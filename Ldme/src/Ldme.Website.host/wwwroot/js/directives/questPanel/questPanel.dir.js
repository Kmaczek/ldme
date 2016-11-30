(function () {
    "use strict";

    angular.module('ldme').directive('questPanel', ['questApi', 'playerInstance', 'toastr', function (questApi, playerInstance, toastr) {

        function linkFunc(scope, element, attrs) {
            scope.showDescriptionLookup = {};
            scope.showFinished = false;

            scope.toggleFinished = function () {
                scope.showFinished = !scope.showFinished;
            }

            scope.completeQuest = function (questId) {
                function onSuccess(result) {
                    playerInstance.fetchPlayerData();
                    toastr.success('Quests updated');
                }

                questApi.CompleteQuest({ id: questId }, { copletedBy: playerInstance.getPlayerData().id }, onSuccess);
            }

            scope.showDescription = function(itemNo) {
                if (scope.showDescriptionLookup[itemNo] === undefined) {
                    scope.showDescriptionLookup[itemNo] = true;
                } else {
                    scope.showDescriptionLookup[itemNo] = !scope.showDescriptionLookup[itemNo];
                }
            }

            scope.arrayFilter = { questType: scope.questFilter }
        }
        
        return {
            restrict: 'E',
            templateUrl: 'js/directives/questPanel/questPanel.tmpl.html',
            scope: {
                title: '@',
                quests: '=',
                questFilter: '@'
            },
            link: linkFunc
        }
    }]);
}())