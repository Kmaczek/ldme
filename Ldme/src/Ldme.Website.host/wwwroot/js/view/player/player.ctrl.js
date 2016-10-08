(function () {
    angular.module('ldme').controller('playerCtrl', ['$scope', 'appState', function ($scope, appState) {
        $scope.isLoggedIn = appState.isLoggedIn();

        function initialize() {
            
        }

        initialize();
    }]);

}())