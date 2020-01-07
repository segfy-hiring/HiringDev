(function () {
    'use strict';

    angular.module('request')
        .factory('BaseResource', BaseResource);

    /**
     * @ngdoc service
     * @summary The base resource for the app.
     * @param {Object} RequestService - The service to call the API
    **/
    function BaseResource(RequestService) {
        return function (options) {

            /**
            * @ngdoc property
            * @name _url
            * @summary The odata URL
            */
            let _url = options.url;

            /**
            * @ngdoc Method
            * @name _getAll
            * @summary Gets the full list of         
            */
            let _getAll = () => {
                return RequestService.get(_url, {});
            }

            /**
           * @ngdoc Method
           * @name _getAll
           * @summary Gets the object 
           */
            let _get = (url, params) => {
                return RequestService.get(url, params);
            }

            /**
             * @ngdoc Method
             * @name _post
             * @summary Post the object         
             */
            let _post = (url, params) => {
                return RequestService.post(url, params);
            }

            /**
              * @ngdoc Method
              * @name _put
              * @summary Put the object 
              */
            let _put = (url, params) => {
                return RequestService.put(url, params);
            }

            /**
              * @ngdoc Method
              * @name _patch
              * @summary Patch the object 
              */
            let _patch = (url, params) => {
                return RequestService.patch(url, params);
            }

            /**
            * @ngdoc Method
            * @name _getById
            * @summary Gets a by its id
            * @param {int} id - The id of the that will have it's data retrieved
            */
            let _getById = (id) => {
                return RequestService.get(`${_url}(${id})`, {});
            }

            /**
            * @ngdoc Method
            * @name _save
            * @summary Saves the into the database
            * @param {object} item - The object to be saved
            */
            let _save = (item) => {
                return RequestService.post(_url, item);
            }

            /**
            * @ngdoc Method
            * @name _delete
            * @summary Deletes the from the database by it's id
            * @param {int} id - The id of the to be deleted
            */
            let _delete = (id) => {
                return RequestService.delete(`${_url}(${id})`, {});
            }

            let service = {
                url: _url,
                get: _get,
                post: _post,
                put: _put,
                patch: _patch,
                delete: _delete,
                getAll: _getAll,
                getById: _getById,
                save: _save,
                RequestService: RequestService
            }

            return service;
        }
    }
})();
