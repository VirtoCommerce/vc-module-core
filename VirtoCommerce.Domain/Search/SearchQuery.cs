using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class SearchQuery
    {
        public string Keywords { get; set; }
        public BaseQuery Filter { get; set; }
        public IList<BaseAggregationQuery> Aggregations { get; set; }
        public IList<SortingField> Sorting { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
