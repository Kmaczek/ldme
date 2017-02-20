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
            return apiHelper.requestWrapperGET(reward.getRewardsForPlayer, { id: id }, onSuccess, onFail);
        }

        function claim(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(reward.claim, { id: id }, onSuccess, onFail);
        }

        function deactivate(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(reward.deactivate, { id: id }, onSuccess, onFail);
        }

        function add(rewardModel, onSuccess, onFail) {
            return apiHelper.requestWrapperWithBody(reward.add, null, rewardModel, onSuccess, onFail);
        }

        return {
            GetAll: getAll,
            Claim: claim,
            Deactivate: deactivate,
            Add: add
        }
    }]);
}())