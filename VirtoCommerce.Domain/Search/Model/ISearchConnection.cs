using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public interface ISearchConnection
    {
        /// <summary>
        /// Gets the Data Source.
        /// </summary>
        /// <value>
        /// The Data Source.
        /// </value>
        string DataSource { get; }

        string Scope { get; }

        /// <summary>
        /// Gets the provider for the search, can be ElasticSearch, Lucene
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        string Provider { get; }

        string AccessKey { get; }
    }
}
