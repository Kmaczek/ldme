(function () {
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
                            templateUrl: 'js/view/navi/navi.tmpl.html'
                        },
                        'main@root': {
                            templateUrl: 'js/view/main/main.tmpl.html'
                        },
                        'footer@root': {
                            templateUrl: 'js/view/footer/footer.tmpl.html'
                        },
                        'lpanel@root': {
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
                    abstract: true,
                    parent: 'root',
                    views: {
                        'main@root': {
                            templateUrl: 'js/view/player/player.tmpl.html'
                        }
                    }
                })
            .state('profile',
                {
                    parent: 'player',
                    url: '/player'
                })
            .state('addQuest',
                {
                    parent: 'player',
                    url: '/player/addQuest',
                    views: {
                        'lpanel@root': {
                            templateUrl: 'js/view/addQuest/addQuest.tmpl.html'
                        }
                    },
                    data: {
                        closeState: 'profile'
                    }
                })
            .state('friends',
                {
                    parent: 'root',
                    url: '/friends',
                    views: {
                        'main': {
                            templateUrl: 'js/view/friends/friends.tmpl.html'
                        }
                    }
                })
            .state('register',
            {
                parent: 'root',
                url: '/user/registration',
                views: {
                    'main': {
                        templateUrl: 'js/view/register/register.tmpl.html'
                    }
                }
            });

        angular.extend(toastrConfig, {
            allowHtml: true,
            preventOpenDuplicates: true,
            progressBar: true,
            timeOut: 1200,
            extendedTimeOut: 1200
        });
    }

    var run = function ($rootScope, $state, $cookies) {
//        $rootScope.$on('$stateChangeStart',
//            function (event, toState) {
//                if (toState.data) {
//                    toState.data.prev = $state.current.name;
//                }
//                var greeting = toState.data.customData1 + " " + toState.data.customData2;
//                console.log(greeting);
//
//                // Would print "Hello World!" when 'parent' is activated
//                // Would print "Hello UI-Router!" when 'parent.child' is activated
//            });
    };

    angular.module('ldme', ['ui.router', 'ui.bootstrap', 'ngResource', 'ngAnimate', 'ngMessages', 'ngCookies', 'toastr', 'angularSpinners'])
//        .constant('ldmeConfig', webConfig)
        .config(config)
        .run(run);
})()