using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;

namespace VirtoCommerce.Domain.Customer.Model
{
    public class Vendor : Member, ISeoSupport
    {
        /// <summary>
        /// Vendor description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Vendor site url
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// Vendor logo url
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Vendor group
        /// </summary>
        public string GroupName { get; set; }

        #region ISeoSupport Members

        public string SeoObjectType => GetType().Name;
        public ICollection<SeoInfo> SeoInfos { get; set; }

        #endregion

        public override object Clone()
        {
            var clone = (Vendor)base.Clone();

            clone.SeoInfos = SeoInfos
                ?.Select(x => (SeoInfo)x.Clone())
                .ToList();

            return clone;
        }
    }
}
