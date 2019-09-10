using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;

namespace VirtoCommerce.Domain.Catalog.Model
{
    /// <summary>
    /// Represents one outline element: catalog, category or product.
    /// </summary>
    public class OutlineItem : ISeoSupport, ICloneable
    {
        #region ISeoSupport Members

        /// <summary>
        /// Object id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Object type
        /// </summary>
        public string SeoObjectType { get; set; }

        /// <summary>
        /// All SEO records for the object
        /// </summary>
        public ICollection<SeoInfo> SeoInfos { get; set; }

        #endregion

        /// <summary>
        /// True when this object is linked to the virtual parent.
        /// </summary>
        public bool HasVirtualParent { get; set; }

        public virtual object Clone()
        {
            var result = MemberwiseClone() as OutlineItem;
            result.SeoInfos = SeoInfos?.Select(x => x.Clone() as SeoInfo).ToList();
            return result;
        }

        public override string ToString()
        {
            return (HasVirtualParent ? "*" : "") + Id;
        }
    }
}
