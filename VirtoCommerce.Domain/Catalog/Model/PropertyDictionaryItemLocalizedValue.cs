using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class PropertyDictionaryItemLocalizedValue : ValueObject, ILanguageSupport
    {
        #region ILanguageSupport members
        public string LanguageCode { get; set; }
        #endregion
        public string Value { get; set; }
    }
}
