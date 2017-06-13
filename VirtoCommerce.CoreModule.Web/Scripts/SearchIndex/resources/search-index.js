angular.module('virtoCommerce.coreModule.searchIndex')
.factory('virtoCommerce.coreModule.searchIndex.searchIndexation', ['$resource', function ($resource) {
    return $resource('api/search/indexes', {}, {
        get: { method: 'GET', isArray: true },
        index: { method: 'POST', url: 'api/search/indexes/index' },       
        cancel: { method: 'GET', url: 'tasks/{taskId}/cancel', params: { taskId: '@taskId'} }
    });
}]);