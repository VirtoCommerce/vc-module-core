using System;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Customer.Events;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Notifications;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Data.Notifications;

namespace VirtoCommerce.CoreModule.Data.Observers
{
    /// <summary>
    /// Send welcome registration email notification when storefront user registered
    /// </summary>
    [Obsolete("Use RegistrationEmailMemberChangedEventHandler instead")]
    public class RegistrationEmailObserver : IObserver<MemberChangingEvent>
    {
        private readonly IStoreService _storeService;
        private readonly ISecurityService _securityService;
        private readonly INotificationManager _notificationManager;
        public RegistrationEmailObserver(IStoreService storeService, ISecurityService securityService, INotificationManager notificationManager)
        {
            _storeService = storeService;
            _securityService = securityService;
            _notificationManager = notificationManager;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {

        } 

        public void OnNext(MemberChangingEvent value)
        {
            var contact = value.Member as Contact;
            if(value.ChangeState == Platform.Core.Common.EntryState.Added && contact != null)
            {
                var usersSearchResult = Task.Run(() => _securityService.SearchUsersAsync(new UserSearchRequest { MemberId = value.Member.Id, TakeCount = int.MaxValue })).Result;
                var storefrontAccount = usersSearchResult.Users.FirstOrDefault(x => x.UserType.EqualsInvariant(AccountType.Customer.ToString()));
                if(storefrontAccount != null)
                {
                    var store = _storeService.GetById(storefrontAccount.StoreId);

                    var notification = _notificationManager.GetNewNotification<RegistrationEmailNotification>(storefrontAccount.StoreId, "Store", string.IsNullOrEmpty(contact.DefaultLanguage) ? store.DefaultLanguage : contact.DefaultLanguage);
                    notification.FirstName = contact.FirstName;
                    notification.LastName = contact.LastName;
                    notification.Login = storefrontAccount.UserName;
                    notification.Sender = store.Email;
                    notification.Recipient = storefrontAccount.Email;

                    _notificationManager.ScheduleSendNotification(notification);
                }
               
            }
        }

     
    }
}
