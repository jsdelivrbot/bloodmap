angular.module('BloodMap', [
    'ngRoute'
    
    
])
//.config(['$urlRouterProvider', '$stateProvider', '$locationProvider', function ($urlRouterProvider, $stateProvider, $locationProvider) {
//    $locationProvider.html5Mode(true);

//    $urlRouterProvider.otherwise('/search');
//    $stateProvider
//     .state('search', {
//         url: '/search',
//         templateUrl: 'partials/search.html'
//     });

//    $stateProvider
//    .state('register', {
//        url: '/register',
//        templateUrl: 'partials/register.html'
//    });

   
//}]);
.config(['$routeProvider', function ($routeProvider) {
    console.log($routeProvider);
    $routeProvider
    .when('/search', {
        templateUrl: "partials/search.html",
        controller: "searchController"
    })
    .when('/load', {
        templateUrl: "partials/register.html",
        controller: "registrationController"
    })
    .otherwise({ redirectTo: "/search" });
}]);