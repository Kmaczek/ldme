(function () {
    "use strict";

    angular.module('ldme').directive('questPanel', ['questApi', 'playerInstance', 'toastr', function (questApi, playerInstance, toastr) {

        function linkFunc(scope, element, attrs) {
            this.showFinished = false;

            scope.toggleFinished = function () {
                scope.showFinished = !scope.showFinished;
            }

            scope.completeQuest = function (questId) {
                function onSuccess(result) {
                    playerInstance.fetchPlayerData();
                    toastr.success('Quests updated');
                }

                scope.CompleteQuest({ id: questId }, { copletedBy: scope.playerData.id }, onSuccess);
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