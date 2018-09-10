using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Marketing.Model.DynamicContent.Search
{
    public class DynamicContentSearchCriteriaBase : SearchCriteriaBase
    {
        public string FolderId { get; set; }
        public string Keyword { get; set; }
    }
}
