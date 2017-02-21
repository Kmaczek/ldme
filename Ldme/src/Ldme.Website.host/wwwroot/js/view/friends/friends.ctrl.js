(function () {
    "use strict";

    angular.module('ldme').controller('friendsCtrl', function ($scope, playerInstance, playerApi) {
        var ctrl = this;
        this.searchInitialized = false;
        this.searchSuccessfull = false;
        this.currentFriends = [];

        (function () {
            var playerLoaded = $scope.$watch(function () {
                return playerInstance.isPlayerDataFetched();
            },
            function (newVal) {
                if (newVal === true) {
                    ctrl.currentFriends = playerInstance.getPlayerData().friends;
                    playerLoaded();
                }
            });
        })();

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
    });
}())