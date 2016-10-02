(function () {
    angular.module('ldme').factory('userApi', ['$resource', 'toastr', 'ldmeConfig', function ($resource, toastr, ldmeConfig) {

        var apiUrl = ldmeConfig.apiUrl + "/user";

        var player = $resource(apiUrl, null,
        {
            login: {
                method: 'POST',
                url: apiUrl + '/login',
                withCredentials: true
            }
        });

        function defaultOnSuccess(response) {

        }

        function defaultOnFail(response) {
            toastr.error('Cannot log in');
        }

        function login(email, password, onSuccess, onFail) {
            var success = defaultOnSuccess;
            var fail = defaultOnFail;
            if (onSuccess) {
                success = onSuccess;
            }
            if (onFail) {
                fail = onFail;
            }
            player.login({ email: email, password: password }, success, fail);
        }

        return {
            Login: login
        }
    }]);

}())