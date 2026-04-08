// Obsolete-VC0014: Moved to VirtoCommerce.Seo module (virtoCommerce.seo.seoApi)
angular.module('virtoCommerce.coreModule.seo')
.factory('virtoCommerce.coreModule.seoApi', ['$resource', function ($resource) {
    return $resource('api/seoinfos/duplicates', null, {
        batchUpdate: { url: 'api/seoinfos/batchupdate', method: 'PUT' }
    });
}]);