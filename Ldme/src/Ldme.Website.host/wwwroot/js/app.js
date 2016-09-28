(function () {

    function config($stateProvider, $locationProvider, $urlRouterProvider, $qProvider, toastrConfig) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
        $urlRouterProvider.otherwise("/");
        $qProvider.errorOnUnhandledRejections(false);

        $stateProvider
            .state('main', {
                url: '/',
                views: {
                    'navbar': {
                        templateUrl: ''
                    },
                    'main': {
                        templateUrl: 'js/view/main/main.template.html'
                    },
                    'footer': {
                        templateUrl: 'js/view/footer/footer.template.html'
                    }
                }
            });
        //.state()

        angular.extend(toastrConfig, {
            preventOpenDuplicates: true,
            progressBar: true,
            timeOut: 1200,
            extendedTimeOut: 1200
        });
    }

    var run = [
//        'appInfo', function () {
//
//        }
    ];

    angular.module('ldme', ['ui.router', 'ngResource', 'ngAnimate', 'ngMessages', 'ngCookies', 'toastr'])
        .constant('ldmeConst', {})
        .config(config);
    //.run(run);
})()