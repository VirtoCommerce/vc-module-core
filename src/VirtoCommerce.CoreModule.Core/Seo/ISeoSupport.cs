using System;
using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Seo
{
    [Obsolete("Interface is deprecated, please use SEO module instead.", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public interface ISeoSupport : IEntity
    {
        string SeoObjectType { get; }
        IList<SeoInfo> SeoInfos { get; set; }
    }
}
