(function () {
    angular.module('ldme').controller('registerCtrl', function ($scope, userApi, toastr, $state) {
        var ctrl = this;
        this.messageGood = '';
        this.messageErrors = [];

        $scope.register = function () {
            ctrl.messageGood = '';
            ctrl.messageErrors.length = 0;

            function onSuccess(result) {
                ctrl.messageGood = 'User was created, please log in';
            }

            function onFail(result) {
                var errors = [];
                angular.forEach(result.data,
                function (value, key) {
                    errors.push(value.description || value.code);
                });

                ctrl.messageErrors = errors;
            }

            $scope.lockButton = userApi.Register($scope.email, $scope.password, onSuccess, onFail);
        };
    });

}());