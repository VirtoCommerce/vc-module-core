using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Seo
{
    public class SeoSearchCriteria : SearchCriteriaBase
    {
        public string Slug { get; set; }
        public string StoreId { get; set; }
        public string RelativeUrl { get; set; }
    }
}
