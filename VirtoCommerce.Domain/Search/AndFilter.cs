using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class AndFilter : IFilter
    {
        public IList<IFilter> ChildFilters { get; set; }
    }
}
