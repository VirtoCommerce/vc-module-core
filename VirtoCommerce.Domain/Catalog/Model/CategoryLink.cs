
using System;
using VirtoCommerce.Platform.Core.Common;
namespace VirtoCommerce.Domain.Catalog.Model
{
    public class CategoryLink : ValueObject, ICloneable
    {
        /// <summary>
        /// Product order position in virtual catalog
        /// </summary>
        public int Priority { get; set; }
        public string CatalogId { get; set; }
        public Catalog Catalog { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        #region ICloneable members

        public virtual object Clone()
        {
            return MemberwiseClone() as CategoryLink;
        }

        #endregion
    }
}
