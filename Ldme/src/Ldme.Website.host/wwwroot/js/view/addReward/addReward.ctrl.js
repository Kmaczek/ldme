(function () {
    "use strict";

    angular.module('ldme').controller('addRewardCtrl', function ($scope, $timeout, playerInstance, rewardApi, toastr) {
        var ctrl = this;
        this.playerData = playerInstance.getPlayerData();
        this.formMsg = [];

        this.rewardModel = new RewardModel();

        (function initialize() {
            $scope.$parent.lpc.registerUnderlying($scope);

            var setCreatorId = $scope.$watch(function () {
                return ctrl.playerData.id;
            },
            function (newVal) {
                if (newVal) {
                    ctrl.rewardModel.rewardCreatorId = newVal;
                    setCreatorId();
                }
            });
        })();

        this.clearForm = function () {
            ctrl.rewardModel.clear();
            ctrl.formMsg.length = 0;
            $scope.rewardForm.$setPristine();
        }

        this.addReward = function () {
            angular.forEach($scope.rewardForm.$$controls, function (field) {
                field.$setDirty();
            });

            //wait for form validations
            $timeout(function () {
                if ($scope.rewardForm.$invalid) {
                    ctrl.formMsg.push('Form has errors, please correct them');
                    return;
                }

                createReward();
            }, 100);
        }

        function createReward() {
            function onSuccess(result) {
                toastr.success('Reward added');
                playerInstance.fetchPlayerData(ctrl.playerData.id);
                ctrl.clearForm();
            }

            function onFail(result) {
                //TODO: handle errors, print them into ctrl.formMsg
                ctrl.formMsg.push('Form has errors, please correct them');
                angular.forEach(result.data,
                    function(error) {
                        ctrl.formMsg.push(error.description);
                    });
                toastr.error('Cannot add reward');
            }
            ctrl.rewardModel.rewardCreatorId = -1;
            rewardApi.Add(ctrl.rewardModel, onSuccess, onFail);
        }
    });

    function RewardModel() {
        this.description = '';
        this.goldPrice = 0;
        this.honorPrice = 0;
        this.rewardCreatorId = 0;

        this.clear = function () {
            this.description = '';
            this.goldPrice = 0;
            this.honorPrice = 0;
        }
    };
}())