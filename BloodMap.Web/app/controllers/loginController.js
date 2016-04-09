(function () {
    'use strict';

    angular.module('jadeSampleApp')
    .controller('loginController', ['$scope', '$state','$passportService', function ($scope, $state, $passportService) {

        
        var vm = this;

        vm.login = function () {
           
            console.log("gooo");
            //debugger;
            var response = $passportService.getNewToken("abc@ass.com", "123123");
            console.log(response);
            
            if (response) {
                //debugger;
                response.then(function (res) {
                 
                    if (res.status === true) {
                        console.log("Login success " + res.status);
                        $state.go('myaccount');
                    } else {
                        console.log("login failed");
                    }
                }, function (error) {
                        console.log("LOGIN FAILED==>", error);
                        
                    });
                }

            //$state.go('myaccount');

        };
    }]);
})();