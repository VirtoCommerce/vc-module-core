using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class SearchResult
    {
        public long TotalCount { get; set; }
        public long DocumentsCount { get; set; }
        public IList<SearchDocument> Documents { get; set; } = new List<SearchDocument>();
        public IList<Aggregation> Aggregations { get; set; } = new List<Aggregation>();
    }
}
