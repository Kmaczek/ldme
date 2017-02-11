(function () {
    "use strict";

    angular.module('ldme')
        .controller('leftPanelCtrl', function ($state, appState, $scope) {
            var ctrl = this;
            this.msg = $scope;
            this.currentChild = null;
            this.hidden = true;
            this.closed = true;

            (function initialize() {
            })();

            this.registerUnderlying = function (underlyingScope) {
                ctrl.currentChild = underlyingScope;
                this.hidden = false;
                this.closed = false;

                underlyingScope.$on('$destroy', function () {
                    ctrl.currentChild = null;
                    ctrl.closed = true;
                });
            }

            this.closePanel = function () {
                // this will trigger 'destroy'
                $state.go($state.current.data.closeState);
            }

            this.isPanelHidden = function() {
                return (this.currentChild === null || this.hidden);
            }

            this.togglePanel = function() {
                this.hidden = !this.hidden;
            }
        });
}());