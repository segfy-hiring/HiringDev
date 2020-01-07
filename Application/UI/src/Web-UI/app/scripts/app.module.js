(function () {
    'use strict';

    /**
     * @name app.youtube.webServices
     * @summary Main module of the application.
     */
    var app = angular.module('app', ['ngMaterial', 'ui.router', 'app.config', 'app.youtube', 'request', 'modal', 'm.alert', 'directive.loading']);

    function runApp($rootScope, ENVIROMENT) {
        $rootScope.appName = ENVIROMENT.projectName;
    }

    function configRoute($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("app/youtube/home");

        $stateProvider
            .state('app', {
                url: '/app',
                abstract: true,
                template: "<ui-view></ui-view>"
            });
    }

    app.config(configRoute)
    app.run(runApp);
})();
