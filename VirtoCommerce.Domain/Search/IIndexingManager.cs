using System;
using System.Threading;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Search
{
    /// <summary>
    /// Responsible for the functionality of indexing
    /// </summary>
    public interface IIndexingManager
    {
        /// <summary>
        /// Return actual index stats for specific document type
        /// </summary>
        /// <param name="documentType"></param>
        /// <returns></returns>
        Task<IndexState> GetIndexStateAsync(string documentType);

        /// <summary>
        /// Indexing the specified documents with given options
        /// </summary>
        /// <param name="options"></param>
        /// <param name="progressCallback"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task IndexAsync(IndexingOptions options, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken);
    }
}
