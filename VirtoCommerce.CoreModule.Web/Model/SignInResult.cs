using System;
using Microsoft.AspNet.Identity.Owin;

namespace VirtoCommerce.CoreModule.Web.Model
{
    public class SignInResult
    {
        public SignInStatus Status { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTimeOffset? LockoutEndDate { get; set; }
    }
}
