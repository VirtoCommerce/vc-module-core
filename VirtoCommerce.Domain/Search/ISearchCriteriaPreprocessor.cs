namespace VirtoCommerce.Domain.Search
{
    public interface ISearchCriteriaPreprocessor
    {
        void Process(SearchCriteria criteria);
    }
}
