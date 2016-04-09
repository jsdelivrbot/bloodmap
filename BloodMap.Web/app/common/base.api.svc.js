(
function () {
    'use strict';

    angular.module('BloodMap')
    .factory('baseApiService', baseApiService);

    baseApiService.$inject = ['$resource', '$q', 'SYSTEM_COMMON_CONFIG'];

    function baseApiSevice($resource, $q, SCC) {

        var baseApiServiceDefinition = function(){
            this.apiBaseUrl = SCC.apiBaseUrl;
            this.apiPrefix = SCC.apiPrefix;
            this.resources = this.resources || {};
        };

        baseApiServiceDefinition.prototype.addApi = function (module,name,url,paramDefaults,actions) {
            if (module === null || module == undefined || module == "") {
                throw "MODULE name should be provided";
            }

            if (name === null || name == undefined || name == "") {
                throw "API name should be provided";
            }

            if (url == null || url == undefined || url == "") {
                throw "API Url should be provided";
            }

            this.resources.push({
                res_module: module,
                res_name: name,
                resource:$resource(this.apiBaseUrl+this.apiPrefix[module]+url,paramDefaults,actions)
            });
        }

        baseApiServiceDefinition.prototype.getApi = function (name) {

            for (var i = 0; i < this.resources.length; i++) {
                var res = this.resources[i];

                if (res.hasOwnProperty("res_name")) {
                    if (res.res_name == name) {
                        return res.resource;
                    }
                }
            }
            throw "Unable to find specified API name";
        }
        
        baseApiServiceDefinition.prototype.get = function (apiName,defaultParams,actions) {

            var deferred = $q.defer();
            var api = this.getApi(apiName);

            if (api) {

                api.get(defaultParams, actions,
                    function (response) {
                        deferred.resolve(response);
                    },
                    function (error) {
                        deferred.reject(error);
                    });
            } else {

                deferred.reject({
                    code: 404,
                    response: "API Exception"
                });
            }
            return deferred.promise;
        }

        baseApiServiceDefinition.prototype.getAll = function (apiName,defaultParams,actions) {

            var deferred = $q.defer();
            var api = this.getApi(apiName);

            if (api) {

                api.query(defaultParams,actions,
                    function (response) {
                        deferred.resolve(response);
                    },
                    function (error) {
                        deferred.reject(error);
                    }
                    );
            } else {
                deferred.reject({
                    code: 404,
                    response: "API Exception"
                });
            }
            return deferred.promise;
        }

        baseApiServiceDefinition.prototype.post = function (apiName, defaultParams, actions) {

            var deferred = $q.defer();
            var api = this.getApi(apiName);

            if (api) {

                api.post(defaultParams, actions,
                    function (response) {
                        deferred.resolve(response);
                    },
                    function (error) {
                        deferred.reject(error);
                    });

            } else {
                deferred.reject({
                    code: 404,
                    response: "API Exception"
                });
            }

            return deferred.promise;

        }

        baseApiServiceDefinition.prototype.put = function (apiName,defaultParams,actions) {

            var deferred = $q.defer();
            var api = this.getApi(apiName);
            if (api) {
                api.put(
                    defaultParams,
                    actions,
                    function (response) {
                        // console.log("PUT:SUCCESS:" + apiName + ":", response);
                        if (navigator.userAgent.toLowerCase().indexOf('chrome') > -1) {
                            console.table(response);
                        } else {
                            // console.log(response);
                        }
                        deferred.resolve(response);
                    },
                    function (error) {
                        // console.log("ERROR:" + apiName + ":", error);
                        deferred.reject(error);
                    });
            } else {
                deferred.reject({
                    code: 404,
                    response: "API EXCEPTION"
                })
            }
            return deferred.promise;
        }

        baseApiServiceDefinition.prototype.delete = function (apiName,defaultParams,actions) {

            var deferred = $q.defer();
            var api = this.getApi(apiName);

            if (api) {
                api.delete(defaultParams,actions,
                    function (response) {
                        deferred.resolve(response);
                    },
                    function (error) {
                        deferred.reject(error);
                    });
            } else {
                deferred.reject({
                    code: 404,
                    response: "API Exception"
                });
            }

        }


        return baseApiServiceDefinition;
    }
}
)();