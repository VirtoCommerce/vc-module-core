using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public interface IDocumentSet
    {
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        int TotalCount { get; set; }
        object[] Properties { get; set; }
        IDocument[] Documents { get; set; }
        string Name { get; set; }
    }
}
