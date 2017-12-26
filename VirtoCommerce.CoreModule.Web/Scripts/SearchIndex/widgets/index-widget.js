angular.module('virtoCommerce.coreModule.searchIndex')
.controller('virtoCommerce.coreModule.searchIndex.indexWidgetController', ['$scope', 'platformWebApp.bladeNavigationService', 'virtoCommerce.coreModule.searchIndex.searchIndexation', function ($scope, bladeNavigationService, searchApi) {
    var blade = $scope.blade;
    $scope.loading = true;

    function refresh() {
        searchApi.getDocIndex({ documentType: $scope.widget.documentType, documentId: blade.currentEntity.id }, function (data) {
            if (_.any(data)) {
                $scope.index = data[0];
                $scope.indexDate = moment.utc($scope.index.indexationdate, 'YYYYMMDDHHmmss');
            }

            $scope.loading = false;
            updateStatus();
        });
    }

    function updateStatus() {
        if (!$scope.loading && blade.currentEntity) {
            $scope.widget.UIclass = !$scope.index || ($scope.indexDate < moment.utc(blade.currentEntity.modifiedDate)) ? 'error' : '';
        }
    }

    $scope.openBlade = function () {
        var newBlade = {
            id: 'detailChild',
            currentEntityId: blade.currentEntity.id,
            currentEntity: blade.currentEntity,
            data: $scope.index,
            indexDate: $scope.indexDate,
            documentType: $scope.widget.documentType,
            parentRefresh: refresh,         
            controller: 'virtoCommerce.coreModule.searchIndex.indexDetailController',
            template: 'Modules/$(VirtoCommerce.Core)/Scripts/SearchIndex/blades/index-detail.tpl.html'
        };       
        bladeNavigationService.showBlade(newBlade, blade);
    };

    $scope.$watch('blade.currentEntity', updateStatus);

    refresh();
}]);
