using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class RangeFilter : FilterQuery
    {
        public IList<RangeFilterValue> Values { get; set; }
    }
}
