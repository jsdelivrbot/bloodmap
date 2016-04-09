angular.module('BloodMap', ['ui.router',
    'ngMessages',
    'smart-table',
    'angularModalService'
    ])
.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider,$urlRouterProvider) {

    $urlRouterProvider.otherwise('/login');

    $stateProvider.state('login', {
        url: '/login',
        templateUrl: 'partials/login.html'
    });

    $stateProvider.state('myaccount', {
        url: '/myaccount',
        templateUrl: 'partials/myaccounts.html'
    });

    
}]);