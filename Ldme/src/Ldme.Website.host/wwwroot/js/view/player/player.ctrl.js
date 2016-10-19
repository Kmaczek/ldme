(function () {
    "use strict";

    angular.module('ldme').controller('playerCtrl', ['appState', 'playerInstance', 'questApi', 'toastr', function (appState, playerInstance, questApi, toastr) {
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
        })();

        this.addQuest = function() {
            this.showQuestForm = true;
        }

        this.cancelQuestCreation = function() {
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

            function onSuccess(result) {
                toastr.success('Quest added');
                ctrl.showQuestForm = false;
                ctrl.questForm.$setPristine();
            }

            function onFail(result) {
                toastr.error('Cannot add quest');
            }

            questApi.CreateQuest(null, qModel, onSuccess, onFail);
        }

        this.completeQuest = function(questId) {
            questApi.CompleteQuest({ id: questId },{copletedBy: ctrl.playerData.id});
        }
        
        this.toggleFinished = function() {
            ctrl.showFinished = !ctrl.showFinished;
        }
    }]);
}())