using System;
using System.Collections.Generic;
using System.Linq;
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
        public virtual object Clone()
        {
            var result = MemberwiseClone() as PropertyDictionaryItem;

            result.LocalizedValues = LocalizedValues?.Select(x => x.Clone() as PropertyDictionaryItemLocalizedValue).ToList() ?? result.LocalizedValues;

            return result;
        }
        #endregion
    }
}
