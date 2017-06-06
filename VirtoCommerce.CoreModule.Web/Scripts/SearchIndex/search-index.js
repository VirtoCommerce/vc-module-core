angular.module("virtoCommerce.coreModule.searchIndex", [])
.config(['$stateProvider', function ($stateProvider) {
    $stateProvider.state('workspace.searchIndexModule', {
        url: '/searchIndex',
        controller: ['$scope', 'platformWebApp.bladeNavigationService', function ($scope, bladeNavigationService) {
            var blade = {
                id: 'searchIndex',
                title: 'core.blades.document-type-list.title',
                headIcon: 'fa fa-search',
                controller: 'virtoCommerce.coreModule.searchIndex.documentTypeListController',
                template: 'Modules/$(VirtoCommerce.Core)/Scripts/SearchIndex/blades/documentType-list.tpl.html',
                isClosingDisabled: true
            };
            bladeNavigationService.showBlade(blade);
            $scope.moduleName = 'vc-core vc-search-index';
        }],
        templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html'
    });
}])
.run(['$rootScope', 'platformWebApp.mainMenuService', 'platformWebApp.widgetService', '$state', function ($rootScope, mainMenuService, widgetService, $state) {
        mainMenuService.addMenuItem({
            path: 'browse/searchIndex',
            icon: 'fa fa-search',
            title: 'core.main-menu-title.search-index',
            priority: 25,
            action: function () {
                $state.go('workspace.searchIndexModule');
            }
        });
    }
]);