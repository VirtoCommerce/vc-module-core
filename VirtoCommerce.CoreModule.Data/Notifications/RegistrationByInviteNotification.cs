using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Notifications;

namespace VirtoCommerce.CoreModule.Data.Notifications
{
    public class RegistrationByInviteNotification : EmailNotification
    {
        public RegistrationByInviteNotification(IEmailNotificationSendingGateway gateway) : base(gateway)
        {
        }

        [NotificationParameter("Invite URL")]
        public string InviteUrl { get; set; }
    }
}
