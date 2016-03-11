(function () {
    'use strict';

    angular.module('BloodMap')
    .controller('searchController', function ($scope) {
        //alert("yes");
        $scope.bloodInfo = "AB+";
        $scope.searchData = "Pune";
        $scope.gPlace;
        
        var mapOptions = {
            zoom: 4,
            center: new google.maps.LatLng(25, 80),
            mapTypeId: google.maps.MapTypeId.TERRAIN
        }
        var options = {
            types: [],
            componentRestrictions: {}
        };

        $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);
        
        var input = document.getElementById('searchText');
        console.log(input);
        $scope.map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
        var autocomplete = new google.maps.places.Autocomplete(input);
        autocomplete.bindTo('bounds', $scope.map);

        $scope.infowindow = new google.maps.InfoWindow();
        var marker = new google.maps.Marker({
            map: $scope.map,
            anchorPoint: new google.maps.Point(0, -29)
        });
        
        autocomplete.addListener('place_changed', function () {
            console.log("yess");
            $scope.infowindow.close();
            marker.setVisible(false);
            var place = autocomplete.getPlace();
            console.log(place);
            if (!place.geometry) {
                window.alert("Autocomplete's returned place contains no geometry");
                return;
            }

            // If the place has a geometry, then present it on a map.
            if (place.geometry.viewport) {
                $scope.map.fitBounds(place.geometry.viewport);
            
            } else {
                $scope.map.setCenter(place.geometry.location);
                $scope.map.setZoom(17);  // Why 17? Because it looks good.
            }

            marker.setIcon(({
                url: place.icon,
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(35, 35)
            }));
            marker.setPosition(place.geometry.location);
            marker.setVisible(true);
            var address = '';
            if (place.address_components) {
                address = [
                  (place.address_components[0] && place.address_components[0].short_name || ''),
                  (place.address_components[1] && place.address_components[1].short_name || ''),
                  (place.address_components[2] && place.address_components[2].short_name || '')
                ].join(' ');
            }
            console.log($scope.infowindow)
            $scope.infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
            $scope.infowindow.open($scope.map, marker);
        });
       
    });
}
)();