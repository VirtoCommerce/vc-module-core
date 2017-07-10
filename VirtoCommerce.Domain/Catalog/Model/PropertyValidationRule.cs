using System;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class PropertyValidationRule : Entity, IInheritable, ICloneable
    {
        public bool IsUnique { get; set; }

        public int? CharCountMin { get; set; }

        public int? CharCountMax { get; set; }

        public string RegExp { get; set; }

        public string PropertyId { get; set; }

        public Property Property { get; set; }

        public bool IsInherited { get; set; }

        public object Clone()
        {
            var retVal = new PropertyValidationRule();
            retVal.Id = Id;
            retVal.IsUnique = IsUnique;
            retVal.CharCountMin = CharCountMin;
            retVal.CharCountMax = CharCountMax;
            retVal.RegExp = RegExp;

            retVal.PropertyId = PropertyId;
            retVal.Property = Property != null ? Property.Clone() as Property : null;

            return retVal;
        }
    }
}
