(function () {
    angular.module('ldme').factory('questApi', function ($resource, ldmeConfig, apiCore) {
        var questApi = angular.extend({}, apiCore);
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
            },
            getCreatedBy: {
                method: 'GET',
                url: apiUrl + '/createdby/:id',
                params: {
                    id: '@id'
                },
                isArray: true
            },
            getOwnedBy: {
                method: 'GET',
                url: apiUrl + '/ownedby/:id',
                params: {
                    id: '@id'
                },
                isArray: true
            }
        });

        function createQuest(params, questModel, onSuccess, onFail) {
            return questApi.requestWrapperWithBody(quest.save, params, questModel, onSuccess, onFail);
        }

        function completeQuest(params, questCompletionModel, onSuccess, onFail) {
            return questApi.requestWrapperWithBody(quest.complete, params, questCompletionModel, onSuccess, onFail);
        }

        function getCreatedByPlayer(id, onSuccess, onFail) {
            return questApi.requestWrapperGET(quest.getCreatedBy, { id: id }, onSuccess, onFail);
        }

        function getOwnedByPlayer(id, onSuccess, onFail) {
            return questApi.requestWrapperGET(quest.getOwnedBy, { id: id }, onSuccess, onFail);
        }

        questApi.CreateQuest = createQuest;
        questApi.CompleteQuest = completeQuest;
        questApi.GetCreatedByPlayer = getCreatedByPlayer;
        questApi.GetOwnedByPlayer = getOwnedByPlayer;

        return questApi;
    });
}())