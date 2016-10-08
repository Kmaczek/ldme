(function () {
    angular.module('ldme').factory('appState', ['$cookies', function ($cookies) {
        var cName = 'ldmeState';
        var state;

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
            logOut: logOut
        }
    }]);
}())