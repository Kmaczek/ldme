(function () {
    "use strict";

    angular.module('ldme').controller('addQuestCtrl', function ($scope, $timeout, playerInstance, questApi, toastr, enumHelper) {
        var ctrl = this;
        this.playerData = playerInstance.getPlayerData();
        this.deadlinePickerOpened = false;
        this.deadlineOptions = {
            formatYear: 'yy',
            maxDate: new Date(2020, 1, 1),
            minDate: new Date(),
            startingDay: 1
        };
        this.formMsg = '';

        this.formModel = new FormModel();

        (function initialize() {
            createQuestTypeOptions();
            $scope.$parent.lpc.registerUnderlying($scope);
        })();

        this.clearForm = function () {
            ctrl.formModel.clear();
            ctrl.formMsg = '';
            $scope.questForm.$setPristine();
        }

        this.createQuest = function () {
            angular.forEach($scope.questForm.$$controls, function (field) {
                field.$setDirty();
            });

            //wait for form validations
            $timeout(function() {
                if ($scope.questForm.$invalid) {
                    ctrl.formMsg = 'Form has errors, please correct them';
                    return;
                }

                createQuest();
            }, 100);
        }

        this.openDeadlinePicker = function () {
            this.deadlinePickerOpened = true;
        }

        function createQuestTypeOptions() {
            ctrl.questTypes = enumHelper.ToSelectOptions(QuestType);
        }

        function createQuest() {
            var qModel = null;
            if (ctrl.formModel.questType === QuestType.Regular) {
                qModel = QuestModel.CreateRegular(
                    ctrl.playerData.id,
                    ctrl.playerData.id,
                    ctrl.formModel.name,
                    ctrl.formModel.description,
                    ctrl.formModel.goldReward,
                    ctrl.formModel.goldPenalty,
                    ctrl.formModel.honorReward,
                    ctrl.formModel.honorPenalty,
                    moment(),
                    ctrl.formModel.endTime);
            }

            if (ctrl.formModel.questType === QuestType.Daily) {
                qModel = QuestModel.CreateDaily(
                    ctrl.playerData.id,
                    ctrl.playerData.id,
                    ctrl.formModel.name,
                    ctrl.formModel.description,
                    ctrl.formModel.goldReward,
                    ctrl.formModel.goldPenalty,
                    ctrl.formModel.honorReward,
                    ctrl.formModel.honorPenalty,
                    moment(),
                    ctrl.formModel.endTime);
            }

            function onSuccess() {
                toastr.success('Quest added');
                playerInstance.updateQuests();
                ctrl.clearForm();
            }

            function onFail() {
                toastr.error('Cannot add quest');
            }

            questApi.CreateQuest(null, qModel, onSuccess, onFail);
        }
    });

    function FormModel() {
        this.self = this;
        this.name = '';
        this.description = '';
        this.goldReward = 0;
        this.goldPenalty = 0;
        this.honorReward = 0;
        this.honorPenalty = 0;
        this.questType = QuestType.Regular;
        this.endTime = null;

        this.clear = function () {
            this.name = '';
            this.description = '';
            this.goldReward = 0;
            this.goldPenalty = 0;
            this.honorReward = 0;
            this.honorPenalty = 0;
            this.questType = QuestType.Regular;
            this.endTime = null;
        }
    };
}())