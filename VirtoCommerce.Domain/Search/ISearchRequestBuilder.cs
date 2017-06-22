using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Search
{
    public interface ISearchRequestBuilder
    {
        string DocumentType { get; }
        SearchRequest BuildRequest(SearchCriteriaBase criteria);
    }
}
