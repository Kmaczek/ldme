(function () {
    "use strict";

    angular.module('ldme').factory('playerInstance', ['$resource', 'ldmeConfig', 'playerApi', 'questApi', function ($resource, ldmeConfig, playerApi, questApi) {
        var playerData = {
            name: '',
            honor: 0,
            gold: 0,
            id: 0,
            questsCreated: new Array(),
            questsOwned: new Array()
        };

        function fetchPlayerData(id) {
            var playerId = id || playerData.id || 0;
            if (playerId === 0) {
                throw "Invalid player ID";
            }

            function onSuccess(result) {
                //JsonNetDecycle.retrocycle(result);
                playerData.name = result.name;
                playerData.honor = result.honor;
                playerData.gold = result.gold;
                playerData.id = result.id;
                copyQuests(playerData.questsCreated, result.questsCreated);
                copyQuests(playerData.questsOwned, result.questsOwned);
            }

            return playerApi.GetPlayer(playerId, onSuccess);
        }

        function getPlayerData() {
            return playerData;
        }

        function updateQuests(typeToUpdate) {
            function onSuccessWrap(array) {
                function onSuccess(result) {
                    copyQuests(array, result);
                 }

                return onSuccess;
            }

            if (!typeToUpdate || typeToUpdate === 'created') {
                questApi.GetCreatedByPlayer(playerData.id, onSuccessWrap(playerData.questsCreated));
            }

            if (!typeToUpdate || typeToUpdate === 'owned') {
                questApi.GetOwnedByPlayer(playerData.id, onSuccessWrap(playerData.questsOwned));
            }
        }

        function copyQuests(array, result) {
            array.length = 0;
            angular.forEach(result, function (value) {
                array.push(QuestModel.FromResponse(value));
            });
        }

        return {
            fetchPlayerData: fetchPlayerData,
            getPlayerData: getPlayerData,
            updateQuests: updateQuests
        }
    }]);
}())