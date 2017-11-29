function initMap() {
    var directionsService = new google.maps.DirectionsService;
    var directionsDisplay = new google.maps.DirectionsRenderer;
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 7,
        center: { lat: 41.4993, lng: -81.6944 }
    });
    directionsDisplay.setMap(map);

    var onClickHandler = function () {
        calculateAndDisplayRoute(directionsService, directionsDisplay);
        getTotalDistance();

    };
    document.getElementById('plotPoints').addEventListener('click', onClickHandler);
}

function calculateAndDisplayRoute(directionsService, directionsDisplay) {
    directionsService.route({
        origin: document.getElementById('startPoint').value,
        destination: document.getElementById('endPoint').value,
        travelMode: 'DRIVING'
    }, function (response, status) {
        if (status === 'OK') {
            directionsDisplay.setDirections(response);
        } else {
            window.alert('Directions request failed due to ' + status);
        }
    });
}


function getTotalDistance() {
    var service = new google.maps.DistanceMatrixService();
    service.getDistanceMatrix(
  {
      origins: [document.getElementById('startPoint').value],
      destinations: [document.getElementById('endPoint').value],

      //we can use this to change the method of transportation via simple dropdown without needing
      //to affect the end user experience
      travelMode: 'DRIVING',

      //Options that apply only to requests where travelMode is TRANSIT
      //transitOptions: TransitOptions,

      //specifies values that apply only to requests where travelMode is DRIVING:
      //drivingOptions: DrivingOptions,

      //The unit system to use when displaying distance. google.maps.UnitSystem.METRIC is default
      unitSystem: google.maps.UnitSystem.IMPERIAL,

      //If true, the routes between origins and destinations will be calculated to avoid highways where possible
      //avoidHighways: Boolean,

      //If true, the directions between points will be calculated using non-toll routes, wherever possible
      //avoidTolls: Boolean,

      //reference https://developers.google.com/maps/documentation/javascript/distancematrix for more options
  }, callback);

    function callback(response, status) {
        if (status == 'OK') {
            var origins = response.originAddresses;
            var destinations = response.destinationAddresses;

            for (var i = 0; i < origins.length; i++) {
                var results = response.rows[i].elements;
                for (var j = 0; j < results.length; j++) {
                    var element = results[j];
                    var distance = element.distance.text;
                    var duration = element.duration.text;
                    var from = origins[i];
                    var to = destinations[j];
                }
            }
            document.getElementById("parseDistanceResult").innerHTML = distance;
        }
    }
}