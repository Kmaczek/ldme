(function () {
    angular.module('ldme').factory('rewardApi', function ($resource, ldmeConfig, apiCore) {
        var rewardApi = angular.extend({}, apiCore);
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
                }
            },
            deactivate: {
                method: 'POST',
                url: apiUrl + '/:id/deactivate',
                params: {
                    id: '@id'
                }
            },
            add: {
                method: 'POST'
            }
        });

        function getAll(id, onSuccess, onFail) {
            return rewardApi.requestWrapperGET(reward.getRewardsForPlayer, { id: id }, onSuccess, onFail);
        }

        function claim(id, onSuccess, onFail) {
            return rewardApi.requestWrapperGET(reward.claim, { id: id }, onSuccess, onFail);
        }

        function deactivate(id, onSuccess, onFail) {
            return rewardApi.requestWrapperGET(reward.deactivate, { id: id }, onSuccess, onFail);
        }

        function add(rewardModel, onSuccess, onFail) {
            return rewardApi.requestWrapperWithBody(reward.add, null, rewardModel, onSuccess, onFail);
        }

        rewardApi.GetAll = getAll;
        rewardApi.Claim = claim;
        rewardApi.Deactivate = deactivate;
        rewardApi.Add = add;

        return rewardApi;
    });
}())