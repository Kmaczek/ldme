(function () {
    angular.module('ldme').controller('naviCtrl', ['$scope', function ($scope) {
        $scope.hello = "Yo man!";

        console.log('in main ctrl');
    }]);

}())