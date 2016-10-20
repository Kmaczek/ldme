(function () {
    angular.module('ldme').factory('playerApi', ['$resource', 'ldmeConfig', 'apiHelper', function ($resource, ldmeConfig, apiHelper) {

        var apiUrl = ldmeConfig.apiUrl + '/player';

        var player = $resource(apiUrl, null,
        {
            get: {
                method: 'GET',
                withCredentials: true,
                url: apiUrl + '/:id'
            },

            search: {
                method: 'GET',
                url: apiUrl + '/search/:query',
                isArray: true
            }

        });

        function getPlayerData(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(player.get, { id: id }, onSuccess, onFail);
        }

        function findPlayers(query, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(player.search, { query: query }, onSuccess, onFail);
        }

        return {
            GetPlayer: getPlayerData,
            FindPlayers: findPlayers
        }
    }]);

}())