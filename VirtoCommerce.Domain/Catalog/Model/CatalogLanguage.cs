using System;
using VirtoCommerce.Platform.Core.Common;
namespace VirtoCommerce.Domain.Catalog.Model
{
    public class CatalogLanguage : Entity, ICloneable
    {
        public string CatalogId { get; set; }
        public Catalog Catalog { get; set; }

        public bool IsDefault { get; set; }
        public string LanguageCode { get; set; }

        #region ICloneable members

        public virtual object Clone()
        {
            return MemberwiseClone() as CatalogLanguage;
        }

        #endregion
    }
}
