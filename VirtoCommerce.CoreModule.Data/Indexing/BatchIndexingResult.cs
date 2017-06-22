using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Data.Indexing
{
    public class BatchIndexingResult
    {
        public IndexingResult IndexingResult { get; set; }
        public long ProcessedCount { get; set; }
    }
}
