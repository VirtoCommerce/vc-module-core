using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class IdsFilter : IFilter
    {
        public IList<string> Values { get; set; }
    }
}
