using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class IndexingProgress
    {
        public string DocumentType { get; set; }
        public string Description { get; set; }
        public long? TotalCount { get; set; }
        public long? ProcessedCount { get; set; }
        public long ErrorsCount => Errors?.Count ?? 0;
        public IList<string> Errors { get; set; }
    }
}
