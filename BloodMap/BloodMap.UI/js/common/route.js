angular.module('bloodMapApp', ['ui.router',
'ngMaterial','ngMessages'])
.config(['$stateProvider', '$urlRouterProvider', '$mdThemingProvider', function ($stateProvider, $urlRouterProvider, $mdThemingProvider) {
    $urlRouterProvider.otherwise('/home');

    $stateProvider.state('home', {
        url: '/home',
        templateUrl: 'partials/bloodMapHome.html'
    });

    $mdThemingProvider.theme('default')
    .primaryPalette('light-green');
}]);