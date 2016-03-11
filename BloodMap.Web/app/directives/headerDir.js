/// <reference path="../partials/header.html" />
/// <reference path="../partials/header.html" />
(function () {
    'use strict';

    angular.module('BloodMap')
    .directive('header', function () {

        var config;
        config = {
            restrict: 'A', //This menas that it will be used as an attribute and NOT as an element. I don't like creating custom HTML elements
            replace: true,
            templateUrl: "partials/header.html",
            controller: ['$scope', '$filter', function ($scope, $filter) {
                // Your behaviour goes here :)
            }]
        };

        return config;
    });
}
)();