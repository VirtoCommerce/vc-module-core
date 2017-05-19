using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public interface ISearchProvider
    {
        void DeleteIndex(string documentType);
        IndexingResult Index(string documentType, IList<IndexDocument> documents);
        SearchResult Search(string documentType, SearchQuery query);
        void Remove(string documentType, IList<IndexDocument> documents);
    }
}
