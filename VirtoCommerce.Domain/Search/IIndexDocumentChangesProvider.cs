using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Search
{
    public interface IIndexDocumentChangesProvider
    {
        Task<long> GetTotalChangesCountAsync(DateTime? startDate, DateTime? endDate);
        Task<IList<IndexDocumentChange>> GetChangesAsync(DateTime? startDate, DateTime? endDate, long skip, long take);
    }
}
