using Microsoft.AspNet.Identity.Owin;

namespace VirtoCommerce.CoreModule.Web.Model
{
    public class SignInResult
    {
        public SignInStatus Status { get; set; }

        private bool _emailConfirmationRequired;

        public bool EmailConfirmationRequired
        {
            get => _emailConfirmationRequired;
            set
            {
                _emailConfirmationRequired = value;
                if (value)
                    Status = SignInStatus.Failure;
            }
        }
    }
}
