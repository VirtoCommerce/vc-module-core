namespace VirtoCommerce.Domain.Search
{
    public interface ISearchRequestBuilder
    {
        void BuildRequest(SearchRequest request, SearchCriteria criteria);
    }
}
