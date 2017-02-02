using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model
{
    public class MarketingSearchCriteria : SearchCriteriaBase
    {
        public string FolderId { get; set; }

        public string Keyword { get; set; }
    }
}