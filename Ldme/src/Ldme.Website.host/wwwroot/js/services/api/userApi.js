(function () {
    angular.module('ldme').factory('userApi', ['$resource', 'toastr', 'ldmeConfig', 'apiHelper', function ($resource, toastr, ldmeConfig, apiHelper) {

        var apiUrl = ldmeConfig.apiUrl + "/user";

        var user = $resource(apiUrl, null,
        {
            login: {
                method: 'POST',
                url: apiUrl + '/login',
                withCredentials: true
            },
            register: {
                method: 'POST',
                url: apiUrl + '/register',
                withCredentials: true
            }
        });

        function login(email, password, onSuccess, onFail) {
            apiHelper.requestWrapperPOST(user.login, null, { email: email, password: password }, onSuccess, onFail);
        }

        function register(email, password, onSuccess, onFail) {
            apiHelper.requestWrapperPOST(user.register, null, { email: email, password: password }, onSuccess, onFail);
        }

        return {
            Login: login,
            Register: register
        };
    }]);

}());