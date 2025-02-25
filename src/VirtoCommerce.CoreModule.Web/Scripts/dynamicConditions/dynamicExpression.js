angular.module('virtoCommerce.coreModule.common')
    .run(
        ['$http', '$compile', 'virtoCommerce.coreModule.common.dynamicExpressionService', function ($http, $compile, dynamicExpressionService) {
            const browseBehavior = 'Browse behavior';
            const shopperProfile = 'Shopper profile';
            const location = 'Location';

            //Register COMMON expressions
            dynamicExpressionService.registerExpression({
                groupName: browseBehavior,
                id: 'ConditionStoreSearchedPhrase',
                displayName: 'Shopper searched for ... in the store'
            });
            dynamicExpressionService.registerExpression({
                groupName: browseBehavior,
                id: 'ConditionLanguageIs',
                displayName: 'User language is set to...'
            });

            dynamicExpressionService.registerExpression({
                groupName: shopperProfile,
                id: 'ConditionAgeIs',
                displayName: 'Shopper age is ...'
            });
            dynamicExpressionService.registerExpression({
                groupName: shopperProfile,
                id: 'ConditionGenderIs',
                displayName: 'Shopper gender is ...'
            });
            dynamicExpressionService.registerExpression({
                groupName: shopperProfile,
                id: 'UserGroupIsCondition',
                displayName: 'User group is ...',
            });
            dynamicExpressionService.registerExpression({
                groupName: shopperProfile,
                id: 'UserGroupsContainsCondition',
                displayName: 'User group contains ...',
            });

            dynamicExpressionService.registerExpression({
                groupName: location,
                id: 'ConditionGeoTimeZone',
                displayName: 'Time zone'
            });
            dynamicExpressionService.registerExpression({
                groupName: location,
                id: 'ConditionGeoZipCode',
                displayName: 'Zip/postal code'
            });
            dynamicExpressionService.registerExpression({
                groupName: location,
                id: 'ConditionGeoCity',
                displayName: 'City'
            });
            dynamicExpressionService.registerExpression({
                groupName: location,
                id: 'ConditionGeoCountry',
                displayName: 'Country'
            });
            dynamicExpressionService.registerExpression({
                groupName: location,
                id: 'ConditionGeoState',
                displayName: 'Region/state/province'
            });

            //Register PRICELIST ASSIGNMENT expressions
            dynamicExpressionService.registerExpression({
                id: 'BlockPricingCondition',
                newChildLabel: 'Add condition'
            });

            $http.get('Modules/$(VirtoCommerce.Core)/Scripts/dynamicConditions/all-templates.html').then(function (response) {
                // compile the response, which will put stuff into the cache
                $compile(response.data);
            });
        }])
    .controller('virtoCommerce.dynamicExpressions.conditionLanguageIsController', ['$scope', 'platformWebApp.settings', function ($scope, settings) {
        $scope.availableLanguages = settings.getValues({ id: 'VirtoCommerce.Core.General.Languages' });
    }])
    .controller('virtoCommerce.dynamicExpressions.conditionGeoCountryController', ['$scope', 'platformWebApp.common.countries', function ($scope, countries) {
        $scope.countries = countries.query();
    }])
    .controller('virtoCommerce.dynamicExpressions.conditionGeoTimeZoneController', ['$scope', 'platformWebApp.common.timeZones', function ($scope, timeZones) {
        $scope.timeZones = timeZones.query();
    }])
    .controller('virtoCommerce.dynamicExpressions.conditionUserGroupsController', ['$scope', 'platformWebApp.settings', function ($scope, settings) {
        $scope.groups = settings.getValues({ id: 'Customer.MemberGroups' });
    }])
    .controller('virtoCommerce.dynamicExpressions.shippingMethodRewardController', ['$scope', function ($scope) {
        function initialize(storeIds) {
            //Use stores ($scope.stores) from parent controller virtoCommerce.marketingModule.promotionDetailController
            let selectedStores = _.filter($scope.stores, function (x) { return (storeIds && storeIds.length > 0) ? storeIds.indexOf(x.id) >= 0 : true });
            $scope.shippingMethods = _.uniq(_.flatten(_.pluck(selectedStores, 'shippingMethods')), function (x) { return x.code; });
            if ($scope.shippingMethods.length === 0) {
                $scope.shippingMethods = [{ code: 'No methods found' }];
            }
        }
        $scope.$watch('stores', function () { initialize($scope.blade.currentEntity.storeIds); }, true);
        $scope.$watch('blade.currentEntity.storeIds', initialize);
    }])
    .controller('virtoCommerce.dynamicExpressions.paymentMethodRewardController', ['$scope', function ($scope) {
        function initialize(storeIds) {
            //Use stores ($scope.stores) from parent controller virtoCommerce.marketingModule.promotionDetailController
            let selectedStores = _.filter($scope.stores, function (x) { return (storeIds && storeIds.length > 0) ? storeIds.indexOf(x.id) >= 0 : true });
            $scope.paymentMethods = _.uniq(_.flatten(_.pluck(selectedStores, 'paymentMethods')), function (x) { return x.code; });
            if ($scope.paymentMethods.length === 0) {
                $scope.paymentMethods = [{ code: 'No methods found' }];
            }
        }
        $scope.$watch('stores', function () { initialize($scope.blade.currentEntity.storeIds); }, true);
        $scope.$watch('blade.currentEntity.storeIds', initialize);
    }])
    .filter('compareConditionToText', function () {
        return function (input) {
            var retVal;

            switch (input) {
                case 'IsMatching': retVal = 'exactly'; break;
                case 'IsNotMatching': retVal = 'anything but'; break;
                case 'IsGreaterThan': retVal = 'greater than'; break;
                case 'IsGreaterThanOrEqual': retVal = 'greater than or equals'; break;
                case 'IsLessThan': retVal = 'less than'; break;
                case 'IsLessThanOrEqual': retVal = 'less than or equals'; break;
                case 'Contains': retVal = 'containing'; break;
                case 'NotContains': retVal = 'not containing'; break;
                case 'Matching': retVal = 'exactly'; break;
                case 'NotMatching': retVal = 'anything but'; break;
                case 'Exactly': retVal = 'exactly'; break;
                case 'AtLeast': retVal = 'at least'; break;
                case 'Between': retVal = 'between'; break;
                default:
                    retVal = input;
            }
            return retVal;
        };
    });
