namespace VirtoCommerce.Domain.Search
{
    public interface ISearchRequestBuilder
    {
        string DocumentType { get; }
        void BuildRequest(SearchRequest request, SearchCriteria criteria);
    }
}
