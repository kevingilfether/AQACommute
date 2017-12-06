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
        getTripInfo();

    };
    $(function () {
        $('#plotPoints').on('click', onClickHandler);
    });
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


function getTripInfo() {
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
                    var distance = element.distance.value;//in meters
                    var duration = element.duration.value;//in seconds
                    var from = origins[i];
                    var to = destinations[j];
                }
            }
            $(function () {
                $("#startInput").val(origins);
                $("#endInput").val(destinations);
                $("#totalMiles").val(((parseFloat(distance)) / 1609.34));
                $("#commuteTime").val((parseInt(duration) / 60));
                var mapData = {
                    //set properties found in controller	
                    DistanceInfo: distance,
                    //DurationInfo: duration
                };

                alert(mapData);
                $.ajax({
                    //makes it so page doesn’t wait to load
                    async: true,
                    method: "POST",
                    url: "/Commutes/MapInfo",
                    data: JSON.stringify(mapData),
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        alert("Info POSTed");
                        var returnValue = parseFloat(data);
                        $("#co2FootprintInput").val()
                        $("#co2FootprintDisplay").text(((Math.round(returnValue, 2)).toFixed(2)) + " lbs/CO2 for this trip.");
                    },
                    error: function (data) {
                        alert("Error POSTing view info to controller!");
                        alert(data);
                    }
                });

            });
        };
    }
}
