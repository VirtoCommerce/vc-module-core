using System;
using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public interface IIndexDocumentChangesProvider
    {
        long GetTotalChangesCount(DateTime startDate, DateTime endDate);
        IList<IndexDocumentChange> GetChanges(DateTime startDate, DateTime endDate, long skip, long take);
    }
}
