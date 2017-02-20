(function () {
    "use strict";

    angular.module('ldme').directive('rewardsPanel', ['rewardApi', 'playerInstance', '$state', 'toastr',
        function (rewardApi, playerInstance, $state, toastr) {

            function linkFunc(scope, element, attrs) {

                scope.claimReward = function (rewardId) {
                    function onSuccess(result) {
                        playerInstance.fetchPlayerData();
                    }

                    rewardApi.Claim(rewardId, onSuccess);
                }

                scope.deactivate = function (questId) {
                    function onSuccess(result) {
                        playerInstance.fetchPlayerData();
                    }

                    rewardApi.Deactivate(questId, onSuccess);
                }

                scope.addReward = function() {
                    if ($state.current.name === 'addReward') {
                        $state.go('profile');
                    } else {
                        $state.go('addReward');
                    }
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