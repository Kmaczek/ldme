(function () {
    "use strict";

    angular.module('ldme').controller('naviCtrl', ['$state', 'userApi', 'appState', 'playerInstance', function ($state, userApi, appState, playerInstance) {
        this.isLoggedIn = appState.isLoggedIn;
        var ctrl = this;

        ctrl.playerName = function () {
            return playerInstance.getPlayerData().name;
        }

        this.logIn = function() {
            function onSuccessfullLogin(response) {
                appState.logIn();
                appState.setPlayerData(response);
                $state.go('profile');
            }

            function onFailedLogin(response) {
                ctrl.password = '';
                userApi.defaultOnFail(response);
            }

            ctrl.lockLogin = userApi.Login(this.email, this.password, onSuccessfullLogin, onFailedLogin);
        };

        this.logOut = function() {
            appState.logOut();
            $state.go('main');
        };
    }]);

}());