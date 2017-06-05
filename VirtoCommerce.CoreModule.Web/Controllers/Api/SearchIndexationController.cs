using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Hangfire;
using Omu.ValueInjecter;
using VirtoCommerce.CoreModule.Web.Model;
using VirtoCommerce.CoreModule.Web.Model.PushNotifcations;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.PushNotifications;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.CoreModule.Web.Controllers.Api
{
    [RoutePrefix("api/search/indexes")]
    public class SearchIndexationController : ApiController
    {
        private static object _lock = new object();
        private static Dictionary<string, CancellationTokenSource> _runningProcesses;
        private readonly ISearchProvider _indexedSearchProvider;
        private readonly IIndexingManager _indexingManager;
        private readonly IUserNameResolver _userNameResolver;
        private readonly IPushNotificationManager _pushNotifier;
        private readonly IndexDocumentConfiguration[] _documentsConfigs;

        public SearchIndexationController(IndexDocumentConfiguration[] documentsConfigs, ISearchProvider indexedSearchProvider, IIndexingManager indexingManager, IUserNameResolver userNameResolver, IPushNotificationManager pushNotifier)
        {
            _documentsConfigs = documentsConfigs;
            _runningProcesses = new Dictionary<string, CancellationTokenSource>();
            _userNameResolver = userNameResolver;
            _indexedSearchProvider = indexedSearchProvider;
            _indexingManager = indexingManager;
            _pushNotifier = pushNotifier;
        }

  
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IndexInfo[]))]
        public async Task<IHttpActionResult> GetAllAvailIndexes()
        {
            var result = new List<IndexInfo>();
            foreach (var documentType in _documentsConfigs.Select(x => x.DocumentType).Distinct())
            {
                var indexInfo = await GetDocumentTypeIndexInfoAsync(documentType);
                result.Add(indexInfo);
            }
            return Ok(result.ToArray());
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
            var result = await _indexedSearchProvider.SearchAsync(documentType, request);     
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

            var indexInfo = await GetDocumentTypeIndexInfoAsync(documentType);

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
            if(_runningProcesses.ContainsKey(taskId))
            {
                _runningProcesses[taskId].Cancel();
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
            var cancellationToken = new CancellationTokenSource();

            lock (_lock)
            {
                _runningProcesses[notification.Id] = cancellationToken;
            }

            try
            {
                _indexingManager.IndexAsync(options, progressCallback, cancellationToken.Token).Wait();
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

        private async Task<IndexInfo> GetDocumentTypeIndexInfoAsync(string documentType)
        {
            var result = new IndexInfo(documentType);
            var request = new SearchRequest
            {
                Take = 1,
                Sorting = new[]
                        {
                              new SortingField { FieldName = "IndexDate", IsDescending = true },
                            },
            };
            var searchResult = await _indexedSearchProvider.SearchAsync(documentType, request);
            result.IndexedDocsTotal = searchResult.TotalCount;
            if (searchResult.TotalCount > 0)
            {
                result.LastIndexationDate = Convert.ToDateTime(searchResult.Documents[0]["IndexDate"]);
            }

            return result;
        }
    }
}
