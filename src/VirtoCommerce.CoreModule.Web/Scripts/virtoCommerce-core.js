var moduleName = "virtoCommerce.coreModule";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [
    'virtoCommerce.coreModule.packageType',
    'virtoCommerce.coreModule.currency',
    'virtoCommerce.coreModule.seo',
    'virtoCommerce.coreModule.common'
])
.run(['platformWebApp.metaFormsService', function (metaFormsService) {

    metaFormsService.registerMetaFields('currencyDetail',
        [
            {
                name: 'code',
                title: 'core.blades.currency-detail.labels.code',
                templateUrl: 'currencyDetail-code.html'
            },
            {
                name: 'name',
                title: 'core.blades.currency-detail.labels.name',
                templateUrl: 'currencyDetail-name.html'
            },
            {
                name: 'isPrimary',
                title: 'core.blades.currency-detail.labels.is-primary',
                templateUrl: 'currencyDetail-isPrimary.html'
            },
            {
                name: 'exchangeRate',
                title: 'core.blades.currency-detail.labels.exchange-rate',
                templateUrl: 'currencyDetail-exchangeRate.html'
            },
            {
                name: 'symbol',
                title: 'core.blades.currency-detail.labels.symbol',
                templateUrl: 'currencyDetail-symbol.html'
            },
            {
                name: 'customFormatting',
                title: 'core.blades.currency-detail.labels.custom-formatting',
                templateUrl: 'currencyDetail-customFormatting.html'
            },
            {
                name: 'midpointRounding',
                title: 'core.blades.currency-detail.labels.midpoint-rounding',
                templateUrl: 'currencyDetail-midpointRounding.html'
            },
            {
                name: 'roundingType',
                title: 'core.blades.currency-detail.labels.rounding-type',
                templateUrl: 'currencyDetail-roundingType.html'
            }
        ]);
}]);
