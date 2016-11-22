(function () {
    "use strict";

    angular.module('ldme').factory('enumHelper', ['ldmeConfig', function (ldmeConfig) {

        function getFields(enumObj) {
            var enumFields = [];

            angular.forEach(enumObj,
                function(value) {
                    enumFields.push(value);
                });

            return enumFields;
        }

        function getKeys(enumObj) {
            var enumKeys = [];

            angular.forEach(enumObj,
                function (value, key) {
                    enumKeys.push(key);
                });

            return enumKeys;
        }

        function toSelectOptions(enumObj) {
            var enumOptions = [];

            angular.forEach(enumObj,
                function(value, key) {
                    enumOptions.push({ value: value, name: key.split(/(?=[A-Z])/).join(" ") });
                });

            return enumOptions;
        }

        return {
            GetFields: getFields,
            GetKeys: getKeys,
            ToSelectOptions: toSelectOptions
        }
    }]);
}())