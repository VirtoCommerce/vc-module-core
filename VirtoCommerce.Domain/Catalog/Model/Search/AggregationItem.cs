using System;

namespace VirtoCommerce.Domain.Catalog.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class AggregationItem
    {
        /// <summary>
        /// Gets or sets the aggregation item value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the aggregation item count
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the flag for aggregation item is applied
        /// </summary>
        public bool IsApplied { get; set; }

        /// <summary>
        /// Gets or sets the collection of the aggregation item labels
        /// </summary>
        public AggregationLabel[] Labels { get; set; }
    }
}
