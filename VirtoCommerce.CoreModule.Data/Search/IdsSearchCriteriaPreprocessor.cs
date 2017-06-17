using System.Linq;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Data.Search
{
    public class IdsSearchCriteriaPreprocessor : ISearchCriteriaPreprocessor
    {
        public void Process(SearchCriteria criteria)
        {
            if (criteria?.Ids?.Any() == true)
            {
                criteria.Filters.Add(new IdsFilter { Values = criteria.Ids });
            }
        }
    }
}
