angular.module('virtoCommerce.coreModule.searchIndex')
.factory('virtoCommerce.coreModule.searchIndex.searchIndexation', ['$resource', function ($resource) {
    return $resource('api/search/indexes', {}, {
        index: { method: 'POST', url: 'api/search/indexes/index/:documentType' },
        reindex: { method: 'POST', url: 'api/search/indexes/reindex/:documentType' },
        cancel: { method: 'GET', url: 'tasks/{taskId}/cancel', params: { taskId: '@taskId'} }
    });
}]);