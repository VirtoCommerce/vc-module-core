using System;
using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class PropertyDictionaryItem : Entity, ICloneable
    {
        public string PropertyId { get; set; }
        public string Alias { get; set; }
        public int SortOrder { get; set; }
        public ICollection<PropertyDictionaryItemLocalizedValue> LocalizedValues { get; set; }

        #region ICloneable members
        public object Clone()
        {
            var retVal = MemberwiseClone() as PropertyDictionaryItem;
            return retVal;
        }
        #endregion
    }
}
