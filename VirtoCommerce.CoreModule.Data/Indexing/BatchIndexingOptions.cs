using System.Collections.Generic;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Data.Indexing
{
    public class BatchIndexingOptions
    {
        public string DocumentType { get; set; }
        public IIndexDocumentBuilder PrimaryDocumentBuilder { get; set; }
        public IList<IIndexDocumentBuilder> SecondaryDocumentBuilders { get; set; }
    }
}
