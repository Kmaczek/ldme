(function () {
    "use strict";

    angular.module('ldme')
        .controller('leftPanelCtrl', function ($state, appState, $scope) {
            var ctrl = this;
            this.msg = $scope;
            this.currentChild = null;
            this.hidden = true;

            (function initialize() {
                $scope.$watch('underlying',
                    function(newVal, oldVal) {
                        var sth = $scope;
                    });
            })();

            this.registerUnderlying = function (underlyingScope) {
                ctrl.currentChild = underlyingScope;
                this.hidden = false;

                underlyingScope.$on('$destroy', function () {
                    ctrl.currentChild = null;
                });
            }

            this.closePanel = function () {
                this.currentChild = null;
                $state.go($state.current.data.closeState);
            }

            this.isPanelHidden = function() {
                return this.currentChild === null || this.hidden;
            }

            this.togglePanel = function() {
                this.hidden = !this.hidden;
            }
        });
}());