(function () {
    "use strict";

    angular.module('ldme').factory('playerInstance', ['$resource', 'ldmeConfig', 'playerApi', function ($resource, ldmeConfig, playerApi) {
        var playerData = {};

        function fetchPlayerData(email) {
            function onSuccess(result) {
                playerData.nickname = result.nickname;
                playerData.honor = result.honor;
                playerData.gold = result.gold;
            }

            playerApi.GetPlayer(email, onSuccess);
        }

        return {
            fetchPlayerData: fetchPlayerData
        }
    }]);
}())