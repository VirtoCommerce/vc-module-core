using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Data.Indexing
{
    public class IndexingManager : IIndexingManager
    {
        private readonly ISearchProvider _searchProvider;
        private readonly IndexDocumentConfiguration[] _configs;

        public IndexingManager(ISearchProvider searchProvider, IndexDocumentConfiguration[] configs)
        {
            if (searchProvider == null)
                throw new ArgumentNullException(nameof(searchProvider));
            if (configs == null)
                throw new ArgumentNullException(nameof(configs));

            _searchProvider = searchProvider;
            _configs = configs;
        }

        public virtual async Task<IndexState> GetIndexStateAsync(string documentType)
        {
            var result = new IndexState { DocumentType = documentType };

            var searchRequest = new SearchRequest
            {
                Sorting = new[] { new SortingField { FieldName = KnownDocumentFields.IndexationDate, IsDescending = true } },
                Take = 1,
            };

            try
            {
                var searchResponse = await _searchProvider.SearchAsync(documentType, searchRequest);

                result.IndexedDocumentsCount = searchResponse.TotalCount;

                if (searchResponse.Documents?.Any() == true)
                {
                    var indexationDate = searchResponse.Documents[0].Where(kvp => kvp.Key.EqualsInvariant(KnownDocumentFields.IndexationDate)).Select(x => x.Value).FirstOrDefault();
                    if (indexationDate != null)
                    {
                        long ticks;
                        if (Int64.TryParse(indexationDate.ToString(), out ticks))
                        {
                            result.LastIndexationDate = new DateTime(ticks);
                        }
                        else
                        {
                            result.LastIndexationDate = Convert.ToDateTime(indexationDate);
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }

        public virtual async Task IndexAsync(IndexingOptions options, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ValidateOptions(options);

            var documentType = options.DocumentType;

            if (options.DeleteExistingIndex)
            {
                await DeleteIndexAsync(documentType, progressCallback, cancellationToken);
            }

            var configs = _configs.Where(c => c.DocumentType.EqualsInvariant(documentType)).ToArray();

            foreach (var config in configs)
            {
                await ProcessConfigurationAsync(config, options, progressCallback, cancellationToken);
            }
        }


        protected virtual void ValidateOptions(IndexingOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrEmpty(options.DocumentType))
                throw new ArgumentNullException($"{nameof(options)}.{nameof(options.DocumentType)}");
            if (options.BatchSize < 1)
                throw new ArgumentException(@"Batch size cannon be less than 1", $"{nameof(options)}.{nameof(options.BatchSize)}");
        }

        protected virtual async Task DeleteIndexAsync(string documentType, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            progressCallback?.Invoke(new IndexingProgress($"{documentType}: deleting index", documentType));
            await _searchProvider.DeleteIndexAsync(documentType);
        }

        protected virtual async Task ProcessConfigurationAsync(IndexDocumentConfiguration configuration, IndexingOptions options, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ValidateConfiguration(configuration);

            var documentType = options.DocumentType;

            progressCallback?.Invoke(new IndexingProgress($"{documentType}: calculating total count", documentType));
            var batchOptions = await GetBatchOptionsAsync(configuration, options);

            var processedCount = 0L;
            var totalCount = batchOptions.TotalCount;

            while (processedCount < totalCount)
            {
                var batchResult = await ProcessBatchAsync(batchOptions, cancellationToken);

                processedCount += batchResult.ProcessedCount;
                batchOptions.Skip += batchOptions.BatchSize;

                var errors = GetIndexingErrors(batchResult.IndexingResult);

                progressCallback?.Invoke(new IndexingProgress($"{documentType}: {processedCount} of {totalCount} have been indexed", documentType, totalCount, processedCount, errors));
            }

            progressCallback?.Invoke(new IndexingProgress($"{documentType}: indexation finished", documentType, totalCount, processedCount));
        }

        protected virtual void ValidateConfiguration(IndexDocumentConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));
            if (string.IsNullOrEmpty(configuration.DocumentType))
                throw new ArgumentNullException($"{nameof(configuration)}.{nameof(configuration.DocumentType)}");
            if (configuration.DocumentSource == null)
                throw new ArgumentNullException($"{nameof(configuration)}.{nameof(configuration.DocumentSource)}");
            if (configuration.DocumentSource.ChangesProvider == null)
                throw new ArgumentNullException($"{nameof(configuration)}.{nameof(configuration.DocumentSource)}.{nameof(configuration.DocumentSource.ChangesProvider)}");
            if (configuration.DocumentSource.DocumentBuilder == null)
                throw new ArgumentNullException($"{nameof(configuration)}.{nameof(configuration.DocumentSource)}.{nameof(configuration.DocumentSource.DocumentBuilder)}");
        }

        private async Task<BatchIndexingOptions> GetBatchOptionsAsync(IndexDocumentConfiguration configuration, IndexingOptions options)
        {
            var result = new BatchIndexingOptions
            {
                DocumentType = options.DocumentType,
                DocumentIds = options.DocumentIds,
                StartDate = options.StartDate,
                EndDate = options.EndDate,
                BatchSize = options.BatchSize,

                PrimaryDocumentBuilder = configuration.DocumentSource.DocumentBuilder,
                SecondaryDocumentBuilders = configuration.RelatedSources?.Where(s => s.DocumentBuilder != null).Select(s => s.DocumentBuilder).ToList(),
            };

            if (options.DocumentIds != null)
            {
                result.TotalCount = options.DocumentIds.Count;
            }
            else
            {
                result.ChangesProvidersAndTotalCounts = await GetChangesProvidersAndTotalCountsAsync(configuration, options.StartDate, options.EndDate);
                result.TotalCount = result.ChangesProvidersAndTotalCounts.Sum(p => p.TotalCount);
            }

            return result;
        }

        protected virtual async Task<BatchIndexingResult> ProcessBatchAsync(BatchIndexingOptions batchOptions, CancellationToken cancellationToken)
        {
            var result = new BatchIndexingResult();

            if (batchOptions.DocumentIds != null)
            {
                var documentIds = batchOptions.DocumentIds.Skip((int)batchOptions.Skip).Take(batchOptions.BatchSize).ToList();
                result.IndexingResult = await ProcessDocumentsAsync(IndexDocumentChangeType.Modified, documentIds, batchOptions, cancellationToken);
                result.ProcessedCount += documentIds.Count;
            }
            else
            {
                var changes = await GetChangesAsync(batchOptions, cancellationToken);
                result.IndexingResult = await ProcessChangesAsync(changes, batchOptions, cancellationToken);
                result.ProcessedCount += changes.Count;
            }

            return result;
        }

        protected virtual async Task<ChangesProviderAndTotalCount[]> GetChangesProvidersAndTotalCountsAsync(IndexDocumentConfiguration configuration, DateTime? startDate, DateTime? endDate)
        {
            var changesProviders = new List<IIndexDocumentChangesProvider> { configuration.DocumentSource.ChangesProvider };
            if (configuration.RelatedSources != null)
            {
                changesProviders.AddRange(configuration.RelatedSources.Where(s => s.ChangesProvider != null).Select(s => s.ChangesProvider));
            }

            var result = await Task.WhenAll(changesProviders.Select(async p => new ChangesProviderAndTotalCount { Provider = p, TotalCount = await p.GetTotalChangesCountAsync(startDate, endDate) }));
            return result;
        }

        protected virtual async Task<IList<IndexDocumentChange>> GetChangesAsync(BatchIndexingOptions batchOptions, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Request changes only from those providers that reported total count greater than the skip value
            var tasks = batchOptions.ChangesProvidersAndTotalCounts
                .Where(p => batchOptions.Skip < p.TotalCount)
                .Select(p => p.Provider.GetChangesAsync(batchOptions.StartDate, batchOptions.EndDate, batchOptions.Skip, batchOptions.BatchSize));

            var results = await Task.WhenAll(tasks);

            var result = results.Where(r => r != null).SelectMany(r => r).ToList();
            return result;
        }

        protected virtual async Task<IndexingResult> ProcessChangesAsync(IEnumerable<IndexDocumentChange> changes, BatchIndexingOptions batchOptions, CancellationToken cancellationToken)
        {
            var result = new IndexingResult();

            var groups = GetLatestChangesForEachDocumentGroupedByChangeType(changes);

            foreach (var group in groups)
            {
                var changeType = group.Key;
                var documentIds = group.Value;

                var groupResult = await ProcessDocumentsAsync(changeType, documentIds, batchOptions, cancellationToken);

                if (groupResult?.Items != null)
                {
                    if (result.Items == null)
                    {
                        result.Items = new List<IndexingResultItem>();
                    }

                    result.Items.AddRange(groupResult.Items);
                }
            }

            return result;
        }

        protected virtual IList<string> GetIndexingErrors(IndexingResult indexingResult)
        {
            var errors = indexingResult?.Items?
                .Where(i => !i.Succeeded)
                .Select(i => $"ID: {i.Id}, Error: {i.ErrorMessage}")
                .ToList();

            return errors?.Any() == true ? errors : null;
        }

        protected virtual IDictionary<IndexDocumentChangeType, string[]> GetLatestChangesForEachDocumentGroupedByChangeType(IEnumerable<IndexDocumentChange> changes)
        {
            var result = changes
                .GroupBy(c => c.DocumentId)
                .Select(g => g.OrderByDescending(o => o.ChangeDate).First())
                .GroupBy(c => c.ChangeType)
                .ToDictionary(g => g.Key, g => g.Select(c => c.DocumentId).ToArray());

            return result;
        }

        protected virtual async Task<IndexingResult> ProcessDocumentsAsync(IndexDocumentChangeType changeType, IList<string> documentIds, BatchIndexingOptions batchOptions, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            IndexingResult result = null;

            if (changeType == IndexDocumentChangeType.Deleted)
            {
                result = await DeleteDocumentsAsync(batchOptions.DocumentType, documentIds, cancellationToken);
            }
            else if (changeType == IndexDocumentChangeType.Modified)
            {
                result = await IndexDocumentsAsync(batchOptions.DocumentType, documentIds, batchOptions.PrimaryDocumentBuilder, batchOptions.SecondaryDocumentBuilders, cancellationToken);
            }

            return result;
        }

        protected virtual async Task<IndexingResult> DeleteDocumentsAsync(string documentType, IList<string> documentIds, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var documents = documentIds.Select(id => new IndexDocument(id)).ToList();
            var response = await _searchProvider.RemoveAsync(documentType, documents);
            return response;
        }

        protected virtual async Task<IndexingResult> IndexDocumentsAsync(string documentType, IList<string> documentIds, IIndexDocumentBuilder primaryDocumentBuilder, IEnumerable<IIndexDocumentBuilder> secondaryDocumentBuilders, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var documents = await GetDocumentsAsync(documentIds, primaryDocumentBuilder, secondaryDocumentBuilders, cancellationToken);
            var response = await _searchProvider.IndexAsync(documentType, documents);
            return response;
        }

        protected virtual async Task<IList<IndexDocument>> GetDocumentsAsync(IList<string> documentIds, IIndexDocumentBuilder primaryDocumentBuilder, IEnumerable<IIndexDocumentBuilder> secondaryDocumentBuilders, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var primaryDocuments = await primaryDocumentBuilder.GetDocumentsAsync(documentIds);
            var primaryDocumentIds = primaryDocuments.Select(d => d.Id).ToArray();

            if (secondaryDocumentBuilders != null)
            {
                var secondaryDocuments = await GetSecondaryDocumentsAsync(secondaryDocumentBuilders, primaryDocumentIds, cancellationToken);

                MergeDocuments(primaryDocuments, secondaryDocuments);
            }

            // Add system fields
            foreach (var document in primaryDocuments)
            {
                document.Add(new IndexDocumentField(KnownDocumentFields.IndexationDate, DateTime.UtcNow) { IsRetrievable = true, IsFilterable = true });
            }

            return primaryDocuments;
        }

        protected virtual async Task<IList<IndexDocument>> GetSecondaryDocumentsAsync(IEnumerable<IIndexDocumentBuilder> secondaryDocumentBuilders, IList<string> documentIds, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var tasks = secondaryDocumentBuilders.Select(p => p.GetDocumentsAsync(documentIds));
            var results = await Task.WhenAll(tasks);

            var result = results.Where(r => r != null).SelectMany(r => r).ToList();
            return result;
        }

        protected virtual void MergeDocuments(IEnumerable<IndexDocument> primaryDocuments, IList<IndexDocument> secondaryDocuments)
        {
            var secondaryDocumentGroups = secondaryDocuments
                .GroupBy(d => d.Id)
                .ToDictionary(g => g.Key, g => g, StringComparer.OrdinalIgnoreCase);

            foreach (var primaryDocument in primaryDocuments)
            {
                if (secondaryDocumentGroups.ContainsKey(primaryDocument.Id))
                {
                    var secondaryDocumentGroup = secondaryDocumentGroups[primaryDocument.Id];

                    foreach (var secondaryDocument in secondaryDocumentGroup)
                    {
                        primaryDocument.Merge(secondaryDocument);
                    }
                }
            }
        }
    }
}
