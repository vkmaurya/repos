
$(document).ready(function () {

    ViewAccommodationList();
    Accommodaationdropdownlist();
});
function Accommodaationdropdownlist() {

    var ddlCustomers = $("#accomodationpackagid");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "GET",
        url: "/AccommodationPackage/Viewdropdownlistaccommodationpackage",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {
                ddlCustomers.append($("<option></option>").val(result.AccommodationPackageID).html(result.AccommodationPackageName));
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function ViewAccommodationList() {

    var oTable = $("#viewAccommodationlist").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#viewAccommodationlist").DataTable({

        "ajax": {

            "url": "/Accommodation/ViewAccommodation",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "AccommodationPackageName", "autoWidth": true, },
            { "data": "AccommodationName", "autoWidth": true, },

            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchaccommodationid(' + row.AccommodationID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =Accomodationpackagedeletes(' + row.AccommodationID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }
        ]
    })
}


function accommodationaddandupdate() {

    var AccommmodationID = $("#accommodationid").val();
    var AccommodationPackageID = $("#accomodationpackagid").val();
    var Accommodationname = $("#accomodationname").val();
    var regexAccmmodation = /^[a-zA-Z0-9 ]+$/;

    if (AccommodationPackageID == 0) {

        $("#accommodationvalidationmessage").html("Required this fields!");
    }
    else {
        $("#accommodationvalidationmessage").html("");
    }

    //----------------------------------------------
    if (Accommodationname == '') {

        $("#accommodationnamevalidationmesage").html("Required this fields!");
    }
    else if (!regexAccmmodation.test(Accommodationname)) {
        $("#accommodationnamevalidationmesage").html("Name must be in alphabets only");

    }
    else {
        $("#accommodationnamevalidationmesage").html("");
    }

    if (AccommodationPackageID != '' && Accommodationname != '' && regexAccmmodation.test(Accommodationname) == true) {

        data = {};

        data.AccommodationID = AccommmodationID;
        data.AccomodationPackageID = AccommodationPackageID;
        data.AccommodationName = Accommodationname;


        $.ajax({

            type: "POST",
            url: "/Accommodation/Accommodationaddandupdate",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {

                        $("#accomodationallmessage").html("Save Successfully...");
                        ViewAccommodationList();
                        $("#AccomodationpageModal").modal("hide");
                        ResetAccomodationpackage();
                    }
                    else if (result == "notsave") {
                        alert("notsave")
                    }
                    else if (result == "exception") {
                        alert("server busy...")
                    }
                    else if (result == "update") {

                        $("#accomodationallmessage").html("Update Successfully...");
                        ViewAccommodationList();
                        $("#AccomodationpageModal").modal("hide");
                        ResetAccomodationpackage();
                    }
                    else if (result == "notupdate") {
                        alert("notupdate");
                    }

                    else {

                    }
                }
            }
        })
    }
}



function searchaccommodationid(accomodationpackageId) {

    var accomodationid = accomodationpackageId;

    data = {};
    data.AccommodationID = accomodationid;

    $.ajax({

        type: "POST",
        url: "/Accommodation/SearchAccomodationid",
        data: data,
        success: function (result) {


            if (result != null) {

                $("#AccomodationpageModal").modal("show");

                $("#accommodationid").val(result.AccommodationID);
                $("#accomodationpackagid").val(result.AccomodationPackageID);
                $("#accomodationname").val(result.AccommodationName);

            }
        }
    })

}


function Accomodationpackagedeletes(id) {

    $("#accomodationModaldelete").modal("show");
    $("#accomodationdeleteid").val(id);
}

function deleteaccommodation() {

    data = {};
    var accomodationtypeid = $("#accomodationdeleteid").val();

    data.AccommodationID = accomodationtypeid;

    $.ajax({

        type: "POST",
        url: "/Accommodation/DeletedAcccommodatoion",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "deleted") {
                    $("#accomodationModaldelete").modal("hide");
                    ViewAccommodationList();
                    $("#accomodationallmessage").html("Deleted Successfully...");
                    ResetAccomodationtypeform();
                }
                else if (result == "notdelete") {

                    alert("notdeleted");
                }
                else if (result == "exception") {
                    alert("Server busy...");
                }
                else {

                }
            }
        }
    })
}


function ResetAccomodationpackage() {

    $("#accommodationid").val("");
    $("#accomodationpackagid").val(0);
    $("#accomodationname").val("");

    $("#accommodationvalidationmessage").html("");
    $("#accommodationvalidationmessage").html("");

}