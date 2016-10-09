(function () {
    angular.module('ldme').factory('apiHelper', ['toastr', function (toastr) {

        function defaultOnSuccess(response) {

        }

        function defaultOnFail(response) {
            var errors = '';
            angular.forEach(response.data,
            function (value, key) {
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

        return {
            requestWrapper: callWrapper
        }
    }]);

}());