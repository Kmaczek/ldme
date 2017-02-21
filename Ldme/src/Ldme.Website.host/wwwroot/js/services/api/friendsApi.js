(function () {
    angular.module('ldme').factory('friendsApi', function ($resource, ldmeConfig, apiHelper) {

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
            return apiHelper.requestWrapperGET(friends.getAll, { id: id }, onSuccess, onFail);
        }

        return {
            GetAll: getAll
        }
    });

}())