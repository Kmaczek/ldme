(function () {
    angular.module('ldme').factory('valMsg', function () {
        var msgs = [];
        msgs['minlenght'] = function(minLength) {
            return 'Input is to short, need to be at lest ' + minLength + ' characters long';
        }

        return msgs;
    });
}())