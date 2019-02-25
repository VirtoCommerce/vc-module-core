using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.Domain.Customer.Model
{
    public class Contact : Member, IHasSecurityAccounts, ICloneable
    {
        public string Salutation { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
        public string DefaultLanguage { get; set; }
        public string TimeZone { get; set; }
        public IList<string> Organizations { get; set; }

        public string TaxPayerId { get; set; }
        public string PreferredDelivery { get; set; }
        public string PreferredCommunication { get; set; }
        public string PhotoUrl { get; set; }

        #region IHasSecurityAccounts Members

        /// <summary>
        /// All security accounts associated with this contact
        /// </summary>
        public ICollection<ApplicationUserExtended> SecurityAccounts { get; private set; } = new List<ApplicationUserExtended>();

        #endregion

        public object Clone()
        {
            var clone = (Contact) MemberwiseClone();

            if (Organizations != null)
            {
                clone.Organizations = new List<string>(Organizations);
            }

            clone.SecurityAccounts = SecurityAccounts
                ?.Select(x => (ApplicationUserExtended) x.Clone())
                .ToList();

            return clone;
        }
    }
}
