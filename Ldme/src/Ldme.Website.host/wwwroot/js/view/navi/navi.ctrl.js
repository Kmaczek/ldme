(function () {
    "use strict";

    angular.module('ldme').controller('naviCtrl', ['$state', 'userApi', 'appState', function ($state, userApi, appState) {
        this.isLoggedIn = appState.isLoggedIn;
        var ctrl = this;

        this.logIn = function() {
            function onSuccesffullLogin(response) {
                appState.logIn();
                appState.setPlayerData(response);
                $state.go('player');
            }

            userApi.Login(this.email, this.password, onSuccesffullLogin);
        };

        this.logOut = function() {
            appState.logOut();
            $state.go('main');
        };
    }]);

}());