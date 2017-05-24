using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class AggregationResponse
    {
        public string Id { get; set; }
        public IList<AggregationResponseValue> Values { get; set; }
    }
}
