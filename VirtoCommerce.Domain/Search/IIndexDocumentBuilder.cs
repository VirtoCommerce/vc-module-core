using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Search
{
    public interface IIndexDocumentBuilder
    {
        Task<IList<IndexDocument>> GetDocumentsAsync(IList<string> documentIds);
    }
}
