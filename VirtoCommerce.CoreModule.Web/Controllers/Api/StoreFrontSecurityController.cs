using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.CoreModule.Data.Notifications;
using VirtoCommerce.CoreModule.Web.Converters;
using VirtoCommerce.CoreModule.Web.Model;
using VirtoCommerce.Domain.Customer.Services;
using VirtoCommerce.Domain.Store.Services;
using VirtoCommerce.Platform.Core.Notifications;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Data.Notifications;
using VirtoCommerce.Platform.Data.Security.Identity;

namespace VirtoCommerce.CoreModule.Web.Controllers.Api
{
    [RoutePrefix("api/storefront/security")]
    public class StorefrontSecurityController : ApiController
    {
        private readonly ISecurityService _securityService;
        private readonly Func<ApplicationSignInManager> _signInManagerFactory;
        private readonly Func<ApplicationUserManager> _userManagerFactory;
        private readonly INotificationManager _notificationManager;
        private readonly IStoreService _storeService;
        private readonly IMemberService _memberService;

        public StorefrontSecurityController(
            ISecurityService securityService,
            Func<ApplicationSignInManager> signInManagerFactory,
            Func<ApplicationUserManager> userManagerFactory,
            INotificationManager notificationManager,
            IStoreService storeService,
            IMemberService memberService)
        {
            _securityService = securityService;
            _signInManagerFactory = signInManagerFactory;
            _userManagerFactory = userManagerFactory;
            _notificationManager = notificationManager;
            _storeService = storeService;
            _memberService = memberService;
        }

        /// <summary>
        /// Get user details by user ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/id/{userId}")]
        [ResponseType(typeof(StorefrontUser))]
        public async Task<IHttpActionResult> GetUserById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var user = await _securityService.FindByIdAsync(userId, UserDetails.Reduced);
            if (user != null)
            {
                var result = user.ToWebModel();
                result.AllowedStores = _storeService.GetUserAllowedStoreIds(result);
                return Ok(result);
            }
            return Ok();
        }

        /// <summary>
        /// Get user details by user name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/name/{userName}")]
        [ResponseType(typeof(StorefrontUser))]
        public async Task<IHttpActionResult> GetUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }

            var user = await _securityService.FindByNameAsync(userName, UserDetails.Reduced);
            if (user != null)
            {
                var result = user.ToWebModel();
                result.AllowedStores = _storeService.GetUserAllowedStoreIds(result);
                return Ok(result);
            }

            return Ok();
        }

        /// <summary>
        /// Get user details by user email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/email/{email}")]
        [ResponseType(typeof(StorefrontUser))]
        public async Task<IHttpActionResult> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            var user = await _securityService.FindByEmailAsync(email, UserDetails.Reduced);
            if (user != null)
            {
                var result = user.ToWebModel();
                result.AllowedStores = _storeService.GetUserAllowedStoreIds(result);
                return Ok(result);
            }
            return Ok();
        }

        /// <summary>
        /// Get user details by external login provider
        /// </summary>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/external")]
        [ResponseType(typeof(StorefrontUser))]
        public async Task<IHttpActionResult> GetUserByLogin(string loginProvider, string providerKey)
        {
            if (string.IsNullOrEmpty(loginProvider) || string.IsNullOrEmpty(providerKey))
            {
                return BadRequest();
            }

            var user = await _securityService.FindByLoginAsync(loginProvider, providerKey, UserDetails.Reduced);
            if (user != null)
            {
                var result = user.ToWebModel();
                result.AllowedStores = _storeService.GetUserAllowedStoreIds(result);
                return Ok(result);
            }

            return Ok();
        }

        /// <summary>
        /// Sign in with user name and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user/signin")]
        [ResponseType(typeof(SignInResult))]
        public async Task<IHttpActionResult> PasswordSignIn(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest();
            }

            using (var signInManager = _signInManagerFactory())
            {
                var status = await signInManager.PasswordSignInAsync(userName, password, false, shouldLockout: true);
                var result = new SignInResult { Status = status };

                if (result.Status == Microsoft.AspNet.Identity.Owin.SignInStatus.Success)
                {
                    var user = await _securityService.FindByNameAsync(userName, UserDetails.Full);

                    //Do not allow to login rejected users
                    if (user != null && user.UserState == AccountState.Rejected)
                    {
                        result.Status = Microsoft.AspNet.Identity.Owin.SignInStatus.LockedOut;
                    }

                }

                return Ok(result);
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user")]
        [ResponseType(typeof(SecurityResult))]
        public async Task<IHttpActionResult> Create(ApplicationUserExtended user)
        {
            if (user != null)
            {
                user.PasswordHash = null;
                user.SecurityStamp = null;
            }

            var result = await _securityService.CreateAsync(user);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Generate a password reset token
        /// </summary>
        /// <remarks>
        /// Generates a password reset token and sends a password reset link to the user via email.
        /// </remarks>
        /// <param name="userId"></param>
        /// <param name="storeName"></param>
        /// <param name="language"></param>
        /// <param name="callbackUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user/password/resettoken")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> GenerateResetPasswordToken(string userId, string storeName, string language, string callbackUrl)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(storeName) || string.IsNullOrEmpty(callbackUrl))
            {
                return BadRequest();
            }

            var token = await _securityService.GeneratePasswordResetTokenAsync(userId);

            var uriBuilder = new UriBuilder(callbackUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["code"] = token;
            uriBuilder.Query = query.ToString();

            var notification = _notificationManager.GetNewNotification<ResetPasswordEmailNotification>(storeName, "Store", language);
            notification.Url = uriBuilder.ToString();

            var store = _storeService.GetById(storeName);
            notification.Sender = store.Email;
            notification.Recipient = await GetUserEmailAsync(userId);
            notification.IsActive = true;

            _notificationManager.ScheduleSendNotification(notification);

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Reset a password for the user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user/password/reset")]
        [ResponseType(typeof(SecurityResult))]
        public async Task<IHttpActionResult> ResetPassword(string userId, string token, string newPassword)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(newPassword))
            {
                return BadRequest();
            }

            var result = await _securityService.ResetPasswordAsync(userId, token, newPassword);

            return Ok(result);
        }

        [HttpPost]
        [Route("user/email/sendconfirmation")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> SendEmailConfirmation(string userId, string storeName, string language, string callbackUrl)
        {
            using (var userManager = _userManagerFactory())
            {
                var store = _storeService.GetById(storeName);

                var uriBuilder = new UriBuilder(callbackUrl);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                var token = await userManager.GenerateEmailConfirmationTokenAsync(userId);
                query["code"] = token;
                uriBuilder.Query = query.ToString();

                var notification = _notificationManager.GetNewNotification<EmailConfirmationNotification>(storeName, "Store", language);
                notification.Url = uriBuilder.ToString();
                notification.Recipient = await GetUserEmailAsync(userId);
                notification.Sender = store.Email;
                notification.IsActive = true;

                _notificationManager.ScheduleSendNotification(notification);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("user/email/confirm")]
        [ResponseType(typeof(SecurityResult))]
        public async Task<IHttpActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }

            using (var userManager = _userManagerFactory())
            {
                var result = await userManager.ConfirmEmailAsync(userId, token);

                return Ok(result);
            }
        }

        private async Task<string> GetUserEmailAsync(string userId)
        {
            string email = null;

            var user = await _securityService.FindByIdAsync(userId, UserDetails.Reduced);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.MemberId))
                {
                    var contacts = _memberService.GetByIds(new[] { user.MemberId });
                    var contact = contacts.FirstOrDefault();
                    if (contact != null && contact.Emails != null && contact.Emails.Any())
                    {
                        email = contact.Emails.FirstOrDefault();
                    }
                }
                else if (!string.IsNullOrEmpty(user.Email))
                {
                    email = user.Email;
                }
                else
                {
                    email = user.UserName;
                }
            }

            return email;
        }
    }
}
