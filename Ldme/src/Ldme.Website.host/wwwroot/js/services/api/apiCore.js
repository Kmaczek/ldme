﻿(function () {
    angular.module('ldme').factory('apiCore', ['toastr', function (toastr) {

        function defaultOnSuccess(response) {

        }

        function defaultOnFail(response) {
            var errors = '';
            angular.forEach(response.data,
            function (value, key) {
                errors += '- ' + (value.description || value.code) + "<br>";
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

        function callWrapperWithBody(action, params, body, onSuccess, onFail) {
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

        function getDefaultErrors(response, unformatted) {
            var errors = '';
            angular.forEach(response.data,
            function (value, key) {
                errors += '- ' + (value.description || value.code) + (unformatted ? '': '<br>');
            });

            return errors;
        }

        return {
            requestWrapperGET: callWrapperGET,
            requestWrapperWithBody: callWrapperWithBody,
            getDefaultErrors: getDefaultErrors,
            defaultOnFail: defaultOnFail
        }
    }]);
}());