(function () {
    "use strict";

    angular.module('ldme').factory('playerInstance',
        function ($resource, ldmeConfig, playerApi, questApi, rewardApi, friendsApi, toastr) {
            var playerData = {
                name: '',
                honor: 0,
                gold: 0,
                id: 0,
                questsCreated: new Array(),
                questsOwned: new Array(),
                rewards: new Array(),
                friends: new Array()
            };

            function fetchPlayerData(id) {
                var playerId = id || playerData.id || 0;
                if (playerId === 0) {
                    console.error("Invalid player ID");
                }

                function onSuccess(result) {
                    //JsonNetDecycle.retrocycle(result);
                    playerData.name = result.name;
                    playerData.honor = result.honor;
                    playerData.gold = result.gold;
                    playerData.id = result.id;
                    copyToArray(playerData.questsCreated, result.questsCreated, QuestModel);
                    copyToArray(playerData.questsOwned, result.questsOwned, QuestModel);
                }

                getRewards(playerId);
                getFriends(playerId);

                return playerApi.GetPlayer(playerId, onSuccess);
            }

            function getPlayerData() {
                return playerData;
            }

            function updateQuests(typeToUpdate) {
                function onSuccessWrap(array) {
                    function onSuccess(result) {
                        copyToArray(array, result, QuestModel);
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

            function isPlayerDataFetched() {
                return playerData.id > 0;
            }

            function copyToArray(array, result, model) {
                array.length = 0;
                angular.forEach(result, function (value) {
                    array.push(model.FromResponse(value));
                });
            }

            function getRewards(playerId) {
                function onSuccess(result) {
                    copyToArray(playerData.rewards, result, RewardModel);
                }

                function onFail(result) {
                    toastr.error('Can not get player rewards');
                }

                return rewardApi.GetAll(playerId, onSuccess, onFail);
            }

            function getFriends(playerId) {
                function onSuccess(result) {
                    copyToArray(playerData.friends, result, FriendModel);
                }

                function onFail(result) {
                    toastr.error('Can not get players friends');
                }

                return friendsApi.GetAll(playerId, onSuccess, onFail);
            }

            return {
                fetchPlayerData: fetchPlayerData,
                getPlayerData: getPlayerData,
                updateQuests: updateQuests,
                isPlayerDataFetched: isPlayerDataFetched
            }
        });
}())