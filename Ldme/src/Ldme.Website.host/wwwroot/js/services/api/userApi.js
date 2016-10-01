(function () {
    angular.module('ldme').factory('userApi', ['$resource', function ($resource) {

        var player = $resource('path', null,
        {
            'login': { method: 'POST' }
        });

        function login(email, password) {

        }
    }]);

}())