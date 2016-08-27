using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class FacetLabel
    {
        public string Language { get; set; }
        public string Label { get; set; }
    }
}
