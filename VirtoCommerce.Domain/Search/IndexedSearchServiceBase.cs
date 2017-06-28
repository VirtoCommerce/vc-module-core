using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Search
{
    public abstract class IndexedSearchServiceBase<TItem, TCriteria> : IIndexedSearchService<TItem, TCriteria>
        where TItem : Entity
        where TCriteria : SearchCriteriaBase
    {
        protected IndexedSearchServiceBase(ISearchRequestBuilder[] searchRequestBuilders, ISearchProvider searchProvider)
        {
            SearchRequestBuilders = searchRequestBuilders;
            SearchProvider = searchProvider;
        }

        protected ISearchRequestBuilder[] SearchRequestBuilders { get; }
        protected ISearchProvider SearchProvider { get; }

        public virtual async Task<GenericSearchResult<TItem>> SearchAsync(TCriteria criteria)
        {
            var result = AbstractTypeFactory<GenericSearchResult<TItem>>.TryCreateInstance();

            var requestBuilder = GetRequestBuilder(criteria);
            var request = requestBuilder?.BuildRequest(criteria);

            var response = await SearchProvider.SearchAsync(criteria.ObjectType, request);

            if (response != null)
            {
                result.TotalCount = (int)response.TotalCount;
                result.Results = ConvertDocuments(response.Documents, criteria);
            }

            return result;
        }

        protected virtual ISearchRequestBuilder GetRequestBuilder(TCriteria criteria)
        {
            var requestBuilder = SearchRequestBuilders?.FirstOrDefault(b => b.DocumentType.Equals(criteria.ObjectType)) ??
                                 SearchRequestBuilders?.FirstOrDefault(b => string.IsNullOrEmpty(b.DocumentType));

            if (requestBuilder == null)
                throw new InvalidOperationException($"No query builders found for document type '{criteria.ObjectType}'");

            return requestBuilder;
        }

        protected virtual ICollection<TItem> ConvertDocuments(IList<SearchDocument> documents, TCriteria criteria)
        {
            ICollection<TItem> result = null;

            if (documents?.Any() == true)
            {
                var itemIds = documents.Select(doc => doc.Id).ToArray();
                var items = GetItemsByIds(itemIds, criteria);
                var itemsMap = items.ToDictionary(m => m.Id, m => m);

                // Preserve documents order
                result = documents
                    .Select(doc => itemsMap[doc.Id.ToString()])
                    //.Where(m => m != null)
                    .ToArray();
            }

            return result;
        }

        protected abstract IList<TItem> GetItemsByIds(IList<string> itemIds, TCriteria criteria);
    }
}
