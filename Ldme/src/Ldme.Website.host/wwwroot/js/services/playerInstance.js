(function () {
    "use strict";

    angular.module('ldme').factory('playerInstance', ['$resource', 'ldmeConfig', 'playerApi', 'questApi', function ($resource, ldmeConfig, playerApi, questApi) {
        var playerData = {};

        function fetchPlayerData(id) {
            function onSuccess(result) {
                function createQuestList(quests) {
                    var list = new Array();

                    angular.forEach(quests, function (value) {
                        list.push(QuestModel.FromResponse(value));
                    });

                    return list;
                }
                //JsonNetDecycle.retrocycle(result);
                playerData.name = result.name;
                playerData.honor = result.honor;
                playerData.gold = result.gold;
                playerData.id = result.id;
                playerData.questsCreated = createQuestList(result.questsCreated);
                playerData.questsOwned = createQuestList(result.questsOwned);
            }

            return playerApi.GetPlayer(id, onSuccess);
        }

        function getPlayerData() {
            return playerData;
        }

        function updateQuests(typeToUpdate) {
            function onSuccessWrap(array) {
                 function onSuccess(result) {
                    array.length = 0;
                    angular.forEach(result, function (value) {
                        array.push(QuestModel.FromResponse(value));
                    });
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

        return {
            fetchPlayerData: fetchPlayerData,
            getPlayerData: getPlayerData,
            updateQuests: updateQuests
        }
    }]);
}())