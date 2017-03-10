(function () {
    angular.module('ldme').directive('repeat', function () {

        function linkFunc(scope, element, attributes, ctrls) {
            scope.$watch(function () {
                return ctrls[0][attributes.repeat].$viewValue;
            },
                function () {
                    ctrls[1].$validate();
                });

            ctrls[1].$validators.same = function (modelValue) {
                if (ctrls[1].$dirty) {
                    var valid = ctrls[0][attributes.repeat].$valid;
                    var same = modelValue === ctrls[0][attributes.repeat].$viewValue;
                    return valid && same;

                }
                return true;
            }
        }

        return {
            restrict: 'A',
            require: ['^form','?ngModel'],
            link: linkFunc
        }
    });
}());