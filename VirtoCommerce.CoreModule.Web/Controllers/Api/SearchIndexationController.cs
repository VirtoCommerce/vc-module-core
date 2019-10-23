using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.CoreModule.Data.Indexing.BackgroundJobs;
using VirtoCommerce.CoreModule.Web.Security;
using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.PushNotifications;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Web.Security;

namespace VirtoCommerce.CoreModule.Web.Controllers.Api
{
    [RoutePrefix("api/search/indexes")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SearchIndexationController : ApiController
    {
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
        [CheckPermission(Permission = CommercePredefinedPermissions.IndexRebuild)]
        public IHttpActionResult IndexDocuments([FromBody] IndexingOptions[] options)
        {
            var currentUserName = _userNameResolver.GetCurrentUserName();
            var notification = IndexingJobs.Enqueue(currentUserName, options);
            _pushNotifier.Upsert(notification);
            return Ok(notification);
        }


        [HttpGet]
        [Route("tasks/{taskId}/cancel")]
        public IHttpActionResult CancelIndexationProcess(string taskId)
        {
            IndexingJobs.CancelIndexation();
            return Ok();
        }
    }
}
