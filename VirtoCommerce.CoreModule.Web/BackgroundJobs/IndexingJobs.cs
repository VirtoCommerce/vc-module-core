using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using Hangfire;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.CoreModule.Web.BackgroundJobs
{
    public class IndexingJobs
    {
        private readonly IndexDocumentConfiguration[] _documentsConfigs;
        private readonly IIndexingManager _indexingManager;
        private readonly ISettingsManager _settingsManager;
        private readonly ILog _logging;

        public IndexingJobs(IndexDocumentConfiguration[] documentsConfigs, IIndexingManager indexingManager, ISettingsManager settingsManager, ILog logging)
        {
            _documentsConfigs = documentsConfigs;
            _indexingManager = indexingManager;
            _settingsManager = settingsManager;
            _logging = logging;
        }

        [DisableConcurrentExecution(60 * 60 * 24)]
        public void Process(string documentType, string[] documentIds)
        {
            // Document IDs make sense only if document type is not empty
            if (string.IsNullOrEmpty(documentType) && !documentIds.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(documentType));

            var allOptions = GetAllIndexingOptions(documentType, documentIds);

            foreach (var options in allOptions)
            {
                Index(options);
            }
        }


        private void Index(IndexingOptions options)
        {
            options.EndDate = options.StartDate != null ? (DateTime?)DateTime.UtcNow : null;
            Task.Run(() => _indexingManager.IndexAsync(options, p => _logging.Trace(p.Description), CancellationToken.None)).GetAwaiter().GetResult();
        }

        private IList<IndexingOptions> GetAllIndexingOptions(string documentType, IList<string> documentIds)
        {
            var result = Task.Run(() => GetAllIndexingOptionsAsync(documentType, documentIds)).GetAwaiter().GetResult();
            return result;
        }


        private async Task<IList<IndexingOptions>> GetAllIndexingOptionsAsync(string documentType, IList<string> documentIds)
        {
            var result = new List<IndexingOptions>();

            var batchSize = _settingsManager.GetValue("VirtoCommerce.Search.IndexPartitionSize", 50);

            if (string.IsNullOrEmpty(documentType))
            {
                var allOptions = await Task.WhenAll(_documentsConfigs.Select(c => GetIndexingOptionsAsync(c.DocumentType, null, batchSize)));
                result.AddRange(allOptions);
            }
            else
            {
                var config = _documentsConfigs.FirstOrDefault(c => c.DocumentType.EqualsInvariant(documentType));
                if (config != null)
                {
                    var options = await GetIndexingOptionsAsync(config.DocumentType, documentIds, batchSize);
                    result.Add(options);
                }
            }

            return result;
        }

        private async Task<IndexingOptions> GetIndexingOptionsAsync(string documentType, IList<string> documentIds, int batchSize)
        {
            var indexState = await _indexingManager.GetIndexStateAsync(documentType);

            return new IndexingOptions
            {
                DocumentType = documentType,
                DocumentIds = documentIds,
                DeleteExistingIndex = false,
                StartDate = indexState.LastIndexationDate,
                BatchSize = batchSize,
            };
        }
    }
}
