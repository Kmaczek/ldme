(function () {
    "use strict";

    angular.module('ldme').factory('playerInstance', ['$resource', 'ldmeConfig', 'playerApi', function ($resource, ldmeConfig, playerApi) {
        var playerData = {};

        function fetchPlayerData(id) {
            function onSuccess(result) {
                //JsonNetDecycle.retrocycle(result);
                playerData.name = result.name;
                playerData.honor = result.honor;
                playerData.gold = result.gold;
                playerData.id = result.id;
                playerData.questsCreated = result.questsCreated;
                playerData.questsOwned = result.questsOwned;
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