using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.DynamicProperties;

namespace VirtoCommerce.Domain.Customer.Model
{
    public class Organization : Member, ICloneable
    {
        public string Description { get; set; }
        public string BusinessCategory { get; set; }
        public string OwnerId { get; set; }
        public string ParentId { get; set; }

        public object Clone()
        {
            var clone = (Organization) MemberwiseClone();

            clone.Addresses = Addresses
                ?.Select(x => (Address) x.Clone())
                .ToList();

            if (Phones != null)
            {
                clone.Phones = new List<string>(Phones);
            }

            if (Emails != null)
            {
                clone.Emails = new List<string>(Emails);
            }

            clone.Notes = Notes
                ?.Select(x => (Note) x.Clone())
                .ToList();

            if (Groups != null)
            {
                clone.Groups = new List<string>(Groups);
            }

            clone.DynamicProperties = DynamicProperties
                ?.Select(x => (DynamicObjectProperty) x.Clone())
                .ToList();

            return clone;
        }
    }
}
