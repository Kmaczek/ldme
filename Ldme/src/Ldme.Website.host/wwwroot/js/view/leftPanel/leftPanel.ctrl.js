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
                $scope.$watch(function () {
                    return ctrl.currentChild;
                },
                function (newVal) {
                    if (!newVal) {
                        ctrl.closed = true;
                    }
                });
            })();

            this.registerUnderlying = function (underlyingScope) {
                ctrl.currentChild = underlyingScope;
                ctrl.scopeId = underlyingScope.$id;
                this.hidden = false;
                this.closed = false;

                underlyingScope.$on('$destroy', function (eventArgs) {
                    function isScopeTheSame() {
                        return ctrl.scopeId === eventArgs.currentScope.$id;
                    }

                    if (isScopeTheSame()) {
                        ctrl.currentChild = null;
                        ctrl.closed = true;
                    }
                });
            }

            this.closePanel = function () {
                // this will trigger 'destroy'
                $state.go($state.current.data.closeState);
            }

            this.isPanelHidden = function () {
                return (this.currentChild === null || this.hidden);
            }

            this.togglePanel = function () {
                this.hidden = !this.hidden;
            }
        });
}());