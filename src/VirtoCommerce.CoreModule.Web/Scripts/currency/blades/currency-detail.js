angular.module('virtoCommerce.coreModule.currency')
    .controller('virtoCommerce.coreModule.currency.currencyDetailController', [
        '$scope',
        'platformWebApp.dialogService',
        'platformWebApp.bladeNavigationService',
        'virtoCommerce.coreModule.currency.currencyApi',
        'platformWebApp.metaFormsService',
        function ($scope, dialogService, bladeNavigationService, currencyApi, metaFormsService) {
        var blade = $scope.blade;
        blade.updatePermission = 'core:currency:update';

        blade.metafields = blade.metafields ? blade.metafields : metaFormsService.getMetaFields('currencyDetail');

        $scope.saveChanges = function () {
            blade.isLoading = true;

            if (blade.isNew) {
                currencyApi.save(blade.currentEntity, function () {
                    angular.copy(blade.currentEntity, blade.origEntity);
                    $scope.bladeClose();
                    blade.parentBlade.setSelectedId(blade.currentEntity.code);
                    blade.parentBlade.refresh(true);
                }, function (error) {
                    bladeNavigationService.setError('Error: ' + error.status, blade);
                });
            } else {
                currencyApi.update(blade.currentEntity, function (data) {
                    angular.copy(blade.currentEntity, blade.origEntity);
                    $scope.bladeClose();
                    blade.parentBlade.setSelectedId(blade.currentEntity.code);
                    blade.parentBlade.refresh(true);
                }, function (error) {
                    bladeNavigationService.setError('Error: ' + error.status, blade);
                });
            }
        };

        function initializeBlade(data) {
            if (blade.isNew) data = { exchangeRate: 1.00 };

            blade.currentEntity = angular.copy(data);
            blade.origEntity = data;
            blade.isLoading = false;

            blade.title = blade.isNew ? 'core.blades.currency-detail.new-title' : data.name;
            blade.subtitle = blade.isNew ? 'core.blades.currency-detail.new-subtitle' : 'core.blades.currency-detail.subtitle';
        }

        var formScope;
        $scope.setForm = function (form) {
            formScope = form;
        }

        function isDirty() {
            return !angular.equals(blade.currentEntity, blade.origEntity) && blade.hasUpdatePermission();
        }

        function canSave() {
            return isDirty() && formScope && formScope.$valid;
        }

        blade.headIcon = 'fa fa-money';

        if (!blade.isNew)
            blade.toolbarCommands = [
                {
                    name: "platform.commands.save", icon: 'fas fa-save',
                    executeMethod: $scope.saveChanges,
                    canExecuteMethod: canSave,
                    permission: blade.updatePermission
                },
                {
                    name: "platform.commands.reset", icon: 'fa fa-undo',
                    executeMethod: function () {
                        angular.copy(blade.origEntity, blade.currentEntity);
                    },
                    canExecuteMethod: isDirty,
                    permission: blade.updatePermission
                },
                {
                    name: "platform.commands.delete", icon: 'fas fa-trash-alt',
                    executeMethod: deleteEntry,
                    canExecuteMethod: function () {
                        return !blade.origEntity.isPrimary;
                    },
                    permission: 'core:currency:delete'
                }
            ];

        function deleteEntry() {
            var dialog = {
                id: "confirmDelete",
                title: "core.dialogs.currency-delete.title",
                message: "core.dialogs.currency-delete.message",
                callback: function (remove) {
                    if (remove) {
                        blade.isLoading = true;

                        currencyApi.remove({ codes: blade.currentEntity.code }, function () {
                            angular.copy(blade.currentEntity, blade.origEntity);
                            $scope.bladeClose();
                            blade.parentBlade.setSelectedId(null);
                            blade.parentBlade.refresh(true);
                        }, function (error) {
                            bladeNavigationService.setError('Error ' + error.status, blade);
                        });
                    }
                }
            }
            dialogService.showConfirmationDialog(dialog);
        }

        blade.onClose = function (closeCallback) {
            bladeNavigationService.showConfirmationIfNeeded(isDirty(), canSave(), blade, $scope.saveChanges, closeCallback, "core.dialogs.currency-save.title", "core.dialogs.currency-save.message");
        };

        // actions on load        
        initializeBlade(blade.data);
    }]);
