using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class CategoryFilterValue : ISearchFilterValue
    {
        public string Outline { get; set; }

        /// <summary>
        /// Gets or sets the id. Which contains category code.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
