using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public interface ISearchProvider
    {
        void DeleteIndex(string documentType);
        IndexingResult Index(string documentType, IList<IndexDocument> documents);
        SearchResponse Search(string documentType, SearchRequest request);
        IndexingResult Remove(string documentType, IList<IndexDocument> documents);
    }
}
