using System;
using System.Threading;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Search
{
    public interface IIndexingManager
    {
        Task IndexAsync(IndexingOptions options, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken);
    }
}
