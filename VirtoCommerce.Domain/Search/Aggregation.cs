using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class Aggregation
    {
        public string Id { get; set; }
        public IList<AggregationValue> Values { get; set; }
    }
}
