(
function () {
    'use strict';

    angular.module('BloodMap')
    .factory('$passportService', passportService);

    passportService.$inject = ['$rootScope', '$q', '$injector', '$clientLocalStorage', 'SYSTEM_COMMON_CONFIG'];

    function passportService($rootScope, $q, $injector, $clientLocalStorage, SCC) {
        var $http;

        function clearLocalStorage() {
            $clientLocalStorage.deleteAll();
        }

        function findTokenValidity(data) {
            //debugger;
            var tokenSpec = SCC.Token_Spec;
            var tokenValidity = true;

            for (var i = 0; i < tokenSpec.length; i++) {
                var propertyFound = false;

                Object.getOwnPropertyNames(data).forEach(function (key, index, array) {
                        
                    if (tokenSpec[i] == key) {
                        propertyFound = true;
                        $clientLocalStorage.setValue(key, data[key]);
                    }
                });
                if (propertyFound == false) {
                    tokenValidity = false;
                    break;
                }
            }
            return tokenValidity;
        }

        function passportNewToken(userId,password) {

            var deferred = $q.defer();
            var passportResponse = {
                status: false,
                msg: "Login failed,unspecified error"
            };

            try{
                if (userId === '' || password === '' || userId === undefined || password === undefined) {
                    passportResponse.status = false;
                    passportResponse.msg = 'Username and password can\'t be empty.';
                    deferred.reject(passportResponse);

                }

                clearLocalStorage();

                $http = $http || $injector.get('$http');
               
                $http.post(
                    SCC.apiBaseUrl+SCC.commonApi+SCC.apiPrefix.login,
                    'username='+encodeURIComponent(userId)+
                    '&password='+encodeURIComponent(password)+
                    '&grant_type=' + encodeURIComponent(SCC.GrantType),{
                        headers:{
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    })
                    .success(function (data, status, header, config) {
                        //debugger;
                        var token_validity = findTokenValidity(data);
                        
                        if (token_validity === true) {
                            passportResponse.status = true;
                            passportResponse.msg = "Success";
                            //passportResponse.defaultUrl = data.default_url;
                            deferred.resolve(passportResponse);
                        } else {
                            passportResponse.status = false;
                            passportResponse.msg = "Login failed";
                            deferred.reject(passportResponse);
                        }
                    })
                    .error(function (data, status, header, config) {
                        console.log("Error");
                        passportResponse.status=false;
                        //passportResponse.msg=data.error_description;
                        deferred.reject(passportResponse);
                    });
            } catch (error) {
                passportResponse.status = false;
                passportResponse.msg = "Exception";
                deferred.reject(passportResponse);
            }
            return deferred.promise;
        }

        function passportTokenRenewal() {

            var deferred = $q.defer();
            var passportRenewResponse = {
                status: false,
                msg: "Token refresh failed"
            };

            try{
                var refreshToken = $clientLocalStorage.getValue(SCC.Refresh_Token);
                var grantType = SCC.GrantType_RenewToken;

                //check for null and undefined
                if (refreshToken === '' || grantType === '' || refreshToken === undefined || grantType === undefined) {
                    passportRenewResponse.status = false;
                    passportRenewResponse.msg = "Token refresh specifications are invalid";
                    deferred.reject(passportRenewResponse);
                }

                $http = $http || $injector.get($http);
                $http.post(
                     SCC.apiBaseUrl + SCC.commonApi + SCC.apiPrefix.login +
                    'refresh_token=' + encodeURIComponent(refreshToken) +
                    '&grant_type=' + encodeURIComponent(SCC.GrantType, {
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    }))
                .success(function (data, status, header, config) {
                    var token_validity = findTokenValidity(data);

                    if (token_validity === true) {
                        passportRenewResponse.status = true;
                        passportRenewResponse.msg = "Success";
                        //passportRenewResponse.defaultUrl = data.default_url;
                        deferred.resolve(passportRenewResponse);
                    } else {
                        passportRenewResponse.status = false;
                        passportRenewResponse.msg = "Login failed";
                        deferred.reject(passportRenewResponse);
                    }
                  })
                 .error(function(data,status,header,config){
                        passportResponse.status=false;
                        passportResponse.msg=data.error_description;
                        deferred.reject(passportResponse);
                    });

            } catch (error) {
                passportRenewResponse.status = false;
                passportRenewResponse.msg = "Token refresh exception";
                deferred.reject(passportRenewResponse);
            }
           return deferred.promise;
        }

        return {
            getNewToken: passportNewToken,
            getRenewedToken: passportTokenRenewal,
            clearClientLocalStorage: clearLocalStorage
        };
    }
}
)();