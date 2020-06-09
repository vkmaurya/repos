
$(document).ready(function () {
    var ddlCustomers = $("#typedoctorname");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Appoiment/DoctorTypeName",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index,result) {
                ddlCustomers.append($("<option></option>").val(result.DoctorTypeID).html(result.DoctorTypeName));
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

//-------------------------------------------------------------------------------------------------
$(document).ready(function () {

    $("#typedoctorname").change(function () {
        data = {};
        var doctordypeid = $("#typedoctorname").val();

        data.DoctorTypeID= doctordypeid;
        var ddlCustomers = $("#doctornamedrop");
        ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
        $.ajax({
            type: "POST",
            url: "/Appoiment/DoctorNamedropdownlist",
            data: data,
         
            success: function (response) {
                ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
                $.each(response, function (index, result) {
                    ddlCustomers.append($("<option></option>").val(result.DoctorId).html(result.DoctorName));
                });
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

})

$(document).ready(function () {

    $("#typedoctorname").change(function () {
        data = {};
        var doctordypeid = $("#typedoctorname").val();
           
        data.DoctorTypeID = doctordypeid;
       
        $.ajax({
            type: "POST",
            url: "/Appoiment/Sickdropdownlist",
            data: data,

            success: function (response) {
                $.each(response, function (index, result) {
                  
                  
                    var checkbox = ' <label for="inputPassword" col-form-label">' + result.SickTypeName + '</label><input type="checkbox" id="checkb" value =' + result.SickTypeID + '>';
                    $("#sickcheckbox").append(checkbox);
                });
            },
        });
    });

})


//-----------------------------------------------------------------------------------------------

function savepatientappoiment() {


    data = {};

    var doctorid = $("#doctornamedrop").val();

    if (doctorid == 0) {

        $("#doctornamedropmessage").html("Requireds this fields!");
    }
    else {
        $("#doctornamedropmessage").html("");
    }

    if (doctorid != 0) {

        p = new Array();
        $("#sickcheckbox").find("input:checked").each(function () {

            p.push($(this).val())
        });


        data.DoctorId = doctorid;
        data.id = p;

        $.ajax({

            type: "POST",
            url: "/Appoiment/PatientAppoiment",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {

                        alert("Appoiment Done");

                    }
                    else if (result == "notsave") {

                    }
                    else if (result == "alreadyexitdata")
                    {
                        alert("you are allready appoiment schedule done");
                    }
                    else {

                    }
                }

            }
        });

    }

}

//-------------------------------------DoctorAppoiment start--------------------------------------------------



$(document).ready(function () {


    $.ajax({

        type: "GET",
        url: "/Appoiment/patientCheckAppoiimentshudal",
        data: "{}",
        success: function (result) {
            $.each(result, function (index, response) {
                var add = '<tr><td>' + response.PatientName + '</td> <td>' + response.DoctorName + '</td> <td>' + ToJsDate(response.AppointmentBookingDate) + '</td> <td>' + ToJsDate(response.AppointmentDateStart) + '</td> <td>' + ToJsDate(response.AppointmentDateEnd) + '</td> <td>' + response.AppointmentPatientSession + '</td> <td>' + response.AppointmentStatus + '</td></tr>';
                $("#showdoneappoiment").append(add);

            });
        }
    })
})

$(document).ready(function () {


    $.ajax({

        type: "GET",
        url: "/Appoiment/patientCheckAppoiimentshudalpanding",
        data: "{}",
        success: function (result) {
            $.each(result, function (index, response) {
                var add = '<tr><td>' + response.PatientName + '</td> <td>' + response.DoctorName + '</td> <td>' + ToJsDate(response.AppointmentBookingDate) + '</td> <td>' + ToJsDate(response.AppointmentDateStart) + '</td> <td>' + ToJsDate(response.AppointmentDateEnd) + '</td> <td>' + response.AppointmentPatientSession + '</td> <td>' + response.AppointmentStatus + '</td></tr>';
                $("#showdoneappoimentpanding").append(add);

            });
        }
    })
})