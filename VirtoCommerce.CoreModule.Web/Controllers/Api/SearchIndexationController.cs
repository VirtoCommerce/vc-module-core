using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Hangfire;
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

        private readonly IndexDocumentConfiguration[] _documentConfigs;
        private readonly ISearchProvider _searchProvider;
        private readonly IIndexingManager _indexingManager;
        private readonly IUserNameResolver _userNameResolver;
        private readonly IPushNotificationManager _pushNotifier;

        public SearchIndexationController(IndexDocumentConfiguration[] documentConfigs, ISearchProvider searchProvider, IIndexingManager indexingManager, IUserNameResolver userNameResolver, IPushNotificationManager pushNotifier)
        {
            _documentConfigs = documentConfigs;
            _searchProvider = searchProvider;
            _indexingManager = indexingManager;
            _userNameResolver = userNameResolver;
            _pushNotifier = pushNotifier;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IndexState[]))]
        public async Task<IHttpActionResult> GetAllIndexes()
        {
            var documentTypes = _documentConfigs.Select(c => c.DocumentType).Distinct().ToList();
            var result = await Task.WhenAll(documentTypes.Select(_indexingManager.GetIndexStateAsync));
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
        /// Rund indexation process for specified options
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("index")]
        [ResponseType(typeof(IndexProgressPushNotification))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult IndexDocuments([FromBody] IndexingOptions[] options)
        {
            var notification = new IndexProgressPushNotification(_userNameResolver.GetCurrentUserName())
            {
                Title = "Indexation process",
                Description = "Starting indexation..."
            };

            _pushNotifier.Upsert(notification);

            BackgroundJob.Enqueue(() => BackgroundIndex(options, notification));

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
        public void BackgroundIndex(IndexingOptions[] options, IndexProgressPushNotification notification)
        {
            var totalCountMap = new Dictionary<string, long>();
            var processedCountMap = new Dictionary<string, long>();

            Action<IndexingProgress> progressCallback = x =>
            {
                notification.DocumentType = x.DocumentType;
                notification.Description = x.Description;
                notification.Errors = x.Errors ?? notification.Errors;
                notification.ErrorCount = x.ErrorsCount;
                notification.TotalCount = x.TotalCount ?? 0;
                notification.ProcessedCount = x.ProcessedCount ?? 0;
                totalCountMap[x.DocumentType] = x.TotalCount ?? 0;
                processedCountMap[x.DocumentType] = x.ProcessedCount ?? 0;
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
                foreach (var option in options)
                {
                    _indexingManager.IndexAsync(option, progressCallback, cancellationToken).Wait(cancellationToken);
                }
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
                notification.TotalCount = totalCountMap.Values.Sum();
                notification.ProcessedCount = processedCountMap.Values.Sum();
                notification.Description = "Indexation finished" + (notification.Errors?.Any() == true ? " with errors" : " successfully");
                _pushNotifier.Upsert(notification);
            }
        }
    }
}
