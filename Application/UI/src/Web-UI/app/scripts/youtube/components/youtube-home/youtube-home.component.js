(function () {
    "use strict";

    angular.module('app.youtube').component("youtubeHome", {
        templateUrl: "scripts/youtube/components/youtube-home/youtube-home.template.html",
        bindings: {},
        controller: function ($state, ENVIROMENT, youtubeResource, SweetAlertService, modalService) {
            var ctrl = this;
            ctrl.selectedType = 0;
            ctrl.selectedSearch = '';

            this.$onInit = function () {
                ctrl.search = '';
                ctrl.result = {};
            }

            this.searchVideoYoutube = function () {
                if (ctrl.search == "" || ctrl.search == undefined) {
                    SweetAlertService.info("Please, type a valid text to search");
                    return;
                }
                ctrl.result = {};
                ctrl.selectedType = 2;
                ctrl.selectedSearch = ctrl.search;

                youtubeResource.searchYoutube(ctrl.search, 2, '').then(function (data) {
                    ctrl.result = data;
                });
            }

            this.searchChannelYoutube = function () {
                if (ctrl.search == "" || ctrl.search == undefined) {
                    SweetAlertService.info("Please, type a valid text to search");
                    return;
                }
                ctrl.result = {};
                ctrl.selectedType = 1;
                ctrl.selectedSearch = ctrl.search;

                youtubeResource.searchYoutube(ctrl.search, 1, '').then(function (data) {
                    ctrl.result = data;
                });
            };

            this.previousPage = function (previousPage) {
                ctrl.result = {};
                ctrl.search = ctrl.selectedSearch;
                youtubeResource.searchYoutube(ctrl.selectedSearch, ctrl.selectedType, previousPage).then(function (data) {
                    ctrl.result = data;
                });
            };

            this.nextPage = function (nextPage) {
                ctrl.result = {};
                ctrl.search = ctrl.selectedSearch;
                youtubeResource.searchYoutube(ctrl.selectedSearch, ctrl.selectedType, nextPage).then(function (data) {
                    ctrl.result = data;
                });
            };

            this.showDetails = function (item) {

                if (ctrl.selectedType == 2) {
                    var result = youtubeResource.getVideoDetail(item.videoId).then(function (data) {
                        return data;
                    }).then(function (data) {
                        modalService.instanceModalBinding("<md-dialog flex='30'><youtube-modal value='$ctrl.$value'></youtube-modal></md-dialog>",
                        {
                            value: data
                        }).then(function (result) { });
                    });
                }
                else {

                    youtubeResource.getChannelDetail(item.channelId).then(function (data) {
                        return data;
                    }).then(function (data) {
                        modalService.instanceModalBinding("<md-dialog flex='30'><youtube-modal value='$ctrl.$value'></youtube-modal></md-dialog>",
                        {
                            value: data
                        }).then(function (result) { });
                    });
                }
            };
        }
    });
})();
