using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class OrFilter : IFilter
    {
        public IList<IFilter> ChildFilters { get; set; }
    }
}
