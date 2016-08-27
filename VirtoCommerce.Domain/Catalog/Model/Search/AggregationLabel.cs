using System;

namespace VirtoCommerce.Domain.Catalog.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class AggregationLabel
    {
        public string Language { get; set; }
        public string Label { get; set; }
    }
}
