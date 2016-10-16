(function () {
    angular.module('ldme').controller('registerCtrl', ['$scope', 'userApi', function ($scope, userApi) {

        $scope.register = function() {
            if ($scope.password === $scope.passwordRepeat) {
                userApi.Register($scope.email, $scope.password);
            } else {
                // sth
            }

        };
    }]);

}());