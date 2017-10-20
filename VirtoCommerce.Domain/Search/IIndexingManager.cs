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

        /// <summary>
        /// Indexes a batch of documents through the queue.
        /// </summary>
        /// <param name="documentType">Document type to index.</param>
        /// <param name="documentIds">Ids of documents to index.</param>
        /// <param name="priority">Priority for the indexation work.</param>
        void QueueDocumentIndexation(string documentType, string[] documentIds, IndexingPriority priority = IndexingPriority.Default);

        /// <summary>
        /// Deletes a batch of documents from the index through the queue
        /// </summary>
        /// <param name="documentType">Document type to delete.</param>
        /// <param name="documentIds">Ids of documents to delete.</param>
        /// <param name="priority">Priority for the indexation work.</param>
        void QueueDocumentDeletion(string documentType, string[] documentIds, IndexingPriority priority = IndexingPriority.Default);

        /// <summary>
        /// Indexes a batch of documents immediately. Intended to be used by IndexingJobs.
        /// </summary>
        /// <param name="documentType">Document type to index.</param>
        /// <param name="documentIds">Ids of documents to index.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Result of indexing operation.</returns>
        Task<IndexingResult> IndexDocumentsAsync(string documentType, string[] documentIds);

        /// <summary>
        /// Deletes a batch of documents from the index immediately. Intended to be used by IndexingJobs.
        /// </summary>
        /// <param name="documentType">Document type to delete.</param>
        /// <param name="documentIds">Ids of documents to delete.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Result of indexing operation.</returns>
        Task<IndexingResult> DeleteDocumentsAsync(string documentType, string[] documentIds);
    }
}
