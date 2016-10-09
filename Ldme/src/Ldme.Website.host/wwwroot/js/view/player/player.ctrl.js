(function () {
    "use strict";

    angular.module('ldme').controller('playerCtrl', ['appState', 'playerInstance', function (appState, playerInstance) {
        this.isLoggedIn = appState.isLoggedIn;

        (function initialize() {
            if (appState.isLoggedIn) {
                playerInstance.fetchPlayerData(appState.getEmail());
            }
        })();

    }]);
}())