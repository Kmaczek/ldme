(function () {
    angular.module('ldme').controller('registerCtrl', function ($scope, userApi, toastr, $state) {

        $scope.register = function() {
            if ($scope.password === $scope.passwordRepeat) {
                function onSuccess(result) {
                    toastr.success("Registration successfull");
                    $state.go('profile');
                }
                $scope.lockButton = userApi.Register($scope.email, $scope.password, onSuccess);
            } else {
                // sth
            }

        };
    });

}());