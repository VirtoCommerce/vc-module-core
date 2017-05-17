namespace VirtoCommerce.Domain.Search
{
    public interface ISearchQueryBuilder
    {
        void BuildQuery(SearchQuery query, BaseSearchCriteria criteria);
    }
}
