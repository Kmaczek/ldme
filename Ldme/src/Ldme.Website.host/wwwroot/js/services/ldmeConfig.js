(function () {
    angular.module('ldme').factory('ldmeConfig', ['$cookies', function ($cookies) {
        var webConfig = $cookies.getObject('ldmeConfig');

        return webConfig;
    }]);
}())