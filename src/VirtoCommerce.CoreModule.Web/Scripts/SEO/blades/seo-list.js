angular.module('virtoCommerce.coreModule.seo')
.controller('virtoCommerce.coreModule.seo.seoListController', ['$scope', 'platformWebApp.uiGridHelper', 'virtoCommerce.storeModule.stores', 'platformWebApp.bladeNavigationService', 'platformWebApp.dialogService', function ($scope, uiGridHelper, stores, bladeNavigationService, dialogService) {
    var blade = $scope.blade;
    $scope.selectedNodeId = null; // need to initialize to null

    var storesPromise = blade.fixedStoreId ? null : stores.query().$promise;

    blade.refresh = function (seoContainerObject) {
        if (seoContainerObject) {
            blade.seoContainerObject = seoContainerObject;
            blade.currentEntities = blade.seoContainerObject.seoInfos;
        }
    };

    $scope.resolveDuplicates = function () {
        var newBlade = {
            id: 'seoDuplicates',
            duplicates: blade.duplicates,
            objectType: blade.objectType,
            seoContainerObject: blade.seoContainerObject,
            defaultContainerId: blade.defaultContainerId,
            languages: blade.languages,
            controller: 'virtoCommerce.coreModule.seo.seoDuplicatesController',
            template: 'Modules/$(VirtoCommerce.Core)/Scripts/SEO/blades/seo-duplicates.tpl.html'
        };

        if (blade.fixedStoreId) {
            newBlade.stores = [blade.seoContainerObject];
            bladeNavigationService.showBlade(newBlade, blade);
        } else {
            storesPromise.then(function (promiseData) {
                newBlade.stores = promiseData;
                bladeNavigationService.showBlade(newBlade, blade);
            });
        }
    };

    blade.selectNode = openDetailsBlade;

    function openDetailsBlade(node, isNew) {
        $scope.selectedNodeId = node.id;

        var newBlade = {
            id: 'seoDetails',
            data: node,
            isNew: isNew,
            seoContainerObject: blade.seoContainerObject,
            languages: blade.languages,
            updatePermission: blade.updatePermission,
            controller: 'virtoCommerce.coreModule.seo.seoDetailController',
            template: 'Modules/$(VirtoCommerce.Core)/Scripts/SEO/blades/seo-detail.tpl.html'
        };

        if (blade.fixedStoreId) {
            newBlade.fixedStoreId = blade.fixedStoreId;
            bladeNavigationService.showBlade(newBlade, blade);
        } else {
            storesPromise.then(function (promiseData) {
                newBlade.stores = promiseData;
                bladeNavigationService.showBlade(newBlade, blade);
            });
        }
    }

    $scope.delete = function (data) {
        deleteList([data]);
    };

    function deleteList(selection) {
        var dialog = {
            id: "confirmDelete",
            title: "platform.dialogs.delete.title",
            message: "platform.dialogs.delete.message",
            callback: function (remove) {
                if (remove) {
                    bladeNavigationService.closeChildrenBlades(blade, function () {
                        _.each(selection, function (x) {
                            blade.seoContainerObject.seoInfos.splice(blade.seoContainerObject.seoInfos.indexOf(x), 1);
                        });
                    });
                }
            }
        };
        dialogService.showConfirmationDialog(dialog);
    }

    blade.toolbarCommands = [
      {
          name: "platform.commands.add", icon: 'fas fa-plus',
          executeMethod: function () {
              bladeNavigationService.closeChildrenBlades(blade, function () {
                  openDetailsBlade({ isActive: true }, true);
              });
          },
          canExecuteMethod: function () { return true; },
          permission: blade.updatePermission
      },
      {
          name: "platform.commands.delete", icon: 'fas fa-trash-alt',
          executeMethod: function () { deleteList($scope.gridApi.selection.getSelectedRows()); },
          canExecuteMethod: function () {
              return $scope.gridApi && _.any($scope.gridApi.selection.getSelectedRows()) && _.any(blade.seoContainerObject.seoInfos);
          },
          permission: blade.updatePermission
      }
    ];

    // ui-grid
    $scope.setGridOptions = function (gridOptions) {
        uiGridHelper.initialize($scope, gridOptions);
    };

    blade.headIcon = 'fa fa-globe';
    blade.subtitle = 'core.blades.seo-list.subtitle';

    blade.refresh(blade.seoContainerObject);
    blade.isLoading = false;
}]);
