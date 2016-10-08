(function () {
    angular.module('ldme').factory('userApi', ['$resource', 'toastr', 'ldmeConfig', function ($resource, toastr, ldmeConfig) {

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

        function defaultOnSuccess(response) {

        }

        function defaultOnFail(response) {
            var errors = '';
                angular.forEach(response.data,
                function(value, key) {
                    errors += '- ' + value.code + "<br>";
                });
            toastr.error('Request failed: <br>' + errors);
        }

        function callWrapper(action, params, onSuccess, onFail) {
            var success = defaultOnSuccess;
            var fail = defaultOnFail;
            if (onSuccess) {
                success = onSuccess;
            }
            if (onFail) {
                fail = onFail;
            }
            action(params, success, fail);
        }

        function login(email, password, onSuccess, onFail) {
            callWrapper(user.login, { email: email, password: password }, onSuccess, onFail);
        }

        function register(email, password, onSuccess, onFail) {
            callWrapper(user.register, { email: email, password: password }, onSuccess, onFail);
        }

        return {
            Login: login,
            Register: register
        }
    }]);

}())