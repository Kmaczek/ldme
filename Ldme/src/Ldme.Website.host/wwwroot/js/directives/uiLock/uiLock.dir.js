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
                    lock(element);
                } else {
                    unlock(element);
                }
            });

            scope.$watch(function() {
                return scope.lockPromise && scope.lockPromise.$$state && scope.lockPromise.$$state.status;
            },
            function (newVal) {
                if (newVal && newVal.$$state && !newVal.$$state.status) {
                    lock(element);
                } else {
                    unlock(element);
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

        function lock(element) {
            if (!isLockSet(element)) {
                element.addClass('ui-lock');
                element.attr('img-src', imagePath);
                disableElements(element.find('input'));
                disableElements(element.find('button'));
            }
        }

        function unlock(element) {
            if (isLockSet(element)) {
                element.removeClass('ui-lock');
                restoreElements(element.find('input'));
                restoreElements(element.find('button'));
            }
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