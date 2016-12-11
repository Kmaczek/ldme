(function () {
    "use strict";

    angular.module('ldme').factory('playerInstance', ['$resource', 'ldmeConfig', 'playerApi', 'questApi', 'rewardApi', 'toastr',
        function ($resource, ldmeConfig, playerApi, questApi, rewardApi, toastr) {
            var playerData = {
                name: '',
                honor: 0,
                gold: 0,
                id: 0,
                questsCreated: new Array(),
                questsOwned: new Array(),
                rewards: new Array()
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

                fetchRewards(playerId);

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

            function copyReward(array, result) {
                array.length = 0;
                angular.forEach(result, function (value) {
                    array.push(RewardModel.FromResponse(value));
                });
            }

            function fetchRewards(playerId) {
                function onSuccess(result) {
                    copyReward(playerData.rewards, result);
                }

                function onFail(result) {
                    toastr.error('Cannot get player rewards');
                }

                return rewardApi.GetRewards(playerId, onSuccess, onFail);
            }

            return {
                fetchPlayerData: fetchPlayerData,
                getPlayerData: getPlayerData,
                updateQuests: updateQuests
            }
        }]);
}())