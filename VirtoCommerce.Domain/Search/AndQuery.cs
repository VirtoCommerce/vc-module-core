using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class AndQuery : BooleanQuery
    {
        public IList<BaseQuery> ChildQueries { get; set; }
    }
}
