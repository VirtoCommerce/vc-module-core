using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class SearchDocument : Dictionary<string, object>
    {
        public string Id { get; set; }
    }
}
