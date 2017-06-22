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
        public void ProcessChanges(string documentType)
        {
            var allOptions = GetAllIndexingOptions(documentType);

            foreach (var options in allOptions)
            {
                var now = DateTime.UtcNow;
                options.EndDate = options.StartDate != null ? (DateTime?)now : null;

                Index(options);

                SetLastIndexationDate(options.DocumentType, options.StartDate, now);
            }
        }


        private void Index(IndexingOptions options)
        {
            Task.Run(() => _indexingManager.IndexAsync(options, p => _logging.Trace(p.Description), CancellationToken.None)).GetAwaiter().GetResult();
        }

        private IList<IndexingOptions> GetAllIndexingOptions(string documentType)
        {
            var configs = _documentsConfigs.AsQueryable();

            if (!string.IsNullOrEmpty(documentType))
            {
                configs = configs.Where(c => c.DocumentType.EqualsInvariant(documentType));
            }

            var result = configs.Select(c => GetIndexingOptions(c.DocumentType)).ToList();
            return result;
        }

        private IndexingOptions GetIndexingOptions(string documentType)
        {
            return new IndexingOptions
            {
                DocumentType = documentType,
                DeleteExistingIndex = false,
                StartDate = GetLastIndexationDate(documentType),
                BatchSize = GetBatchSize(),
            };
        }

        private DateTime? GetLastIndexationDate(string documentType)
        {
            return _settingsManager.GetValue(GetLastIndexationDateName(documentType), (DateTime?)null);
        }

        private void SetLastIndexationDate(string documentType, DateTime? oldValue, DateTime newValue)
        {
            var currentValue = GetLastIndexationDate(documentType);
            if (currentValue == oldValue)
            {
                _settingsManager.SetValue(GetLastIndexationDateName(documentType), newValue);
            }
        }

        private static string GetLastIndexationDateName(string documentType)
        {
            return $"VirtoCommerce.Search.IndexingJobs.IndexationDate.{documentType}";
        }

        private int GetBatchSize()
        {
            return _settingsManager.GetValue("VirtoCommerce.Search.IndexPartitionSize", 50);
        }
    }
}
