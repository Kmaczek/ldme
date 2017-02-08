(function () {
    "use strict";

    angular.module('ldme')
        .controller('playerCtrl', function ($scope, $state, appState, playerInstance) {
            var ctrl = this;
            this.isLoggedIn = appState.isLoggedIn;

            (function initialize() {
                var playerLoaded = $scope.$watch(function () {
                        return playerInstance.isPlayerDataFetched();
                    },
                    function(newVal) {
                        if (newVal === true) {
                            ctrl.playerData = playerInstance.getPlayerData();
                            playerLoaded();
                        }
                    });
            })();

            this.addQuest = function () {
                if ($state.current.name === 'addQuest') {
                    $state.go('profile');
                } else {
                    $state.go('addQuest');
                }
            }
        });
}());