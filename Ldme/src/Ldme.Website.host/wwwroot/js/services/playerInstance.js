(function () {
    "use strict";

    angular.module('ldme').factory('playerInstance', ['$resource', 'ldmeConfig', 'playerApi', function ($resource, ldmeConfig, playerApi) {
        var playerData = {};

        function fetchPlayerData(id) {
            function onSuccess(result) {
                playerData.name = result.name;
                playerData.honor = result.honor;
                playerData.gold = result.gold;
                playerData.id = result.id;
                playerData.quests = result.quests;
            }

            return playerApi.GetPlayer(id, onSuccess);
        }

        function getPlayerData() {
            return playerData;
        }

        return {
            fetchPlayerData: fetchPlayerData,
            getPlayerData: getPlayerData
        }
    }]);
}())