(function () {
    "use strict";

    angular.module('ldme').controller('addQuestCtrl', function ($scope, playerInstance, questApi, toastr, enumHelper) {
        var ctrl = this;

        (function initialize() {
            createQuestTypeOptions();
            setDefaultQuestType(QuestType.Regular);
            $scope.$parent.lpc.registerUnderlying($scope);
        })();

        this.cancelQuestCreation = function () {
            this.questForm.$setPristine();
            this.showQuestForm = false;
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
            qModel.endTime = null; //moment().add(7, 'days');
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

        function createQuestTypeOptions() {
            ctrl.questTypes = enumHelper.ToSelectOptions(QuestType);
        }

        function setDefaultQuestType(qType) {
            ctrl.questType = qType;
        }
    });
}())