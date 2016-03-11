(
function () {
    angular.module('BloodMap')
    .directive('myMap', function () {

        var link = function (scope,element,attrs) {
            var map, infoWindow;

            var markers = [];

            // map config
            var mapOptions = {
                center: new google.maps.LatLng(18.52, 73.85),
                zoom: 10,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                scrollwheel: false
            };
           
            // init the map
            function initMap() {
                if (map === void 0) {
                    console.log(element[0]);
                    map = new google.maps.Map(element[0], mapOptions);
                }
            }
            // show the map and place some markers
            initMap();
           
            //watch
            scope.$watch("searchText", function (oldvalue, newValue) {
                console.log("Plzz : " + oldvalue+" >> "+newValue);
            });
            
            var input = scope.searchText;
            console.log("input : " + input);
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
            var autocomplete = new google.maps.places.Autocomplete(input);
            autocomplete.bindTo('bounds', map);
            
            //scope.gPlace = new google.maps.places.Autocomplete(element[0], options);
            //google.maps.event.addListener(scope.gPlace, 'place_changed', function () {
            //    scope.$apply(function () {
            //        model.$setViewValue(element.val());
            //    });
            //});
            //map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

            //var searchBox = new google.maps.places.SearchBox((input));
        };

        var config = {
            restrict: 'A',
            replace: true,
            scope: { searchText: '=' },
            template: '<div id="gmaps" class="container"></div>',
            link:link
        };

        return config;
    })

    //.directive('googleplace', function() {
    //    return {
    //        require: 'ngModel',
    //        link: function(scope, element, attrs, model) {
    //            var options = {
    //                types: [],
    //                componentRestrictions: {}
    //            };
                
    //            scope.gPlace = new google.maps.places.Autocomplete(element[0], options);
    //            console.log("scope.gPlace : " + scope.gPlace);
    //            console.log(" >>> " + element.val());
    //            google.maps.event.addListener(scope.gPlace, 'place_changed', function() {
    //                scope.$apply(function() {
    //                    model.$setViewValue(element.val());                
    //                });
    //            });
    //        }
    //    };
    //});
}
)();