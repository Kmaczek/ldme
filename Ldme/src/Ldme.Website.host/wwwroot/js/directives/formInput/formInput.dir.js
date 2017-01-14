﻿(function () {
    "use strict";

    angular.module('ldme').directive('formInput', function () {

        var linkFunc = function (scope, element, attrs) {
            scope.$watch(function () {
                return scope.formObj[scope.fieldName].$dirty;
            },
            function (newVal) {
                var s = scope.formObj[scope.fieldName];
            });

            scope.formField = scope.formObj[scope.fieldName];
        }

        return {
            restrict: 'E',
            transclude: true,
            templateUrl: 'js/directives/formInput/formInput.tmpl.html',
            link: linkFunc,
            scope: {
                errors: '=',
                label: '@',
                formObj: '=',
                fieldName: '@'
            }
        };
    });
}())