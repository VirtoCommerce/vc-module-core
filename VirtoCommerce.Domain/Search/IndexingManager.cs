using System;

namespace VirtoCommerce.Domain.Search
{
    public class IndexingManager
    {
        private readonly ISearchProvider _searchProvider;
        private readonly IndexDocumentConfiguration[] _configs;

        public IndexingManager(ISearchProvider searchProvider, IndexDocumentConfiguration[] configs)
        {
            _searchProvider = searchProvider;
            _configs = configs;
        }

        public void Index(IndexingOptions[] options)
        {
            throw new NotImplementedException();
        }
    }
}
