using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Data.Indexing
{
    /// <summary>
    /// Allows queueing indexation working.
    /// Can be a serious performance boost for full re-indexation.
    /// </summary>
    public interface IIndexingWorker
    {
        void IndexDocuments(string documentType, string[] documentIds);

        void DeleteDocuments(string documentType, string[] documentIds);
    }
}
