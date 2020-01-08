(function () {
    "use strict";

    angular.module('request')
        .service('RequestService', function ($http, ENVIROMENT) {

            var self = this;

            function _adjustUrl(url) {
                if (url.indexOf("http://") === -1 && url.indexOf("https://") === -1) {
                    url = ENVIROMENT.apiEndpoint + url;
                }

                return url;
            }

            function _adjustHeader(headers) {
                return headers;
            }

            this.parseResponse = function (response, originalResponse) {
                var data = response.data;
                if (response.status === 200) {

                    if (originalResponse) {
                        return data;
                    } else {
                        if (data.Object !== undefined && data.Status === 1) {
                            return data.Object;
                        } else if (data.value === null || data.value === undefined) {
                            return data;
                        } else {
                            return data.value;
                        }
                    }
                } else {
                    throw response;
                }
            }

            this.catchResponse = function (err) {
                console.error(err);
                throw err;
            }

            this.downloadResponse = function (response, fileName) {
                var headers = response.headers();

                var contentType = headers['content-type'];

                var blob = new Blob([response.data], { type: contentType });
                var url = window.URL.createObjectURL(blob);

                var linkElement = document.createElement('a');

                linkElement.setAttribute('href', url);
                linkElement.setAttribute("download", fileName);

                var clickEvent = new MouseEvent("click", {
                    "view": window,
                    "bubbles": true,
                    "cancelable": false
                });

                linkElement.dispatchEvent(clickEvent);
            }

            /**
             * @ngdoc function
             * @name get
             * @summary Serviço de request HTTP GET
             */
            this.get = function (url, params, originalResponse) {
                return $http({ method: "GET", url: _adjustUrl(url), params: params, headers: _adjustHeader({}) }).then(function (data) { return self.parseResponse(data, originalResponse); }).catch(self.catchResponse);
            }

            /**
             * @ngdoc function
             * @name post
             * @summary Serviço de request HTTP POST
             */
            this.post = function (url, data, originalResponse) {
                return $http({ method: "POST", url: _adjustUrl(url), data: data, headers: _adjustHeader({ 'Content-Type': "application/json;odata=verbose" }) }).then(function (data) { return self.parseResponse(data, originalResponse); }).catch(self.catchResponse);
            }

            /**
             * @ngdoc function
             * @name put
             * @summary Serviço de request HTTP PUT
             */
            this.put = function (url, data, originalResponse) {
                return $http({ method: "PUT", url: _adjustUrl(url), data: data, headers: _adjustHeader({ 'Content-Type': "application/json;odata=verbose" }) }).then(function (data) { return self.parseResponse(data, originalResponse); }).catch(self.catchResponse);
            }

            /**
             * @ngdoc function
             * @name patch
             * @summary Serviço de request HTTP PATCH
             */
            this.patch = function (url, data, originalResponse) {
                return $http({ method: "PATCH", url: _adjustUrl(url), data: data, headers: _adjustHeader({ 'Content-Type': "application/json;odata=verbose" }) }).then(function (data) { return self.parseResponse(data, originalResponse); }).catch(self.catchResponse);
            }

            /**
             * @ngdoc function
             * @name delete
             * @summary Serviço de request HTTP DELETE
             */
            this.delete = function (url, params, originalResponse) {
                return $http({ method: "DELETE", url: _adjustUrl(url), params: params, headers: _adjustHeader({ 'Content-Type': "application/json;odata=verbose" }) }).then(function (data) { return self.parseResponse(data, originalResponse); }).catch(self.catchResponse);
            }

            /**
             * @ngdoc function
             * @name download
             * @summary Service to download
             */
            this.download = function (fileName, requestParams, ignoreHeaders) {

                var defaultConfig = {
                    method: "GET",
                    responseType: 'arraybuffer',
                    headers: ignoreHeaders ? undefined : _adjustHeader({})
                }

                angular.extend(defaultConfig, requestParams);

                return $http(defaultConfig).then(function (data) { self.downloadResponse(data, fileName) }).catch(self.catchResponse);
            }
        })
})();
