(function () {
    angular.module('ldme').factory('friendsApi', function ($resource, ldmeConfig, apiCore) {
        var friensApi = angular.extend({}, apiCore);
        var apiUrl = ldmeConfig.apiUrl + '/friend';

        var friends = $resource(apiUrl, null,
        {
            getAll: {
                method: 'GET',
                withCredentials: true,
                url: apiUrl + '/:id',
                isArray: true
            }

        });

        function getAll(id, onSuccess, onFail) {
            return friensApi.requestWrapperGET(friends.getAll, { id: id }, onSuccess, onFail);
        }

        friensApi.GetAll = getAll;

        return friensApi;
    });

}())