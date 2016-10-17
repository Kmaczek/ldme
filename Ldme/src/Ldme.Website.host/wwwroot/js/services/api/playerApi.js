(function () {
    angular.module('ldme').factory('playerApi', ['$resource', 'ldmeConfig', 'apiHelper', function ($resource, ldmeConfig, apiHelper) {

        var apiUrl = ldmeConfig.apiUrl + '/player';

        var player = $resource(apiUrl, null,
        {
            get: {
                method: 'GET',
                withCredentials: true,
                url: apiUrl + '/:id'
            }
        });

        function getPlayerData(id, onSuccess, onFail) {
            return apiHelper.requestWrapperGET(player.get, { id: id }, onSuccess, onFail);
        }

        return {
            GetPlayer: getPlayerData
        }
    }]);

}())