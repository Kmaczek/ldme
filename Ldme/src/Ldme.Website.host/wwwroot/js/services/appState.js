﻿(function () {
    angular.module('ldme').factory('appState', ['$cookies', function ($cookies) {
        var cName = 'ldmeState';
        var state;

        var dependencies = [];

        (function initialize() {
            setCookie();
        })();

        //------------------------------------
        function isLoggedIn() {
            return state.isLoggedIn;
        }

        function logIn() {
            state.isLoggedIn = true;
            $cookies.putObject(cName, state);
        }

        function logOut() {
            state.isLoggedIn = false;
            $cookies.putObject(cName, state);
        }

        function getEmail() {
            return state.email;
        }

        function getPlayerId() {
            return state.playerId;
        }

        function setUserData(response) {
            state.email = response.email;
            state.userId = response.id;
            state.playerId = response.playerId;
            $cookies.putObject(cName, state);
        }

        function dependencyFinishedLoading(name) {
            dependencies[name] = true;
        }

        //------------------------------------
        function setCookie() {
            function getDefaultState() {
                return {
                    isLoggedIn: false
                }
            }

            state = $cookies.getObject(cName);
            if (!state) {
                state = getDefaultState();
            }

            return state;
        }

        //------------------------------------
        return {
            isLoggedIn: isLoggedIn,

            logIn: logIn,
            logOut: logOut,
            getEmail: getEmail,
            getPlayerId: getPlayerId,
            setUserData: setUserData,
            dependencies: dependencies,
            dependencyFinishedLoading: dependencyFinishedLoading,

            onLoggedIn: function () {
                //TODO: why do I need this?
                // implement
            }
        }
    }]);
}())