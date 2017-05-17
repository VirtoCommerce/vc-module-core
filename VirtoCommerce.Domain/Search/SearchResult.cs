using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class SearchResult
    {
        public long TotalCount { get; set; }
        public IList<Document> Documents { get; set; } = new List<Document>();
        public IList<Aggregation> Aggregations { get; set; } = new List<Aggregation>();
    }
}
