(function () {
    angular.module('ldme').factory('apiHelper', ['toastr', function (toastr) {

        function defaultOnSuccess(response) {

        }

        function defaultOnFail(response) {
            var errors = '';
            angular.forEach(response.data,
            function (value, key) {
                errors += '- ' + value[0] + "<br>";
            });
            toastr.error('Request failed: <br>' + errors);
        }

        function callWrapperGET(action, params, onSuccess, onFail) {
            var success = defaultOnSuccess;
            var fail = defaultOnFail;
            if (onSuccess) {
                success = onSuccess;
            }
            if (onFail) {
                fail = onFail;
            }
            return action(params, success, fail).$promise;
        }

        function callWrapperPOST(action, params, body, onSuccess, onFail) {
            var success = defaultOnSuccess;
            var fail = defaultOnFail;
            var param = {};
            if (onSuccess) {
                success = onSuccess;
            }
            if (onFail) {
                fail = onFail;
            }
            if (params) {
                param = params;
            }
            return action(params, body, success, fail).$promise;
        }

        return {
            requestWrapperGET: callWrapperGET,
            requestWrapperPOST: callWrapperPOST
        }
    }]);

}());