using System;
using System.Threading;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Search
{
    public interface IIndexingManager
    {
        Task<IndexState> GetIndexStateAsync(string documentType);
        Task IndexAsync(IndexingOptions options, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken);
    }
}
