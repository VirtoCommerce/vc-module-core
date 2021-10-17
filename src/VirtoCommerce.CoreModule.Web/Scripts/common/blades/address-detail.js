angular.module('virtoCommerce.coreModule.common')
    .controller('virtoCommerce.coreModule.common.coreAddressDetailController', ['$scope', '$filter', 'platformWebApp.common.countries', 'platformWebApp.dialogService', 'platformWebApp.metaFormsService', 'platformWebApp.bladeNavigationService', function ($scope, $filter, countries, dialogService, metaFormsService, bladeNavigationService) {
        var blade = $scope.blade;

        blade.addressTypes = ['Billing', 'Shipping', 'BillingAndShipping'];
        blade.metaFields = blade.metaFields && blade.metaFields.length ? blade.metaFields : metaFormsService.getMetaFields('addressDetails');
        if (blade.currentEntity.isNew) {
            blade.currentEntity.addressType = blade.addressTypes[1];
        }
        blade.origEntity = blade.currentEntity;
        blade.currentEntity = angular.copy(blade.origEntity);
        blade.countries = countries.query();
        blade.countries.$promise.then(
            (allCountries) => {
                $scope.$watch('blade.currentEntity.countryCode', (countryCode, old) => {
                    if (countryCode) {
                        var country = _.findWhere(allCountries, { id: countryCode });
                        if (country) {
                            blade.currentEntity.countryName = country.name;

                            if (countryCode !== old) {
                                blade.currentEntity.regionName = undefined;
                                currentRegions = [];
                            }

                            if (country.regions) {
                                currentRegions = country.regions;
                            } else {
                                countries.queryRegions(countryCode).$promise.then((regions) => {
                                    country.regions = regions;
                                    currentRegions.push(...regions);
                                });
                            }
                        }
                    }
                });
            }
        );

        var currentRegions = [];
        if (blade.currentEntity.regionName && !blade.currentEntity.regionId) {
            addRegion(currentRegions, blade.currentEntity.regionName);
        }

        blade.getRegions = function (search) {
            var results = currentRegions;
            if (search && search.length > 1) {
                var filtered = $filter('filter')(results, search);
                if (!_.some(filtered)) {
                    addRegion(results, search);
                } else if (filtered.length > 1) { // remove other (added) records
                    filtered = _.filter(filtered, (x) => !x.id && x.displayName.length > search.length);
                    for (var x of filtered) {
                        results.splice(_.indexOf(results, x), 1);
                    }
                }
            }

            return results;
        };

        function addRegion(regions, name) {
            regions.unshift({ name: name, displayName: name });
        }

        $scope.$watch('blade.currentEntity.regionName', function (regionName, old) {
            if (regionName === old) return;

            var newId = null;
            if (regionName) {
                var region = _.findWhere(currentRegions, { name: regionName });
                if (region) {
                    newId = region.id;
                }
            }

            blade.currentEntity.regionId = newId;
        });

        blade.toolbarCommands = [{
            name: "platform.commands.reset", icon: 'fa fa-undo',
            executeMethod: function () {
                angular.copy(blade.origEntity, blade.currentEntity);
            },
            canExecuteMethod: isDirty
        }, {
            name: "platform.commands.delete", icon: 'fas fa-trash-alt',
            executeMethod: deleteEntry,
            canExecuteMethod: function () {
                return !blade.currentEntity.isNew;
            }
        }];

        blade.isLoading = false;

        blade.onClose = function (closeCallback) {
            bladeNavigationService.showConfirmationIfNeeded(isDirty(), canSave(), blade, $scope.saveChanges, closeCallback, "core.dialogs.address-save.title", "core.dialogs.address-save.message");
        };

        $scope.setForm = function (form) {
            $scope.formScope = form;
        };

        $scope.isValid = function () {
            return $scope.formScope && $scope.formScope.$valid;
        };

        $scope.cancelChanges = function () {
            $scope.bladeClose();
        };

        $scope.saveChanges = function () {
            if (blade.confirmChangesFn) {
                blade.confirmChangesFn(blade.currentEntity);
            }
            angular.copy(blade.currentEntity, blade.origEntity);
            $scope.bladeClose();
        };

        function isDirty() {
            return !angular.equals(blade.currentEntity, blade.origEntity);
        }

        function canSave() {
            return isDirty();
        }

        function deleteEntry() {
            var dialog = {
                id: "confirmDelete",
                title: "core.dialogs.address-delete.title",
                message: "core.dialogs.address-delete.message",
                callback: function (remove) {
                    if (remove) {
                        if (blade.deleteFn) {
                            blade.deleteFn(blade.currentEntity);
                        }
                        $scope.bladeClose();
                    }
                }
            }
            dialogService.showConfirmationDialog(dialog);
        }
    }]);
