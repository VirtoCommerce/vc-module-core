using System.Collections.Generic;

namespace VirtoCommerce.Domain.Search
{
    public interface ISearchProvider
    {
        SearchResult Search(SearchQuery query);
        IndexingResult Index(IList<IndexDocument> documents);
        void Remove(IList<IndexDocument> documents);
        void RemoveIndex(string documentType);
    }
}
