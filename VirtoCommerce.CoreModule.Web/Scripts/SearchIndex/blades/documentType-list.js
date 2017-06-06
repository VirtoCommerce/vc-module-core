angular.module('virtoCommerce.coreModule.searchIndex')
.controller('virtoCommerce.coreModule.searchIndex.documentTypeListController', ['$scope', 'platformWebApp.bladeNavigationService', 'platformWebApp.dialogService', 'platformWebApp.bladeUtils', 'virtoCommerce.coreModule.searchIndex.searchIndexation',
    function($scope, bladeNavigationService, dialogService, bladeUtils, searchIndexationApi) {
        var blade = $scope.blade;
        blade.isLoading = false;

        blade.refresh = function () {
            blade.isLoading = true;
            searchIndexationApi.get(function (response) {
                blade.currentEntities = response.results;
                $scope.pageSettings.totalItems = response.length;
                blade.isLoading = false;
            });
        }

        $scope.rebuildIndex = function(documentTypes) {
            var dialog = {
                id: "confirmRebuildIndex",
                callback: function (doReindex) {
                    var apiToCall = doReindex ? searchIndexationApi.reindex : searchIndexationApi.index;
                    apiToCall({ documentType: documentTypes }, null,
                        function openProgressBlade(data) {
                            // show indexing progress
                            var newBlade = {
                                id: 'indexProgress',
                                notification: data,
                                parentRefresh: blade.parentRefresh,
                                controller: 'virtoCommerce.searchModule.indexProgressController',
                                template: 'Modules/$(VirtoCommerce.Core)/Scripts/SearchIndex/blades/index-progress.tpl.html'
                            };
                            bladeNavigationService.showBlade(newBlade, blade.parentBlade || blade);
                        });
                }
            }
            dialogService.showDialog(dialog, 'Modules/$(VirtoCommerce.Core)/Scripts/SearchIndex/dialogs/reindex-dialog.tpl.html', 'platformWebApp.confirmDialogController');
        }

        blade.toolbarCommands = [{
            name: 'platform.commands.refresh',
            icon: 'fa fa-refresh',
            canExecuteMethod: function () {
                return true;
            },
            executeMethod: function () {
                blade.refresh();
            }
        }, {
            name: 'core.commands.rebuild-index',
            icon: 'fa fa-recycle',
            canExecuteMethod: function () {
                return $scope.gridApi && _.any($scope.gridApi.selection.getSelectedRows());
            },
            executeMethod: function () {
                $scope.rebuildIndex($scope.gridApi.selection.getSelectedRows());
            },
            permission: 'VirtoCommerce.Search:Index:Rebuild'
        }];

        $scope.setGridOptions = function (gridOptions) {
            $scope.gridOptions = gridOptions;
            gridOptions.onRegisterApi = function (gridApi) {
                gridApi.core.on.sortChanged($scope, function () {
                    if (!blade.isLoading) blade.refresh();
                });
            };
            bladeUtils.initializePagination($scope);
        };
    }
]);