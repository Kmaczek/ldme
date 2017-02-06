(function () {
    "use strict";

    angular.module('ldme').directive('formInput', function () {

        var linkFunc = function (scope, element, attrs) {
            scope.formField = scope.formObj[scope.fieldName];
            scope.focus = false;
            scope.isOpen = function() {
                return !scope.formField.$valid;
            }
        }

        return {
            restrict: 'E',
            transclude: true,
            templateUrl: 'js/directives/formInput/formInput.tmpl.html',
            link: linkFunc,
            scope: {
                errors: '=',
                label: '@',
                errorsUrl: '@',
                formObj: '=', // for future maybe remove this field
                fieldName: '@' // for future maybe remove this field
            }
        };
    });
}())