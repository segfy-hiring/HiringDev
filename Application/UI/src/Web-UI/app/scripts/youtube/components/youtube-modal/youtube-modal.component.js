(function () {
    "use strict";

    angular.module('app.youtube').component("youtubeModal", {
        templateUrl: "scripts/youtube/components/youtube-modal/youtube-modal.template.html",
        bindings: {
            value: "<"
        },
        controller: function ($mdDialog) {
            var ctrl = this;

            this.$onInit = function () {
                console.log(ctrl);
                ctrl.model = this.value.value;
                var myEl = angular.element(document.querySelector('#youtubeVideo'));
                myEl.append(ctrl.model.embedHtml);

                var iframe = angular.element('#youtubeVideo > iframe');
                iframe.removeAttr('width');
                iframe.attr('height', '320px;');
                iframe.attr('style', 'width: 100%');
            }

            this.close = function () {
                $mdDialog.hide();
            };
        }
    });
})();
