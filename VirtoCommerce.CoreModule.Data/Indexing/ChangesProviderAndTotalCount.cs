using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Data.Indexing
{
    public class ChangesProviderAndTotalCount
    {
        public IIndexDocumentChangesProvider Provider { get; set; }
        public long TotalCount { get; set; }
    }
}
