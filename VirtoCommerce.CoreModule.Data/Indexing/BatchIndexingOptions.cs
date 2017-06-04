using System;
using System.Collections.Generic;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Data.Indexing
{
    public class BatchIndexingOptions
    {
        public string DocumentType { get; set; }
        public IList<string> DocumentIds { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int BatchSize { get; set; }
        public long Skip { get; set; }
        public long TotalCount { get; set; }
        public IList<ChangesProviderAndTotalCount> ChangesProvidersAndTotalCounts { get; set; }
        public IIndexDocumentBuilder PrimaryDocumentBuilder { get; set; }
        public IList<IIndexDocumentBuilder> SecondaryDocumentBuilders { get; set; }
    }
}
