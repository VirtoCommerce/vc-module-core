using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class TermsFilter : FilterQuery
    {
        public IList<string> Values { get; set; }
    }
}
