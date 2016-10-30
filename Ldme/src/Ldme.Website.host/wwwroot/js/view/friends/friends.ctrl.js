(function () {
    "use strict";

    angular.module('ldme').controller('friendsCtrl', ['playerInstance', 'playerApi', function (playerInstance, playerApi) {
        var ctrl = this;
        this.searchInitialized = false;
        this.searchSuccessfull = false;

        ctrl.findFriends = function (query) {
            ctrl.searchInitialized = true;
            function onSuccess(result) {
                ctrl.searchSuccessfull = true;
                ctrl.searchedPlayer = result[0];
            }

            function onFail(result) {
                ctrl.searchSuccessfull = false;
            }
            playerApi.FindPlayers(query, onSuccess, onFail);
        }
    }]);
}())