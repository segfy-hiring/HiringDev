(function () {

    angular.module('modal', []).service('modalService', modalService);

    function modalService($mdDialog) {

        function _instanceModalBinding(modalTemplate, parameters, modalParams) {
            var parentEl = angular.element(document.body);

            var defaultConfig = {
                parent: parentEl,
                template: modalTemplate,
                clickOutsideToClose: true,
                escapeToClose: true,
                controller: function (resolve) {
                    this.$value = resolve;
                },
                controllerAs: '$ctrl',
                bindToController: true,
                locals: {
                    'resolve': parameters
                }
            }

            angular.extend(defaultConfig, modalParams);

            return $mdDialog.show(defaultConfig);
        }

        function _instanceModalBinding(modalTemplate, parameters, modalParams) {
            var parentEl = angular.element(document.body);

            var defaultConfig = {
                parent: parentEl,
                template: modalTemplate,
                clickOutsideToClose: true,
                escapeToClose: true,
                controller: function (resolve) {
                    this.$value = resolve;
                },
                controllerAs: '$ctrl',
                bindToController: true,
                locals: {
                    'resolve': parameters
                }
            }

            angular.extend(defaultConfig, modalParams);

            return $mdDialog.show(defaultConfig);
        }

        var service = {
            instanceModalBinding: _instanceModalBinding
        };

        return service;
    }
})();
