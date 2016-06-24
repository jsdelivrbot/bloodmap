(function () {
    'use strict';

    angular.module('bloodMapApp')

    .controller('bloodMapHomeCtrl',bloodMapHomeCtrl);
    bloodMapHomeCtrl.$inject=['$scope', '$state'];
    function bloodMapHomeCtrl($scope, $state) {
        var vm = this;
        vm.loginBloodMap = function () {

        }
    };

})();