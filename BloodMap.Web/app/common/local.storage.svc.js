(
function () {
    'use strict';

    angular.module('BloodMap')
    .factory('$clientLocalStorage', clientLocalStorage);

    clientLocalStorage.$inject = ['$window', '$rootScope'];

    function clientLocalStorage($window, $rootScope) {
        return {
            getAll: getAll,
            getAllKeys: getAllKeys,
            deleteAll: deleteAll,
            setValue: setValue,
            getValue: getValue,
            deleteValue: deleteValue,
            setObject: setObject,
            getObject: getObject,
            deleteObject: deleteObject
        };

        function getAll() {
            var i = 0, valueList = {}, sKey;
            for (; sKey = $window.localStorage.key(i) ; i++) {
                valueList[sKey] = $window.localStorage.getItem(sKey);
            }
            return valueList;
        }

        function getAllKeys() {
            var i = 0, valueList = [], sKey;
            for (; sKey = $window.localStorage.key(i) ; i++) {
                valueList.push(sKey);
            }
            return valueList;
        }

        function deleteAll() {
            var i = 0, sKey;
            for (; sKey = $window.localStorage.key(i) ; i++) {
                if (!("HSStore:" + $rootScope.ApplicationInstanceKey == sKey)) {
                    $window.localStorage.removeItem(sKey);
                }
            }
        }

        function setValue(key, value) {
            if (('localStorage' in window) && window['localStorage'] !== null) {
                $window.localStorage["HSStore:" + key] = value;
            }
            else throw "LocalStorage is not available to store value";
        }

        function getValue(key, defaultValue) {
            if (('localStorage' in window) && window['localStorage'] !== null) {
                return $window.localStorage["HSStore:" + key] || defaultValue;
            } else {
                return defaultValue;
            }
        }

        function deleteValue(key) {
            if (('localStorage' in window) && window['localStorage'] !== null) {
                return $window.localStorage.removeItem("HSStore:" + key);
            }
        }

        function setObject(key, value) {
            if (('localStorage' in window) && window['localStorage'] !== null) {
                $window.localStorage["HSStore:" + key] = JSON.stringify(value);
            }
            else throw "LocalStorage is not available to store object";
        }

        function getObject(key) {
            if (('localStorage' in window) && window['localStorage'] !== null) {
                return JSON.parse($window.localStorage["HSStore:" + key] || '{}');
            } else {
                return {};
            }
        }

        function deleteObject(key) {
            if (('localStorage' in window) && window['localStorage'] !== null) {
                return $window.localStorage.removeItem("HSStore:" + key);
            }
        }
    }
}
)();