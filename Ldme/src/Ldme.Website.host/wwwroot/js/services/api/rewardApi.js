(function () {
    angular.module('ldme').factory('rewardApi', ['$resource', 'ldmeConfig', 'apiHelper', function ($resource, ldmeConfig, apiHelper) {

        var apiUrl = ldmeConfig.apiUrl + '/reward';

        var reward = $resource(apiUrl, null,
        {
            getRewardsForPlayer: {
                method: 'GET',
                url: apiUrl + '/forPlayer/:id',
                params: {
                    id: '@id'
                },
                isArray: true
            },
            claim: {
                method: 'POST',
                url: apiUrl + '/:id/claim',
                params: {
                    id: '@id'
                },
                isArray: true
            }
        });

        function getRewards(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(reward.getRewardsForPlayer, { id: id }, onSuccess, onFail);
        }

        function claimReward(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(reward.claim, { id: id }, onSuccess, onFail);
        }

        return {
            GetRewards: getRewards,
            ClaimReward: claimReward
        }
    }]);
}())