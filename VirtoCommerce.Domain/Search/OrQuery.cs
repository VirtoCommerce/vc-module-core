using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class OrQuery : BooleanQuery
    {
        public IList<BaseQuery> ChildQueries { get; set; }
    }
}
