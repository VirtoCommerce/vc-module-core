using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class SearchRequest
    {
        public string SearchKeywords { get; set; }
        public IList<string> SearchFields { get; set; }
        public bool IsFuzzySearch { get; set; }
        public int? Fuzziness { get; set; }

        public IFilter Filter { get; set; }

        public IList<AggregationRequest> Aggregations { get; set; }

        public IList<SortingField> Sorting { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
