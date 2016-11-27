(function () {
    "use strict";

    angular.module('ldme').directive('questPanel', ['ldmeConfig', function (ldmeConfig) {

        function linkFunc(scope, element, attrs) {
            
        }
        
        return {
            restrict: 'E',
            templateUrl: 'questPanel.tmpl.html',
            scope: {
                title: '@',
                quests: '&'
            },
            link: linkFunc
        }
    }]);
}())