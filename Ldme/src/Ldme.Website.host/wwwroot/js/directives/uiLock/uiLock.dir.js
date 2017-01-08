(function () {
    "use strict";

    angular.module('ldme').directive('uiLock', function () {
        var imagePath = 'content/ring.svg';

        var linkFunc = function (scope, element, attrs) {
            scope.$watch(function () {
                return scope.lockCondition;
            },
            function (newVal) {
                if (newVal) {
                    if (!isLockSet(element)) {
                        element.addClass('ui-lock');
                        element.attr('img-src', imagePath);
                        disableElements(element.find('input'));
                        disableElements(element.find('button'));
                    }
                } else {
                    if (isLockSet(element)) {
                        element.removeClass('ui-lock');
                        restoreElements(element.find('input'));
                        restoreElements(element.find('button'));
                    }
                }
            });
        }

        function isLockSet(element) {
            return element.hasClass('ui-lock');
        }

        function disableElements(elements) {
            angular.forEach(elements,
                function (value) {
                    var el = angular.element(value);
                    el.attr('disabled', true);
                    el.attr('tabindex', -1);
                });
        }

        function restoreElements(elements) {
            angular.forEach(elements,
                function (value) {
                    var el = angular.element(value);
                    el.removeAttr('disabled');
                    el.removeAttr('tabindex');
                });
        }

        return {
            restrict: 'AE',
            link: linkFunc,
            scope: {
                lockCondition: '=',
                lockPromise: '='
            }
        };
    });
}())