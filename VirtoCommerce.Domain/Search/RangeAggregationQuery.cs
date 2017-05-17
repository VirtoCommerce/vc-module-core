using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class RangeAggregationQuery : BaseAggregationQuery
    {
        public IList<RangeAggregationQueryValue> Values { get; set; }
    }
}
