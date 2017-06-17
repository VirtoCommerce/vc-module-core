namespace VirtoCommerce.Domain.Search
{
    public interface ISearchRequestBuilder
    {
        string DocumentType { get; }
        SearchRequest BuildRequest(SearchCriteria criteria);
    }
}
