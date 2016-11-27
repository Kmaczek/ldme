(function () {
    "use strict";

    angular.module('ldme').controller('playerCtrl', ['appState', 'playerInstance', 'questApi', 'toastr', 'enumHelper',
        function (appState, playerInstance, questApi, toastr, enumHelper) {
            var ctrl = this;
            this.isLoggedIn = appState.isLoggedIn;
            this.showFinished = false;
            this.showQuestForm = false;

            (function initialize() {
                if (appState.isLoggedIn) {
                    playerInstance.fetchPlayerData(appState.getPlayerId()).then(function () {
                        ctrl.playerData = playerInstance.getPlayerData();
                    });
                }
                createQuestTypeOptions();
                setDefaultQuestType(QuestType.Regular);
            })();

            this.addQuest = function () {
                this.showQuestForm = true;
            }

            this.cancelQuestCreation = function () {
                this.showQuestForm = false;
                this.questForm.$setPristine();
            }

            this.createQuest = function () {

                var qModel = new QuestModel();
                qModel.fromPlayer = ctrl.playerData.id;
                qModel.toPlayer = ctrl.playerData.id;
                qModel.name = ctrl.qName;
                qModel.description = ctrl.qDescription;
                qModel.goldReward = ctrl.goldReward;
                qModel.goldPenalty = ctrl.goldPenalty;
                qModel.honorReward = ctrl.honorReward;
                qModel.honorPenalty = ctrl.honorPenalty;
                qModel.startTime = moment();
                qModel.endTime = moment().add(7, 'days');
                qModel.questType = ctrl.questType;

                function onSuccess(result) {
                    toastr.success('Quest added');
                    ctrl.showQuestForm = false;
                    playerInstance.updateQuests();
                    ctrl.questForm.$setPristine();
                }

                function onFail(result) {
                    toastr.error('Cannot add quest');
                }

                questApi.CreateQuest(null, qModel, onSuccess, onFail);
            }

            this.completeQuest = function (questId) {
                function onSuccess(result) {
                    playerInstance.fetchPlayerData();
                    toastr.success('Quests updated');
                }

                questApi.CompleteQuest({ id: questId }, { copletedBy: ctrl.playerData.id }, onSuccess);
            }

            this.toggleFinished = function () {
                ctrl.showFinished = !ctrl.showFinished;
            }

            function createQuestTypeOptions() {
                ctrl.questTypes = enumHelper.ToSelectOptions(QuestType);
            }

            function setDefaultQuestType(qType) {
                ctrl.questType = qType;
            }
        }]);
}())