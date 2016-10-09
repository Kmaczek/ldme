(function () {
    angular.module('ldme').factory('playerApi', ['$resource', 'ldmeConfig', 'apiHelper', function ($resource, ldmeConfig, apiHelper) {

        var apiUrl = ldmeConfig.apiUrl + "/players";

        var player = $resource(apiUrl, null,
        {
            get: {
                method: 'GET',
                withCredentials: true,
                isArray: true
            }
        });

        function getPlayerByEmail(email, onSuccess, onFail) {
            apiHelper.requestWrapper(player.get, { email: email }, onSuccess, onFail);
        }

        return {
            GetPlayer: getPlayerByEmail
        }
    }]);

}())