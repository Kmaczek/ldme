(function () {
    angular.module('ldme').factory('questApi', ['$resource', 'ldmeConfig', 'apiHelper', function ($resource, ldmeConfig, apiHelper) {

        var apiUrl = ldmeConfig.apiUrl + '/quest';

        var quest = $resource(apiUrl, null,
        {
            save: {
                method: 'POST',
                withCredentials: true
            },
            complete: {
                method: 'POST',
                withCredentials: true,
                url: apiUrl + '/:id/complete',
                params: {
                    id: '@id'
                }
            }
        });

        function createQuest(params, questModel, onSuccess, onFail) {
            return apiHelper.requestWrapperPOST(quest.save, params, questModel, onSuccess, onFail);
        }

        function completeQuest(params, questCompletionModel, onSuccess, onFail) {
            return apiHelper.requestWrapperPOST(quest.complete, params, questCompletionModel, onSuccess, onFail);
        }

        return {
            CreateQuest: createQuest,
            CompleteQuest: completeQuest
        }
    }]);
}())