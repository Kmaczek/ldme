(function () {
    angular.module('ldme').factory('userApi', function ($resource, toastr, ldmeConfig, apiCore) {
        var userApi = angular.extend({}, apiCore);
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
            return userApi.requestWrapperWithBody(user.login, null, { email: email, password: password }, onSuccess, onFail);
        }

        function register(email, password, onSuccess, onFail) {
            return userApi.requestWrapperWithBody(user.register, null, { email: email, password: password }, onSuccess, onFail);
        }

        userApi.Login = login;
        userApi.Register = register;

        return userApi;
    });

}());