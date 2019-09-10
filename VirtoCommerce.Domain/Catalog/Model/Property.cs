using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class Property : AuditableEntity, IInheritable, ICloneable
    {
        public string CatalogId { get; set; }
        public Catalog Catalog { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
        public bool Dictionary { get; set; }
        public bool Multivalue { get; set; }
        public bool Multilanguage { get; set; }
        public bool Hidden { get; set; }
        public PropertyValueType ValueType { get; set; }
        public PropertyType Type { get; set; }
        public ICollection<PropertyAttribute> Attributes { get; set; }
        [Obsolete("No longer populated, use IProperyDictionaryValueService instead")]
        public ICollection<PropertyDictionaryValue> DictionaryValues { get; set; }
        public ICollection<PropertyDisplayName> DisplayNames { get; set; }
        public ICollection<PropertyValidationRule> ValidationRules { get; set; }

        /// <summary>
        /// Because we not have a direct link between prop values and properties we should
        /// find property value meta information by comparing key properties like name and value type.
        /// </summary>
        /// <param name="propValue"></param>
        /// <returns></returns>
        public bool IsSuitableForValue(PropertyValue propValue)
        {
            return String.Equals(Name, propValue.PropertyName, StringComparison.InvariantCultureIgnoreCase) && ValueType == propValue.ValueType;
        }

        #region IInheritable Members
        public bool IsInherited { get; set; }
        #endregion

        #region ICloneable members
        public virtual object Clone()
        {
            var result = MemberwiseClone() as Property;

            result.Attributes = Attributes?.Select(x => x.Clone() as PropertyAttribute).ToList() ?? result.Attributes;
            result.DisplayNames = DisplayNames?.Select(x => x.Clone() as PropertyDisplayName).ToList() ?? result.DisplayNames;
            result.ValidationRules = ValidationRules?.Select(x => x.Clone() as PropertyValidationRule).ToList() ?? result.ValidationRules;

            return result;
        }
        #endregion
    }
}
