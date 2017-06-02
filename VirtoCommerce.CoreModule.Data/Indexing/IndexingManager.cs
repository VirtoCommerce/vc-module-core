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
            _searchProvider = searchProvider ?? throw new ArgumentNullException(nameof(searchProvider));
            _configs = configs ?? throw new ArgumentNullException(nameof(configs));
        }

        public virtual async Task IndexAsync(IndexingOptions options, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrEmpty(options.DocumentType))
                throw new ArgumentNullException($"{nameof(options)}.{nameof(options.DocumentType)}");

            var documentType = options.DocumentType;

            if (options.RebuildIndex)
            {
                await DeleteIndexAsync(documentType, progressCallback, cancellationToken);
            }

            var configs = _configs.Where(c => c.DocumentType.EqualsInvariant(documentType)).ToArray();

            foreach (var config in configs)
            {
                await ProcessConfigurationAsync(options, config, progressCallback, cancellationToken);
            }
        }


        private async Task DeleteIndexAsync(string documentType, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            progressCallback?.Invoke(new IndexingProgress { DocumentType = documentType, Description = "Deleting index" });

            await _searchProvider.DeleteIndexAsync(documentType);
        }

        private async Task ProcessConfigurationAsync(IndexingOptions options, IndexDocumentConfiguration configuration, Action<IndexingProgress> progressCallback, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

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

            var primaryDocumentBuilder = configuration.DocumentSource.DocumentBuilder;
            var secondaryDocumentBuilders = configuration.RelatedSources?.Where(s => s.DocumentBuilder != null).Select(s => s.DocumentBuilder).ToList();

            var documentType = options.DocumentType;

            progressCallback?.Invoke(new IndexingProgress { DocumentType = documentType, Description = "Calculating documents count" });

            var providersAndCounts = await GetChangesProvidersAndTotalCounts(configuration, options.StartDate, options.EndDate);
            var totalChangesCount = providersAndCounts.Sum(p => p.TotalCount);

            var processedCount = 0L;
            var skip = 0L;

            while (processedCount < totalChangesCount)
            {
                progressCallback?.Invoke(new IndexingProgress { DocumentType = documentType, Description = "Processing", TotalCount = totalChangesCount, ProcessedCount = processedCount });

                var changes = await GetChangesAsync(providersAndCounts, options.StartDate, options.EndDate, skip, options.BatchSize, cancellationToken);
                var indexingResult = await ProcessChanges(documentType, changes, primaryDocumentBuilder, secondaryDocumentBuilders, cancellationToken);

                skip += options.BatchSize;
                processedCount += changes.Count;

                var errors = GetIndexingErrors(indexingResult);
                progressCallback?.Invoke(new IndexingProgress { DocumentType = documentType, Description = "Processed", TotalCount = totalChangesCount, ProcessedCount = processedCount, Errors = errors });
            }

            progressCallback?.Invoke(new IndexingProgress { DocumentType = documentType, Description = "Completed" });
        }

        private static async Task<ProviderAndCount[]> GetChangesProvidersAndTotalCounts(IndexDocumentConfiguration configuration, DateTime? startDate, DateTime? endDate)
        {
            var changesProviders = new List<IIndexDocumentChangesProvider> { configuration.DocumentSource.ChangesProvider };
            if (configuration.RelatedSources != null)
            {
                changesProviders.AddRange(configuration.RelatedSources.Where(s => s.ChangesProvider != null).Select(s => s.ChangesProvider));
            }

            return await Task.WhenAll(changesProviders.Select(async p => new ProviderAndCount { Provider = p, TotalCount = await p.GetTotalChangesCountAsync(startDate, endDate) }));
        }

        private static async Task<IList<IndexDocumentChange>> GetChangesAsync(IEnumerable<ProviderAndCount> providersAndCounts, DateTime? startDate, DateTime? endDate, long skip, long take, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Request changes only from those providers that reported total count greater than the skip value
            var tasks = providersAndCounts
                .Where(p => skip < p.TotalCount)
                .Select(p => p.Provider.GetChangesAsync(startDate, endDate, skip, take));

            var results = await Task.WhenAll(tasks);

            var result = results.SelectMany(r => r).ToList();
            return result;
        }

        private async Task<IndexingResult> ProcessChanges(string documentType, IEnumerable<IndexDocumentChange> changes, IIndexDocumentBuilder primaryDocumentBuilder, IList<IIndexDocumentBuilder> secondaryDocumentBuilders, CancellationToken cancellationToken)
        {
            var result = new IndexingResult();

            var groups = GetLatestChangesForEachDocumentGroupedByChangeType(changes);

            foreach (var group in groups)
            {
                var changeType = group.Key;
                var documentIds = group.Value;

                var groupResult = await ProcessDocuments(documentType, changeType, documentIds, primaryDocumentBuilder, secondaryDocumentBuilders, cancellationToken);

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

        private static IList<string> GetIndexingErrors(IndexingResult indexingResult)
        {
            var errors = indexingResult?.Items?
                .Where(i => !i.Succeeded)
                .Select(i => $"ID: {i.Id}, Error: {i.ErrorMessage}")
                .ToList();

            return errors?.Any() == true ? errors : null;
        }

        private static IDictionary<IndexDocumentChangeType, string[]> GetLatestChangesForEachDocumentGroupedByChangeType(IEnumerable<IndexDocumentChange> changes)
        {
            var result = changes
                .GroupBy(c => c.DocumentId)
                .Select(g => g.OrderByDescending(o => o.ChangeDate).First())
                .GroupBy(c => c.ChangeType)
                .ToDictionary(g => g.Key, g => g.Select(c => c.DocumentId).ToArray());

            return result;
        }

        private async Task<IndexingResult> ProcessDocuments(string documentType, IndexDocumentChangeType changeType, IList<string> documentIds, IIndexDocumentBuilder primaryDocumentBuilder, IEnumerable<IIndexDocumentBuilder> secondaryDocumentBuilders, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            IndexingResult result = null;

            if (changeType == IndexDocumentChangeType.Deleted)
            {
                result = await DeleteDocumentsAsync(documentType, documentIds, cancellationToken);
            }
            else if (changeType == IndexDocumentChangeType.Modified)
            {
                result = await IndexDocumentsAsync(documentType, documentIds, primaryDocumentBuilder, secondaryDocumentBuilders, cancellationToken);
            }

            return result;
        }

        private async Task<IndexingResult> DeleteDocumentsAsync(string documentType, IEnumerable<string> documentIds, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var documents = documentIds.Select(id => new IndexDocument(id)).ToList();
            var response = await _searchProvider.RemoveAsync(documentType, documents);
            return response;
        }

        private async Task<IndexingResult> IndexDocumentsAsync(string documentType, IList<string> documentIds, IIndexDocumentBuilder primaryDocumentBuilder, IEnumerable<IIndexDocumentBuilder> secondaryDocumentBuilders, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var documents = await GetDocuments(documentIds, primaryDocumentBuilder, secondaryDocumentBuilders, cancellationToken);
            var response = await _searchProvider.IndexAsync(documentType, documents);
            return response;
        }

        private async Task<IList<IndexDocument>> GetDocuments(IList<string> documentIds, IIndexDocumentBuilder primaryDocumentBuilder, IEnumerable<IIndexDocumentBuilder> secondaryDocumentBuilders, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var primaryDocuments = await primaryDocumentBuilder.GetDocumentsAsync(documentIds);
            var primaryDocumentIds = primaryDocuments.Select(d => d.Id).ToArray();
            var secondaryDocuments = await GetSecondaryDocuments(secondaryDocumentBuilders, primaryDocumentIds, cancellationToken);

            MergeDocuments(primaryDocuments, secondaryDocuments);

            return primaryDocuments;
        }

        private async Task<IList<IndexDocument>> GetSecondaryDocuments(IEnumerable<IIndexDocumentBuilder> secondaryDocumentBuilders, IList<string> documentIds, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var tasks = secondaryDocumentBuilders.Select(p => p.GetDocumentsAsync(documentIds));
            var results = await Task.WhenAll(tasks);

            var result = results.SelectMany(r => r).ToList();
            return result;
        }

        private void MergeDocuments(IEnumerable<IndexDocument> primaryDocuments, IList<IndexDocument> secondaryDocuments)
        {
            foreach (var primaryDocument in primaryDocuments)
            {
                foreach (var secondaryDocument in secondaryDocuments.Where(d => d.Id.EqualsInvariant(primaryDocument.Id)))
                {
                    primaryDocument.Merge(secondaryDocument);
                }
            }
        }


        private class ProviderAndCount
        {
            public IIndexDocumentChangesProvider Provider { get; set; }
            public long TotalCount { get; set; }
        }
    }
}
