using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.Domain.Customer.Model
{
    public class Employee : Member, IHasSecurityAccounts
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

        /// <summary>
        /// Employee type
        /// </summary>
        public string EmployeeType { get; set; }

        /// <summary>
        /// Employee activity flag
        /// </summary>
        public bool IsActive { get; set; }

        public string PhotoUrl { get; set; }

        #region IHasSecurityAccounts Members

        /// <summary>
        /// All security accounts associated with this employee
        /// </summary>
        public ICollection<ApplicationUserExtended> SecurityAccounts { get; private set; } = new List<ApplicationUserExtended>();

        #endregion

        public override object Clone()
        {
            var clone = (Employee)base.Clone();

            clone.Organizations = Organizations?.ToList();

            clone.SecurityAccounts = SecurityAccounts
                ?.Select(x => (ApplicationUserExtended)x.Clone())
                .ToList();

            return clone;
        }
    }
}
