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
            return apiHelper.requestWrapperWithBody(quest.save, params, questModel, onSuccess, onFail);
        }

        function completeQuest(params, questCompletionModel, onSuccess, onFail) {
            return apiHelper.requestWrapperWithBody(quest.complete, params, questCompletionModel, onSuccess, onFail);
        }

        function getCreatedByPlayer(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(quest.getCreatedBy, { id: id }, onSuccess, onFail);
        }

        function getOwnedByPlayer(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(quest.getOwnedBy, { id: id }, onSuccess, onFail);
        }

        return {
            CreateQuest: createQuest,
            CompleteQuest: completeQuest,
            GetCreatedByPlayer: getCreatedByPlayer,
            GetOwnedByPlayer: getOwnedByPlayer
        }
    }]);
}())