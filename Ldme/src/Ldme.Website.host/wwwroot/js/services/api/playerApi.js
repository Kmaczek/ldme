(function () {
    angular.module('ldme').factory('playerApi', function ($resource, ldmeConfig, apiCore) {
        var playerApi = angular.extend({}, apiCore);
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
            return playerApi.requestWrapperGET(player.get, { id: id }, onSuccess, onFail);
        }

        function findPlayers(query, onSuccess, onFail) {
            return playerApi.requestWrapperGET(player.search, { query: query }, onSuccess, onFail);
        }

        playerApi.GetPlayer = getPlayerData;
        playerApi.FindPlayers = findPlayers;

        return playerApi;
    });

}())