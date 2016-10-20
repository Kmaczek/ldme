(function () {
    "use strict";

    angular.module('ldme').controller('friendsCtrl', ['playerInstance', 'playerApi', function (playerInstance, playerApi) {
        var ctrl = this;

        ctrl.findFriends = function (query) {
            function onSuccess(result) {
                var players = result;
            }
            playerApi.FindPlayers(query, onSuccess);
        }
    }]);
}())