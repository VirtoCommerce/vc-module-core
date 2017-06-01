using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Tests
{
    public class SearchProvider : ISearchProvider
    {
        public Task DeleteIndexAsync(string documentType)
        {
            return Task.FromResult<object>(null);
        }

        public Task<IndexingResult> IndexAsync(string documentType, IList<IndexDocument> documents)
        {
            var result = new IndexingResult
            {
                Items = documents.Select(GetIndexingResult).ToArray()
            };

            return Task.FromResult(result);
        }

        public Task<IndexingResult> RemoveAsync(string documentType, IList<IndexDocument> documents)
        {
            throw new NotImplementedException();
        }

        public Task<SearchResponse> SearchAsync(string documentType, SearchRequest request)
        {
            throw new NotImplementedException();
        }


        private static IndexingResultItem GetIndexingResult(IndexDocument document)
        {
            var error = string.IsNullOrEmpty(document.Id);

            return new IndexingResultItem
            {
                Id = document.Id,
                Succeeded = !error,
                ErrorMessage = error ? "Document ID is empty" : null,
            };
        }
    }
}
