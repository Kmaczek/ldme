(function () {
    angular.module('ldme').controller('mainCtrl', ['$scope', function ($scope) {
        $scope.hello = "Yo man!";

        console.log('in main ctrl');
    }]);

}())