(function () {
    angular.module('ldme').factory('questApi', ['$resource', 'ldmeConfig', 'apiHelper', function ($resource, ldmeConfig, apiHelper) {

        var apiUrl = ldmeConfig.apiUrl + '/quest';

        var quest = $resource(apiUrl, null,
        {
            save: {
                method: 'POST',
                withCredentials: true
            }
        });

        function createQuest(questModel, onSuccess, onFail) {
            return apiHelper.requestWrapper(quest.save, questModel, onSuccess, onFail);
        }

        return {
            CreateQuest: createQuest
        }
    }]);
}())