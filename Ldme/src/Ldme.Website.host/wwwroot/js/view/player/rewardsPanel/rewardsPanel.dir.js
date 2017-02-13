(function () {
    "use strict";

    angular.module('ldme').directive('rewardsPanel', ['rewardApi', 'playerInstance', 'toastr',
        function (rewardApi, playerInstance, toastr) {

            function linkFunc(scope, element, attrs) {

                scope.claimReward = function (questId) {
                    function onSuccess(result) {
                        playerInstance.fetchPlayerData();
                    }

                    rewardApi.ClaimReward(questId, onSuccess);
                }

                scope.deactivate = function (questId) {
                    function onSuccess(result) {
                        playerInstance.fetchPlayerData();
                    }

                    rewardApi.Deactivate(questId, onSuccess);
                }
            }

            return {
                restrict: 'E',
                templateUrl: 'js/view/player/rewardsPanel/rewardsPanel.tmpl.html',
                scope: {
                    title: '@',
                    rewards: '='
                },
                link: linkFunc
            }
        }]);
}())