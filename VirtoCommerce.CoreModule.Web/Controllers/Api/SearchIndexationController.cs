using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Hangfire;
using VirtoCommerce.CoreModule.Web.Model;
using VirtoCommerce.CoreModule.Web.Model.PushNotifcations;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.PushNotifications;
using VirtoCommerce.Platform.Core.Security;

namespace VirtoCommerce.CoreModule.Web.Controllers.Api
{
    [RoutePrefix("api/search/indexes")]
    public class SearchIndexationController : ApiController
    {
        private static readonly object _lockObject = new object();
        private static readonly Dictionary<string, CancellationTokenSource> _runningProcesses = new Dictionary<string, CancellationTokenSource>();

        private readonly IndexDocumentConfiguration[] _documentsConfigs;
        private readonly ISearchProvider _searchProvider;
        private readonly IIndexingManager _indexingManager;
        private readonly IUserNameResolver _userNameResolver;
        private readonly IPushNotificationManager _pushNotifier;

        public SearchIndexationController(IndexDocumentConfiguration[] documentsConfigs, ISearchProvider searchProvider, IIndexingManager indexingManager, IUserNameResolver userNameResolver, IPushNotificationManager pushNotifier)
        {
            _documentsConfigs = documentsConfigs;
            _searchProvider = searchProvider;
            _indexingManager = indexingManager;
            _userNameResolver = userNameResolver;
            _pushNotifier = pushNotifier;
        }


        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IndexInfo[]))]
        public async Task<IHttpActionResult> GetAllIndexes()
        {
            var documentTypes = _documentsConfigs.Select(x => x.DocumentType).Distinct().ToList();
            var tasks = documentTypes.Select(GetIndexInfoAsync);
            var result = await Task.WhenAll(tasks);
            return Ok(result);
        }

        /// <summary>
        /// Get search index for specified document type and document id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("index/{documentType}/{documentId}")]
        [ResponseType(typeof(IndexDocument[]))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> GetDocumentIndexAsync(string documentType, string documentId)
        {
            var request = new SearchRequest
            {
                Filter = new IdsFilter
                {
                    Values = new[] { documentId },
                },
            };
            var result = await _searchProvider.SearchAsync(documentType, request);
            return Ok(result.Documents);
        }

        /// <summary>
        /// Index specified document or all documents specified type
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("index/{documentType}")]
        [ResponseType(typeof(IndexProgressPushNotification))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IHttpActionResult> IndexDocuments([FromBody] string[] documentsIds, string documentType)
        {
            var notification = new IndexProgressPushNotification(_userNameResolver.GetCurrentUserName())
            {
                Title = "Indexation process",
                Description = documentType != null ? $"Starting {documentType} indexation" : "Starting full indexation"
            };
            _pushNotifier.Upsert(notification);

            var indexInfo = await GetIndexInfoAsync(documentType);

            var indexingOptions = new IndexingOptions
            {
                BatchSize = 50,
                DocumentIds = documentsIds,
                DocumentType = documentType,
                StartDate = indexInfo.LastIndexationDate
            };

            BackgroundJob.Enqueue(() => BackgroundIndex(indexingOptions, notification));

            return Ok(notification);
        }

        /// <summary>
        /// Reindex specified document or all documents specified type
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("reindex/{documentType?}")]
        [ResponseType(typeof(IndexProgressPushNotification))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult ReindexDocuments([FromBody] string[] documentsIds, string documentType = null)
        {
            var notification = new IndexProgressPushNotification(_userNameResolver.GetCurrentUserName())
            {
                Title = "Reindexation process",
                Description = documentType != null ? "Starting reindex for " + documentType : "Starting full index rebuild"
            };
            _pushNotifier.Upsert(notification);
            var indexingOptions = new IndexingOptions
            {
                BatchSize = 50,
                DocumentIds = documentsIds,
                DocumentType = documentType,
                DeleteExistingIndex = true
            };

            BackgroundJob.Enqueue(() => BackgroundIndex(indexingOptions, notification));

            return Ok(notification);
        }

        [HttpGet]
        [Route("tasks/{taskId}/cancel")]
        public IHttpActionResult CancelIndexationProcess(string taskId)
        {
            lock (_lockObject)
            {
                if (_runningProcesses.ContainsKey(taskId))
                {
                    _runningProcesses[taskId].Cancel();
                }
            }

            return Ok();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        // Only public methods can be invoked in the background. (Hangfire)
        public void BackgroundIndex(IndexingOptions options, IndexProgressPushNotification notification)
        {
            Action<IndexingProgress> progressCallback = x =>
            {
                notification.DocumentType = x.DocumentType;
                notification.Description = x.Description;
                notification.Errors = x.Errors;
                notification.ErrorCount = x.ErrorsCount;
                notification.TotalCount = x.TotalCount ?? 0;
                notification.ProcessedCount = x.ProcessedCount ?? 0;
                _pushNotifier.Upsert(notification);
            };

            var cancellationTokenSource = new CancellationTokenSource();

            lock (_lockObject)
            {
                _runningProcesses[notification.Id] = cancellationTokenSource;
            }

            try
            {
                var cancellationToken = cancellationTokenSource.Token;
                _indexingManager.IndexAsync(options, progressCallback, cancellationToken).Wait(cancellationToken);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                notification.Description = "Index error";
                notification.ErrorCount++;
                notification.Errors.Add(ex.ToString());
            }
            finally
            {
                notification.Finished = DateTime.UtcNow;
                notification.Description = "Indexation finished" + (notification.Errors.Any() ? " with errors" : " successfully");
                _pushNotifier.Upsert(notification);
            }
        }

        private async Task<IndexInfo> GetIndexInfoAsync(string documentType)
        {
            var result = new IndexInfo(documentType);

            var searchRequest = new SearchRequest
            {
                Sorting = new[]
                {
                    new SortingField { FieldName = Constants.IndexationDateFieldName, IsDescending = true }
                },
                Take = 1,
            };

            try
            {
                var searchResponse = await _searchProvider.SearchAsync(documentType, searchRequest);

                result.IndexedDocumentsCount = searchResponse.TotalCount;

                if (searchResponse.Documents?.Any() == true)
                {
                    result.LastIndexationDate = Convert.ToDateTime(searchResponse.Documents[0][Constants.IndexationDateFieldName]);
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }
    }
}
