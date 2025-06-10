using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Seo;

[Obsolete("Use VirtoCommerce.Seo.Core.Services.ISeoResolver", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
public interface ISeoResolver
{
    Task<IList<SeoInfo>> FindSeoAsync(SeoSearchCriteria criteria);
}
