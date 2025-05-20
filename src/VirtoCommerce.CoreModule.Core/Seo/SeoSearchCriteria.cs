using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Seo
{
    [Obsolete("Use VirtoCommerce.Seo.Core.Models.SeoSearchCriteria", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public class SeoSearchCriteria : SearchCriteriaBase
    {
        public string UserId { get; set; }
        public string Slug { get; set; }
        public string StoreId { get; set; }
        public string Permalink { get; set; }
    }
}
