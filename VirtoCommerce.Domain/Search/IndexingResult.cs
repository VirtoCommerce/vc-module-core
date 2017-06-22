using System.Collections.Generic;
using System.Diagnostics;

namespace VirtoCommerce.Domain.Search
{
    public class IndexingResult
    {
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public IList<IndexingResultItem> Items { get; set; }
    }
}
