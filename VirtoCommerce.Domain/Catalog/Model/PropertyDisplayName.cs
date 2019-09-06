using System;
using VirtoCommerce.Domain.Commerce.Model;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class PropertyDisplayName : ILanguageSupport, ICloneable
    {
        public string Name { get; set; }
        public string LanguageCode { get; set; }

        #region ICloneable members
        public virtual object Clone()
        {
            return MemberwiseClone() as PropertyDisplayName;
        }
        #endregion
    }
}
