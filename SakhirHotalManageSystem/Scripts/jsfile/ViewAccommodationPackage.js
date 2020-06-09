

//$(document).ready(function () {

//   


$(document).ready(function () {


    var ddlCustomers = $("#accommodationpackagedropdownListshow");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/ViewAccommodationpackage/ViewAccommodationAllpackagenamedropdownlist",
        data: "{}",

        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');

            $.each(response, function (index, result) {
                ddlCustomers.append($("<option></option>").val(result.AccommodationPackageID).html(result.AccommodationPackageName));
                $("#accommodationtypename").val(result.AccommodationTypeID);
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });

})



$("#accommodationpackagedropdownListshow").change(function () {

    $("#allaccommodationlistshow").html("");

    var accommodationpackageid = this.value;
    var accommodationtypeid = $("#accommodationtypename").val();

    data = {};
    data.AccommodationTypeID = accommodationtypeid;
    data.AccommodationPackageID = accommodationpackageid;

    $.ajax({

        type: "POST",
        url: "/ViewAccommodationpackage/ViewAccommodationAllList",
        data: data,
        success: function (result) {
            $.each(result, function (index, response) {

                var allaccommodation = '<div class="col-lg-4 col-md-4 col-sm-12"> <div class="card" style="width: 100%;" ><img src="/FrontDeskTamplates/images/room-3.jpg" class="card-img-top room image-popup-link" alt="..." style="background-color:blue;"><br/><div class="card-body text-center"> <h5 class="card-title">' + response.AccommodationTypeName + '</h5> <p class="card-text">' + response.AccommodationPackageName + '</p> <p class="card-text">' + response.FeePerNight + ' PerNight </p>  <p class="card-text">' + response.NoOfRoom + ' BeadRoom</p> <p class="card-text">' + response.AccommodationName + '</p> <a class="btn btn-primary btn-btn-book" onclick="BookHotal(' + response.AccommodationID + ');">Book Now</a> </div></div></div>';

                $("#allaccommodationlistshow").append(allaccommodation);
            });
        }
    })
});


$(document).ready(function () {
    $("#checkindate").datepicker({
        formate: "mm/dd/yyyy",
        StartDate: '+3d'
    })

});


function BookHotal(accommodationid) {

    var AccommodationID = accommodationid;
    $("#HotalBookingmodel").modal("show");
    $("#accommodationbbokingid").val(AccommodationID);

}

function hotalbooking() {


    var accommodationbbokingid = $("#accommodationbbokingid").val();
    var checkindate = $("#checkindate").val();
    var durationstaynight = $("#durationstaynight").val();
    var noofadults = $("#noofadults").val();
    var noofchildren = $("#noofchildren").val();
    var GuestName = $("#GuestName").val();
    var bookingemail = $("#bookingemail").val();
    var noteaddmessage = $("#noteaddmessage").val();


    var regexcname = /^[a-zA-Z ]+$/;
    var regexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;
    var regsaddnotes = /^[a-zA-Z0-9 ]+$/;

    if (checkindate == '') {
        $("#messagecheckindate").html("Required this fields!");

    }
    else {

        $("#messagecheckindate").html("");
    }


    if (durationstaynight == 0) {
        $("#messagedurationstaynight").html("Required this fields!");

    }
    else {

        $("#messagedurationstaynight").html("");
    }


    if (noofadults == '') {
        $("#messagenoofadults").html("Required this fields!");

    }
    else {

        $("#messagenoofadults").html("");
    }



    if (noofchildren == '') {
        $("#messagenoofchildren").html("Required this fields!");

    }
    else {

        $("#messagenoofchildren").html("");
    }



    if (GuestName == '') {
        $("#messageGuestName").html("Required this fields!");

    }
    else if (!regexcname.test(GuestName)) {
        $("#messageGuestName").html("Please Enter only Char Name");
    }
    else {

        $("#messageGuestName").html("");
    }


    if (bookingemail == '') {
        $("#messagebookingemail").html("Required this fields!");

    }
    else if (!regexemail.test(bookingemail)) {
        $("#messagebookingemail").html("Invalid Email Enter Valid Email");
    }
    else {

        $("#messagebookingemail").html("");
    }

    if (noteaddmessage == '') {
        $("#messagenoteaddmessage").html("Required this fields!");

    }
    else if (!regsaddnotes.test(noteaddmessage)) {
        $("#messagenoteaddmessage").html("Wrong name enter char Name");
    }
    else {

        $("#messagenoteaddmessage").html("");
    }

    if (checkindate != '' && durationstaynight != '' && noofadults != '' && noofchildren != '' && GuestName != '' && bookingemail != '' && noteaddmessage != '' && regexcname.test(GuestName) == true && regexemail.test(bookingemail) == true && regsaddnotes.test(noteaddmessage) == true) {


        data = {};

        data.AccommodationID = accommodationbbokingid;
        data.CheckInDate = checkindate;
        data.Duration = durationstaynight;
        data.NoOfAdults = noofadults;
        data.NoOfChildren = noofchildren;
        data.GuestName = GuestName;
        data.BookingEmail = bookingemail;
        data.AddMesageNotes = noteaddmessage;


        $.ajax({

            type: "POST",
            url: "/Booking/BookingHotal",
            data: data,
            success: function (result) {

                if (result != null) {
                    if (result == "submit") {

                        alert("Submit");

                        $("#HotalBookingmodel").modal("hide");

                        Resetbookingform();

                    }
                    else if (result == "notsubmit") {
                        alert("NotSubmit");
                    }
                    else if (result == "exception") {
                        alert("Exception");
                    }
                    else {

                    }

                }
            }
        })


    }
}



function Resetbookingform() {

    $("#checkindate").val('');
    $("#durationstaynight").val(1);
    $("#noofadults").val(1);
    $("#noofchildren").val(0);
    $("#GuestName").val('');
    $("#bookingemail").val('');
    $("#noteaddmessage").val('');




    $("#messagecheckindate").html("");
    $("#messagedurationstaynight").html("");
    $("#messagenoofadults").html("");
    $("#messagenoofchildren").html("");
    $("#messageGuestName").html("");
    $("#messagebookingemail").html("");
    $("#messagenoteaddmessage").html("");
}