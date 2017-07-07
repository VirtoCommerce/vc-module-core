// This indexing jobs implementation allows only one job to perform indexing.
// If some job is started successfully, all other jobs will terminate with "Indexation is already in progress" error until the first job is finished.
// The synchronization is done by checking the static field _cancellationTokenSource. If it is not null, then some job is already running.
// This scenario requires the platform and hangfire server to run in the same application.

// TODO: Implement indexation for multiple servers. Distribute different document partions between servers for parallel indexation.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using VirtoCommerce.CoreModule.Web.Model.PushNotifcations;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.CoreModule.Web.BackgroundJobs
{
    public class IndexingJobs
    {
        private static readonly object _lockObject = new object();
        private static CancellationTokenSource _cancellationTokenSource;

        private readonly IndexDocumentConfiguration[] _documentsConfigs;
        private readonly IIndexingManager _indexingManager;
        private readonly ISettingsManager _settingsManager;
        private readonly IndexProgressHandler _progressHandler;

        public IndexingJobs(IndexDocumentConfiguration[] documentsConfigs, IIndexingManager indexingManager, ISettingsManager settingsManager, IndexProgressHandler progressHandler)
        {
            _documentsConfigs = documentsConfigs;
            _indexingManager = indexingManager;
            _settingsManager = settingsManager;
            _progressHandler = progressHandler;
        }

        // Enqueue a background job with single notification object for all given options
        public static IndexProgressPushNotification Enqueue(string currentUserName, IndexingOptions[] options)
        {
            var notification = IndexProgressHandler.CreateNotification(currentUserName, null);
            BackgroundJob.Enqueue<IndexingJobs>(j => j.IndexAllDocumentsJob(currentUserName, notification.Id, options));
            return notification;
        }

        // Cancel current indexation if there is one
        public static void CancelIndexation()
        {
            lock (_lockObject)
            {
                _cancellationTokenSource?.Cancel();
            }
        }

        // One-time job for manual indexation
        public async Task IndexAllDocumentsJob(string userName, string notificationId, IndexingOptions[] options)
        {
            // Use single notification for all options (document types)
            await IndexAsync(userName, notificationId, false, options, IndexAllDocumentsAsync);
        }

        // Recurring job for automatic changes indexation.
        // It should push separate notification for each document type if any changes were indexed for this type
        public async Task IndexChangesJob(string documentType)
        {
            var allOptions = GetAllIndexingOptions(documentType);

            // Create different notification for each option (document type)
            foreach (var options in allOptions)
            {
                await IndexAsync(null, null, true, new[] { options }, IndexChangesAsync);
            }
        }


        private async Task IndexAsync(string currentUserName, string notificationId, bool suppressInsignificantNotifications, IEnumerable<IndexingOptions> allOptions, Func<IndexingOptions, CancellationToken, Task> indexationFunc)
        {
            // Reset progress handler to initial state
            _progressHandler.Start(currentUserName, notificationId, suppressInsignificantNotifications);

            // Capture the syncronization object (cancelation token source) if it is not captured already.
            var cancellationTokenSource = StartIndexation();

            if (cancellationTokenSource == null)
            {
                // Report error and exit
                _progressHandler.AlreadyInProgress();
            }
            else
            {
                // Begin indexation
                try
                {
                    foreach (var options in allOptions)
                    {
                        await indexationFunc(options, cancellationTokenSource.Token);
                    }
                }
                catch (OperationCanceledException)
                {
                    _progressHandler.Cancel();
                }
                catch (Exception ex)
                {
                    _progressHandler.Exception(ex);
                }
                finally
                {
                    // Report indexation summary
                    _progressHandler.Finish();

                    // Release the syncronization object
                    FinishIndexation();
                }
            }
        }

        private async Task IndexAllDocumentsAsync(IndexingOptions options, CancellationToken cancellationToken)
        {
            var oldIndexationDate = GetLastIndexationDate(options.DocumentType);
            var newIndexationDate = DateTime.UtcNow;

            await _indexingManager.IndexAsync(options, _progressHandler.Progress, cancellationToken);

            // Save indexation date to prevent changes from being indexed again
            SetLastIndexationDate(options.DocumentType, oldIndexationDate, newIndexationDate);
        }

        private async Task IndexChangesAsync(IndexingOptions options, CancellationToken cancellationToken)
        {
            var oldIndexationDate = options.StartDate;
            var newIndexationDate = DateTime.UtcNow;

            options.EndDate = oldIndexationDate == null ? null : (DateTime?)newIndexationDate;

            await _indexingManager.IndexAsync(options, _progressHandler.Progress, cancellationToken);

            // Save indexation date. It will be used as a start date for the next indexation
            SetLastIndexationDate(options.DocumentType, oldIndexationDate, newIndexationDate);
        }

        private static CancellationTokenSource StartIndexation()
        {
            CancellationTokenSource result = null;

            lock (_lockObject)
            {
                if (_cancellationTokenSource == null)
                {
                    _cancellationTokenSource = new CancellationTokenSource();
                    result = _cancellationTokenSource;
                }
            }

            return result;
        }

        private static void FinishIndexation()
        {
            lock (_lockObject)
            {
                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Cancel();
                    _cancellationTokenSource = null;
                }
            }
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
