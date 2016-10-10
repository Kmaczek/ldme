(function () {
    "use strict";

    angular.module('ldme').controller('playerCtrl', ['appState', 'playerInstance', function (appState, playerInstance) {
        var ctrl = this;
        this.isLoggedIn = appState.isLoggedIn;

        (function initialize() {
            if (appState.isLoggedIn) {
                playerInstance.fetchPlayerData(appState.getPlayerId()).then(function () {
                    var playerData = playerInstance.getPlayerData();
                    ctrl.name = playerData.name;
                    ctrl.gold = playerData.gold;
                    ctrl.honor = playerData.honor;
                    ctrl.quests = playerData.quests;
                });
            }
        })();
    }]);
}())