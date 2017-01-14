(function () {
    "use strict";

    angular.module('ldme').controller('addQuestCtrl', function ($scope, playerInstance, questApi, toastr, enumHelper) {
        var ctrl = this;
        this.playerData = playerInstance.getPlayerData();
        this.deadlinePickerOpened = false;
        this.deadlineOptions = {
            //dateDisabled: disabled,
            formatYear: 'yy',
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
        };
        this.formErrors = {
            name: [],
            description: [],
            goldReward: [],
            goldPenalty: [],
            honorReward: [],
            honorPenalty: []
        };

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
            var qModel = null;
            if (ctrl.questType === QuestType.Regular) {
                qModel = QuestModel.CreateRegular(ctrl.playerData.id, ctrl.playerData.id, ctrl.qName, ctrl.qDescription, ctrl.goldReward,
                    ctrl.goldPenalty, ctrl.honorReward, ctrl.honorPenalty, moment(), ctrl.endTime);
            }

            if (ctrl.questType === QuestType.Daily) {
                qModel = QuestModel.CreateDaily(ctrl.playerData.id, ctrl.playerData.id, ctrl.qName, ctrl.qDescription, ctrl.goldReward,
                    ctrl.goldPenalty, ctrl.honorReward, ctrl.honorPenalty, moment(), ctrl.endTime);
            }

            function onSuccess(result) {
                toastr.success('Quest added');
                ctrl.showQuestForm = false;
                playerInstance.updateQuests();
                ctrl.questForm.$setPristine();
            }

            //            function onFail(result) {
            //                toastr.error('Cannot add quest');
            //            }

            questApi.CreateQuest(null, qModel, onSuccess);
        }

        this.openDeadlinePicker = function () {
            this.deadlinePickerOpened = true;
        }

        function createQuestTypeOptions() {
            ctrl.questTypes = enumHelper.ToSelectOptions(QuestType);
        }

        function setDefaultQuestType(qType) {
            ctrl.questType = qType;
        }

        function disablePast() {

        }
    });
}())