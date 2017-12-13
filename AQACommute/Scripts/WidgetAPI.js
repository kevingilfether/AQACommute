var metaMpgData = {};
var vehicleRequest = vehicleRequest || {};
var MPGInfo;
var _vehicleID;

$(function () {
    //$("#createVehicle").hide();

    $(".carYear").change(function () {
        $("#Year").val($(".carYear").val());
    })
    $(".carMake").change(function () {
        $("#Make").val($(".carMake").val());
    })
    $(".carModel").change(function () {
        $("#Model").val($(".carModel").val());
    })
    $(".carVersion").change(function () {
        $("#Options").val($(".carVersion").val());
    })
    var localInput = JSON.parse(localStorage.getItem('userInput'));
    if (localInput) {
        $('.carSelection').html(localInput.carSelection);
        $('.carYear').val(localInput.carYear);
        $('.carMake').val(localInput.carMake);
        $('.carModel').val(localInput.carModel);
        $('.carVersion').val(localInput.carVersion);
        $('#WPOutput').html(localInput.waypts);
        $('#start').val(localInput.start);
        $('#end').val(localInput.end);
        $('#WPOutput option').each(function (index, elem) {
            var waypt = {
                location: $(elem).val(),
                stopover: true
            }
            waypts.push(waypt);
        });
        console.log(waypts);
        setEventsCarInfo();
    }
    else {
        console.log('no local input stored');
        setEventsCarInfo();
    }
});//end of ready function
function setEventsCarInfo() {
    var $carYear = $('.carYear');
    var $carMake = $('.carMake');
    var $carModel = $('.carModel');
    var $carVersion = $('.carVersion');

    $carYear.on('change', function (e) {
        e.preventDefault;
        $('.errorVehicle').text('');
        console.log('carYear event fires');
        var userSelectedYear = ""
        $(".carYear option:selected").each(function () {
            userSelectedYear += $(this).text();
        });
        var ajaxRequest = $.ajax({
            type: "GET",
            url: 'https://www.fueleconomy.gov/ws/rest/vehicle/menu/make?year=' + userSelectedYear,
            dataType: "xml",
        });
        ajaxRequest.done(function (xml) {
            $('.errorVehicle').text('');
            $carMake.html('');
            $carMake.append('<option>Make</option>');
            $(xml).find("value").each(function () {
                $carMake.append('<option>' + $(this).text() + '</option>');
            })
        });
    });
    //MODELS
    $carMake.change(function () {
        console.log('carMake event fires');
        $('.errorVehicle').text('');
        var userSelectedMake = "";
        $(".carMake option:selected").each(function () {
            userSelectedMake += $(this).text();
        });

        ajaxRequest = $.ajax({
            type: "GET",
            url: 'https://www.fueleconomy.gov/ws/rest/vehicle/menu/model?year=2012&make=' + userSelectedMake,
            dataType: "xml",
        });
        ajaxRequest.done(function (xml) {
            $carModel.html('');
            $carModel.append('<option>Model</option>');
            $(xml).find("value").each(function () {
                $carModel.append('<option>' + $(this).text() + '</option>');
            })
        });
    });

    $carModel.on('change', function () {
        $('.errorVehicle').text('');
        vehicleRequest.userCar();
    });
}

vehicleRequest.selection = function () {
    var $carYear = $('.carYear');
    var $carMake = $('.carMake');
    var $carModel = $('.carModel');
    var $carVersion = $('.carVersion');
    var $avgMpg = $('.avgMpg');
    var $minMpg = $('.minMpg');
    var $maxMpg = $('.maxMpg');
    var $errorVehicle = $('.errorVehicle');

    var date = new Date();
    var currentYear = date.getFullYear();
    for (ii = 1984; ii <= currentYear; ii++) {
        $carYear.prepend('<option>' + ii + '</option>')
    };

    vehicleRequest.userCar = function () {
        console.log('it runs');
        userYear = $(".carYear option:selected").text();
        userMake = $(".carMake option:selected").text();
        userModel = $(".carModel option:selected").text();
        console.log('Request to https://www.fueleconomy.gov/ws/rest/vehicle/menu/options?year=' + userYear + '&make=' + userMake + '&model=' + userModel)
        ajaxRequest = $.ajax({
            type: "GET",
            url: 'https://www.fueleconomy.gov/ws/rest/vehicle/menu/options?year=' + userYear + '&make=' + userMake + '&model=' + userModel,
            dataType: "xml",
        });

        ajaxRequest.done(function (xml) {
            //var $carVersion = $('.carVersion');
            $carVersion.html('');
            $carVersion.append('<option>Version</option>');
            $(xml).find("text").each(function () {
                $carVersion.append('<option>' + $(this).text() + '</option>');
            });
            if ($carVersion.children().length === 1) {
                $errorVehicle.text('Sorry, we could not find the information about the vehicle.  An average mpg of 20 will be used for this vehicle.');
                $("#AvgMPG").val("20");
                $("#createVehicle").show();

            } else {
                
                $carVersion.on('change', function () {
                    vehicleID = $(xml).find("text:contains('" + $carVersion.val() + "')").next("value").text();
                    //http://www.fueleconomy.gov/ws/rest/vehicle/menu/options?year=2012&make=Honda&model=Fit
                    //http://www.fueleconomy.gov/ws/rest/ympg/shared/ympgVehicle/26425
                    console.log('Car ID: ' + vehicleID)
                    _vehicleID = vehicleID;
                    $("#createVehicle").show();
                    if (_vehicleID) {
                        getCarMPG();
                    }
                });
            }
        }); //ajax done #1
    } //userCarVersion
}; //vehicleRequest closed
vehicleRequest.selection();

function getCarMPG() {


    ajaxRequest = $.ajax({

        type: "GET",
        url: 'http://www.fueleconomy.gov/ws/rest/vehicle/' + _vehicleID,
        dataType: "xml",
        error: function () {
            var $errorVehicle = $('.errorVehicle');
            $errorVehicle.text('Sorry, we could not find the information about the vehicle.  An average mpg of 20 will be used for this vehicle.');
            $("#AvgMPG").val("20");
            $("#createVehicle").show();
        }
    });

    //TODO Change the following function to adjust what elements you are looking for for a vehicle and what you want to do with the result
    ajaxRequest.done(function (xml) {
        MPGInfo = $(xml).find('comb08').text();
        $("#AvgMPG").val(MPGInfo)
    });
}