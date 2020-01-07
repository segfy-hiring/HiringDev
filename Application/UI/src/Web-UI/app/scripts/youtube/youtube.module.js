(function () {
    "use strict";

    angular.module('app.youtube', ['ui.router']).config(function ($stateProvider) {
        $stateProvider
            .state({
                name: 'app.youtube',
                url: "/youtube",
                abstract: true
            })
            .state({
                name: 'app.youtube.home',
                url: "/home",
                component: "youtubeHome"
            })
    });
})();
