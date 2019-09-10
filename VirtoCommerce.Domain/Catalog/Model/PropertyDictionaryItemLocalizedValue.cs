using System;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class PropertyDictionaryItemLocalizedValue : ValueObject, ILanguageSupport, ICloneable
    {
        #region ILanguageSupport members
        public string LanguageCode { get; set; }
        #endregion
        public string Value { get; set; }

        #region ICloneable members
        public virtual object Clone()
        {
            return MemberwiseClone() as PropertyDictionaryItemLocalizedValue;
        }
        #endregion
    }
}
