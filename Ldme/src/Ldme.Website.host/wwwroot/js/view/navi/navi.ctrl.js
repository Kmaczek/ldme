(function () {
    "use strict";

    angular.module('ldme').controller('naviCtrl', ['$state', 'userApi', 'appState', function ($state, userApi, appState) {
        this.isLoggedIn = appState.isLoggedIn;
        var self = this;

        this.logIn = function() {
            function goToPlayerPage() {
                appState.logIn();
                $state.go('player');
            }

            userApi.Login(this.email, this.password, goToPlayerPage);
        }

        this.logOut = function() {
            appState.logOut();
            $state.go('main');
        }
    }]);

}())