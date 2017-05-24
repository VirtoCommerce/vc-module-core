using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class TermFilter : IFilter
    {
        public string FieldName { get; set; }
        public IList<string> Values { get; set; }
    }
}
