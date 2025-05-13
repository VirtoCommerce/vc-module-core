using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Seo
{
    /// <summary>
    /// Used to detect seo duplicates within any object based on it inner structure and relationships (store, catalogs, categories etc)
    /// </summary>
    [Obsolete("Interface is deprecated, please use SEO module instead.", DiagnosticId = "VC0011", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public interface ISeoDuplicatesDetector
    {
        Task<IEnumerable<SeoInfo>> DetectSeoDuplicatesAsync(TenantIdentity tenantIdentity);
    }
}
