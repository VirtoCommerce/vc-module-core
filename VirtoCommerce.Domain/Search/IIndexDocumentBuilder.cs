using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public interface IIndexDocumentBuilder
    {
        IList<IndexDocument> GetDocuments(IList<string> documentIds);
    }
}
