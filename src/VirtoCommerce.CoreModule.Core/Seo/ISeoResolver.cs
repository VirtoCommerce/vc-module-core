using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Seo;

[Obsolete("Interface is deprecated, please use SEO module instead.", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
public interface ISeoResolver
{
    Task<IList<SeoInfo>> FindSeoAsync(SeoSearchCriteria criteria);
}
