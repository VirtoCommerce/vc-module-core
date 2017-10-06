using Hangfire;
using VirtoCommerce.CoreModule.Data.Indexing;

namespace VirtoCommerce.CoreModule.Web.BackgroundJobs
{
    public class HangfireIndexingWorker : IIndexingWorker
    {
        public void IndexDocuments(string documentType, string[] documentIds)
        {
            BackgroundJob.Enqueue<IndexingManager>(x => x.IndexDocumentsAsync(documentType, documentIds));
        }

        public void DeleteDocuments(string documentType, string[] documentIds)
        {
            BackgroundJob.Enqueue<IndexingManager>(x => x.DeleteDocumentsAsync(documentType, documentIds));
        }
    }
}
