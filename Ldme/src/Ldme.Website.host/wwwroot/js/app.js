﻿(function () {
    // pre load
//    var injector = angular.injector(['ng, ngCookies']);
//    var cookies = injector.get('$cookies');
//    var webConfig = cookies.getObject('ldmeConfig');
    // load appp
    function config($stateProvider, $locationProvider, $urlRouterProvider, $qProvider, toastrConfig) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
        $urlRouterProvider.otherwise("/");
        $qProvider.errorOnUnhandledRejections(false);

        $stateProvider
            .state('root',
                {
                    abstract: true,
                    views: {
                        '': { templateUrl: 'layout.html' },

                        'navbar@root': {
                            templateUrl: 'js/view/navi/navi.template.html'
                        },
                        'main@root': {
                            templateUrl: 'js/view/main/main.template.html'
                        },
                        'footer@root': {
                            templateUrl: 'js/view/footer/footer.template.html'
                        }
                    }
                })
            .state('main',
                {
                    parent: 'root',
                    url: '/'
                })
            .state('player',
                {
                    parent: 'root',
                    url: '/player',
                    views: {
                        'main': {
                            templateUrl: 'js/view/player/player.template.html'
                        }
                    }
                });

        angular.extend(toastrConfig, {
            preventOpenDuplicates: true,
            progressBar: true,
            timeOut: 1200,
            extendedTimeOut: 1200
        });
    }

    var run = [
        '$cookies', function ($cookies) {
            
        }
    ];

    angular.module('ldme', ['ui.router', 'ngResource', 'ngAnimate', 'ngMessages', 'ngCookies', 'toastr'])
//        .constant('ldmeConfig', webConfig)
        .config(config)
        .run(run);
})()