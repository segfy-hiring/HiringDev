(function () {

    angular
        .module('m.alert')

        .service('SweetAlertService', ['$rootScope', function ($rootScope) {

             /**
             * @name error
             * @summary Show error Message
             * @param {Object} params - Swal config
             * @param {boolean} removeButtons - Indicate if should remove the buttons
            */
            var _error = function (params, removeButtons) {

                var defaultConfig = {
                    title: 'Error',
                    text: 'An error ocurred!',
                    icon: 'error',
                    closeOnClickOutside: false,
                    timer: null,
                    button: "Ok"
                }

                return swalIt(params, defaultConfig, removeButtons);
            }

            /**
             * @name success
             * @summary  Show success Message
             * @param {Object} params - Swal config
             * @param {boolean} removeButtons - Indicate if should remove the buttons
            */
            var _success = function (params, removeButtons) {
                var defaultConfig = {
                    title: 'Success',
                    text: 'Operation concluded with success!',
                    icon: 'success',
                    closeOnClickOutside: false,
                    timer: null,
                    button: "Ok"
                }

                return swalIt(params, defaultConfig, removeButtons);
            }

            /**
             * @name info
             * @summary Show info Message
             * @param {Object} params - Swal config
             * @param {boolean} removeButtons - Indicate if should remove the buttons
            */
            var _info = function (params, removeButtons) {

                var defaultConfig = {
                    title: 'Info',
                    icon: 'info',
                    text: params,
                    closeOnClickOutside: false,
                    timer: null,
                    button: "Ok"
                }

                return swalIt(params, defaultConfig, removeButtons);
            }

            /**
             * @name warning
             * @summary Show warning Message
             * @param {Object} params - Swal config
             * @param {boolean} removeButtons - Indicate if should remove the buttons
            */
            var _warning = function (params, removeButtons) {

                var defaultConfig = {
                    title: 'Warning',
                    icon: 'warning',
                    closeOnClickOutside: false,
                    timer: null,
                }

                return swalIt(params, defaultConfig, removeButtons);
            }

            /**
             * @name empty
             * @summary Must pass the entire configuration
             * @param {Object} params - Swal config
            */
            var _empty = function (params) {
                var defaultConfig = {
                    closeOnClickOutside: false
                };

                return swalIt(params, defaultConfig, false);
            }

            /**
             * @name swalIt
             * @summary Show delete Message
             * @param {Object} params - The parameters
             * @param {Object} defaultConfig - Default configuration
             * @param {boolean} removeButtons - Indicate if should remove the buttons
            */
            function swalIt(swalParams, defaultConfig, removeButtons) {

                if (!angular.isUndefined(swalParams) && swalParams.hasOwnProperty("exception") && swalParams.exception.hasOwnProperty("Message") && swalParams.exception.Message.hasOwnProperty("Id")) {
                    swalParams["title"] = (swalParams.exception.Message.Id);
                }

                if (removeButtons) {
                    delete defaultConfig.button;
                    delete defaultConfig.buttons;
                    defaultConfig.buttons = false;
                }

                angular.extend(defaultConfig, swalParams);

                return swal(defaultConfig).then(function (isConfirm) {
                    $rootScope.$evalAsync();

                    if (!isConfirm) {
                        throw isConfirm;
                    }

                    return isConfirm;
                });
            }

            this.error = _error;
            this.success = _success;
            this.info = _info;
            this.warning = _warning;
            this.empty = _empty;
        }]);
})();
