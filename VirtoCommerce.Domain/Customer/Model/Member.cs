using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.DynamicProperties;

namespace VirtoCommerce.Domain.Customer.Model
{
    public abstract class Member : AuditableEntity, IHasDynamicProperties, ICloneable
    {
        protected Member()
        {
            MemberType = GetType().Name;
        }

        public string Name { get; set; }
        public string MemberType { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<string> Phones { get; set; }
        public IList<string> Emails { get; set; }
        public IList<Note> Notes { get; set; }
        public IList<string> Groups { get; set; }

        #region IHasDynamicProperties Members

        public string ObjectType { get; set; }
        public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }

        #endregion

        public virtual object Clone()
        {
            var clone = (Member) MemberwiseClone();

            clone.Addresses = Addresses
                ?.Select(x => (Address) x.Clone())
                .ToList();

            clone.Phones = Phones?.ToList();
            clone.Emails = Emails?.ToList();

            clone.Notes = Notes
                ?.Select(x => (Note) x.Clone())
                .ToList();

            clone.Groups = Groups?.ToList();

            clone.DynamicProperties = DynamicProperties
                ?.Select(x => (DynamicObjectProperty) x.Clone())
                .ToList();

            return clone;
        }
    }
}
