using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public class IndexDocumentConfiguration
    {
        public string DocumentType { get; set; }
        public IIndexDocumentBuilder DocumentBuilder { get; set; }
        public IIndexDocumentChangesProvider ChangesProvider { get; set; }
        public IList<IndexDocumentConfiguration> RelatedConfigurations { get; set; }
    }
}
