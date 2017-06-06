angular.module('virtoCommerce.searchModule')
.controller('virtoCommerce.searchModule.indexProgressController', ['$scope', 'virtoCommerce.coreModule.searchIndex.searchIndexation', function ($scope, searchIndexationApi) {
    var blade = $scope.blade;

    $scope.$on("new-notification-event", function (event, notification) {
        if (blade.notification && notification.id == blade.notification.id) {
            angular.copy(notification, blade.notification);
            if (notification.finished && blade.parentRefresh) {
                blade.parentRefresh();
            }
        }
    });

    blade.toolbarCommands = [{
        name: 'platform.commands.cancel',
        icon: 'fa fa-cancel',
        canExecuteMethod: function() {
            return true;
        },
        executeMethod: function() {
            searchIndexationApi.cancel({ taskId: blade.notification.id });
        }
    }];

    blade.title = blade.notification.title;
    blade.headIcon = 'fa-search';
    blade.isLoading = false;
}]);