(function () {
    "use strict";

    angular.module('ldme')
        .controller('playerCtrl', function ($state, appState, playerInstance) {
            var ctrl = this;
            this.isLoggedIn = appState.isLoggedIn;
            this.showQuestForm = false;

            (function initialize() {
                if (appState.isLoggedIn) {
                    playerInstance.fetchPlayerData(appState.getPlayerId())
                        .then(function () {
                            ctrl.playerData = playerInstance.getPlayerData();
                        });
                }

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