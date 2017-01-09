(function () {
    "use strict";

    angular.module('ldme').controller('naviCtrl', ['$state', 'userApi', 'appState', 'playerInstance', function ($state, userApi, appState, playerInstance) {
        this.isLoggedIn = appState.isLoggedIn;
        var ctrl = this;

        ctrl.playerName = function () {
            return playerInstance.getPlayerData().name;
        }

        this.logIn = function() {
            function onSuccesffullLogin(response) {
                appState.logIn();
                appState.setPlayerData(response);
                $state.go('profile');
            }

            ctrl.lockLogin = userApi.Login(this.email, this.password, onSuccesffullLogin);
        };

        this.logOut = function() {
            appState.logOut();
            $state.go('main');
        };
    }]);

}());