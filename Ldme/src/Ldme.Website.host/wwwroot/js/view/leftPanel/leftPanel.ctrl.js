﻿(function () {
    "use strict";

    angular.module('ldme')
        .controller('leftPanelCtrl', function ($state, appState, $scope) {
            var ctrl = this;
            this.msg = $scope;
            this.currentChild = null;

            (function initialize() {
                $scope.$watch('underlying',
                    function(newVal, oldVal) {
                        var sth = $scope;
                    });
            })();

            this.registerUnderlying = function (underlyingScope) {
                ctrl.currentChild = underlyingScope;

                underlyingScope.$on('$destroy', function () {
                    ctrl.currentChild = null;
                });
            }

            this.closePanel = function() {
                this.currentChild = null;
            }

            this.isPanelHidden = function() {
                return this.currentChild === null;
            }
        });
}());