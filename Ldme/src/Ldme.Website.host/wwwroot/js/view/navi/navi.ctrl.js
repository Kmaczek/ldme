(function () {
    angular.module('ldme').controller('naviCtrl', ['$scope', 'userApi', function ($scope, userApi) {
        $scope.hello = "Yo man!";
        $scope.login = function() {
            userApi.Login($scope.email, $scope.password);
        }
    }]);

}())