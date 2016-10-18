using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
	public class ProductAssociation : ValueObject<ProductAssociation>
	{
        /// <summary>
        /// Association type (Accessories, Up-Sales, Cross-Sales, Related etc)
        /// </summary>
        public string Type { get; set; }

        public int Priority { get; set; }

        public int? Quantity { get; set; }
        /// <summary>
        /// Each link element can have an associated object like Product, Category, etc.
        /// Is a primary key of associated object
        /// </summary>
        public string AssociatedObjectId { get; set; }
        /// <summary>
        /// Associated object type : 'product', 'category' etc
        /// </summary>
        public string AssociatedObjectType { get; set; }
        /// <summary>
        /// Associated object
        /// </summary>
        public Entity AssociatedObject { get; set; }

        public string[] Tags { get; set; }

        #region Obsolete properties
        [Obsolete]
        public string Description { get; set; }
        [Obsolete]
        public string Name { get; set; }
        [Obsolete]
        public string AssociatedProductId { get; set; }
        [Obsolete]
        public CatalogProduct AssociatedProduct { get; set; }
        #endregion
    }
}
