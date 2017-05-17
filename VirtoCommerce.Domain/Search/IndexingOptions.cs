using System;
using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class IndexingOptions
    {
        public string DocumentType { get; set; }
        public bool RebuildIndex { get; set; }
        public IList<string> Ids { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
