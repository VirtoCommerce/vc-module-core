angular.module('virtoCommerce.coreModule.common')
    .run(
        ['$http', '$compile', 'virtoCommerce.coreModule.common.dynamicExpressionService', function ($http, $compile, dynamicExpressionService) {

            //Register PROMOTION expressions
            dynamicExpressionService.registerExpression({
                id: 'BlockCustomerCondition',
                newChildLabel: 'Add user group',
                getValidationError: function () {
                    return (this.children && this.children.length) ? undefined : 'Your promotion must have at least one eligibility criterion';
                }
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionIsEveryone',
                displayName: 'Everyone'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionIsFirstTimeBuyer',
                displayName: 'First time customers'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionIsRegisteredUser',
                displayName: 'Registered users'
            });
            dynamicExpressionService.registerExpression({
                id: 'UserGroupsContainsCondition',
                displayName: 'User group contains...'
            });

            var availableExcludings = [
                {
                    id: 'ExcludingCategoryCondition'
                },
                {
                    id: 'ExcludingProductCondition'
                }
            ];
            dynamicExpressionService.registerExpression({
                id: 'ExcludingCategoryCondition',
                displayName: 'Items from a specific category'
            });
            dynamicExpressionService.registerExpression({
                id: 'ExcludingProductCondition',
                displayName: 'Product items'
            });

            dynamicExpressionService.registerExpression({
                id: 'BlockCatalogCondition',
                newChildLabel: 'Add condition'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionEntryIs',
                // templateURL: 'expression-ConditionEntryIs.html',
                // controller: 'conditionEntryIsController'
                displayName: 'Specific product'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCurrencyIs',
                displayName: 'Currency is...'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCodeContains',
                displayName: 'Product code contains...'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCategoryIs',
                displayName: 'Specific category',
                availableChildren: availableExcludings,
                newChildLabel: 'Excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionInStockQuantity',
                displayName: 'In stock quantity is...'
            });

            dynamicExpressionService.registerExpression({
                id: 'BlockCartCondition',
                newChildLabel: 'Add condition'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionCartSubtotalLeast',
                displayName: 'Cart subtotal is...',
                availableChildren: availableExcludings,
                newChildLabel: 'Excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionAtNumItemsInCart',
                displayName: 'Number of items in the shopping cart',
                availableChildren: availableExcludings,
                newChildLabel: 'Excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionAtNumItemsInCategoryAreInCart',
                displayName: 'Number of items out of a category in the shopping cart',
                availableChildren: availableExcludings,
                newChildLabel: 'Excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'ConditionAtNumItemsOfEntryAreInCart',
                displayName: 'Number of specific product items in the shopping cart'
            });
            dynamicExpressionService.registerExpression({
                id: 'BlockReward',
                newChildLabel: 'Add reward',
                getValidationError: function () {
                    return (this.children && this.children.length) ? undefined : 'Your promotion must have at least one reward';
                }
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardCartGetOfAbsSubtotal',
                displayName: '$... off cart subtotal'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardCartGetOfRelSubtotal',
                displayName: '...% off cart subtotal, no more than $...'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetFreeNumItemOfProduct',
                displayName: '... free items of ... product'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGiftNumItem',
                displayName: '... items of ... product as a gift'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfAbs',
                displayName: '$... off'
            });

            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfRel',
                displayName: '...% off for product ..., no more than $...'
            });

            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfAbsForNum',
                displayName: '$... off for ... specific product items'
                //availableChildren: availableExcludings,
                //newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemGetOfRelForNum',
                displayName: '...% off for ... specific product items, no more than $...'
                //availableChildren: availableExcludings,
                //newChildLabel: '+ excluding'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardShippingGetOfAbsShippingMethod',
                displayName: '$... off for shipping at ...'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardShippingGetOfRelShippingMethod',
                displayName: '% off for shipping at ..., no more than $...'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardPaymentGetOfAbs',
                displayName: '$... off for using ... payment method'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardPaymentGetOfRel',
                displayName: '...% off for using ... payment method, no more than $...'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemForEveryNumInGetOfRel',
                displayName: '...% off for ... of every ... specific product items'
            });
            dynamicExpressionService.registerExpression({
                id: 'RewardItemForEveryNumOtherItemInGetOfRel',
                displayName: '...% off for ... items of a specific product per every ... items of another product'
            });

            //Register COMMON expressions
            var groupNames = ['Browse behavior', 'Shopper profile', 'Shopping cart', 'Location'];
            dynamicExpressionService.registerExpression({
                groupName: groupNames[0],
                id: 'ConditionStoreSearchedPhrase',
                displayName: 'Shopper searched for ... in the store'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[0],
                id: 'ConditionLanguageIs',
                displayName: 'User language is set to...'
            });

            dynamicExpressionService.registerExpression({
                groupName: groupNames[1],
                id: 'ConditionAgeIs',
                displayName: 'Shopper age is ...'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[1],
                id: 'ConditionGenderIs',
                displayName: 'Shopper gender is ...'
            });

            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoTimeZone',
                displayName: 'Time zone'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoZipCode',
                displayName: 'Zip/postal code'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoCity',
                displayName: 'City'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoCountry',
                displayName: 'Country'
            });
            dynamicExpressionService.registerExpression({
                groupName: groupNames[3],
                id: 'ConditionGeoState',
                displayName: 'State/province'
            });

            //Register CONTENT PUBLISHING expressions
            dynamicExpressionService.registerExpression({
                id: 'BlockContentCondition',
                newChildLabel: 'Add condition'
            });

            //Register PRICELIST ASSIGNMENT expressions
            dynamicExpressionService.registerExpression({
                id: 'BlockPricingCondition',
                newChildLabel: 'Add condition'
            });

            dynamicExpressionService.registerExpression({
                groupName: groupNames[1],
                id: 'UserGroupsContainsCondition',
                displayName: 'User group contains ...'
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
