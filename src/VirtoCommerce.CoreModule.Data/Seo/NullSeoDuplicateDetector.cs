using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.CoreModule.Core.Seo;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Data.Seo
{
    [Obsolete("Class is deprecated, please use SEO module instead.", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public class NullSeoDuplicateDetector : ISeoDuplicatesDetector
    {
        public Task<IEnumerable<SeoInfo>> DetectSeoDuplicatesAsync(TenantIdentity tenantIdentity)
        {
            return Task.FromResult(Enumerable.Empty<SeoInfo>());
        }
    }
}
