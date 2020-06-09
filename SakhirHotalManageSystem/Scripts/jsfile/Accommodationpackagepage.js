
$(document).ready(function () {

    ViewAccommodationpackageList();
    AccommodaationTypedropdownlist();
});
function AccommodaationTypedropdownlist() {

    var ddlCustomers = $("#accomodationtypenamedropdownlist");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/AccommodationType/ViewAccommodationTypedropdownlist",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {
                ddlCustomers.append($("<option></option>").val(result.AccommodatioTypeID).html(result.AccommodationTypeName));
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

function ViewAccommodationpackageList() {

    var oTable = $("#viewAccommodationpackagelist").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#viewAccommodationpackagelist").DataTable({

        "ajax": {

            "url": "/AccommodationPackage/ViewAccommodationPackage",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "AccommodationTypeName", "autoWidth": true, },
            { "data": "AccommodationPackageName", "autoWidth": true, },
            { "data": "NoOfRoom", "autoWidth": true, },
            { "data": "FeePerNight", "autoWidth": true, },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchaccommodationpackageid(' + row.AccommodationPackageID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =Accomodationpackagedeletesrecords(' + row.AccommodationPackageID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }
        ]
    })
}


function accommodationpackagaddupdate() {

    var AccommmodationpackageID = $("#accommodationpackageid").val();
    var AccommodationTypename = $("#accomodationtypenamedropdownlist").val();
    var Accommodationpackagename = $("#accomodationpackagename").val();
    var noofroom = $("#noofroom").val();
    var feeoernight = $("#feepernight").val();


    var regexname = /^[a-zA-Z ]+$/;
    var regexnumber = /^[0-9 ]+$/;


    if (AccommodationTypename == 0) {

        $("#accommodationpackagevalidationdrop").html("Required this fileds!");
    }
    else {

        $("#accommodationpackagevalidationdrop").html("");
    }
    //-----------------------------------------------

    //--------------------------------------------------------
    if (Accommodationpackagename == "") {

        $("#accommodationpackagenamevalidation").html("Required this fileds!");
    }
    else if (!regexname.test(Accommodationpackagename)) {
        $("#accommodationpackagenamevalidation").html("Name must be in alphabets only");
    }
    else {

        $("#accommodationpackagenamevalidation").html("");
    }
    //-----------------------------------------------------------------------
    if (noofroom == "") {

        $("#accommodationpackagenoofroomvalidation").html("Required this fileds!");
    }

    else if (!regexnumber.test(noofroom)) {

        $("#accommodationpackagenoofroomvalidation").html("Enter Only number");
    }
    else {

        $("#accommodationpackagenoofroomvalidation").html("");
    }

    //-----------------------------------------------------------------------
    if (feeoernight == "") {

        $("#accommodationpackagefeepernightvalidation").html("Required this fileds!");
    }
    else if (!regexnumber.test(feeoernight)) {

        $("#accommodationpackagefeepernightvalidation").html("Enter Only Number");
    }
    else {

        $("#accommodationpackagefeepernightvalidation").html("");
    }

    if (AccommodationTypename != 0 && Accommodationpackagename != '' && feeoernight != '' && noofroom != '' && regexname.test(Accommodationpackagename) == true && regexnumber.test(noofroom) == true && regexnumber.test(feeoernight) == true) {


        data = {};
        data.AccommodationPackageID = AccommmodationpackageID;
        data.AccommodationTypeID = AccommodationTypename;

        data.AccommodationPackageName = Accommodationpackagename;

        data.FeePerNight = feeoernight;
        data.NoOfRoom = noofroom;
        $.ajax({

            type: "POST",
            url: "/AccommodationPackage/Accommodationpackageaddandupdate",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {

                        $("#accomodationallmessage").html("Save Successfully...");
                        ViewAccommodationpackageList();
                        $("#AccomodationpackageModal").modal("hide");
                        ResetAccomodationpackageform();
                    }
                    else if (result == "notsave") {
                        alert("notsave")
                    }
                    else if (result == "exception") {
                        alert("server busy...")
                    }
                    else if (result == "update") {

                        $("#accomodationallmessage").html("Update Successfully...");
                        ViewAccommodationpackageList();
                        $("#AccomodationpackageModal").modal("hide");
                        ResetAccomodationpackageform();
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



function searchaccommodationpackageid(accomodationpackageId) {

    var accomodationid = accomodationpackageId;

    data = {};
    data.AccommodationPackageID = accomodationid;

    $.ajax({

        type: "POST",
        url: "/AccommodationPackage/SearchAccomodationpackage",
        data: data,
        success: function (result) {


            if (result != null) {

                $("#AccomodationpackageModal").modal("show");

                $("#accommodationpackageid").val(result.AccommodationPackageID);
                $("#accomodationtypenamedropdownlist").val(result.AccommodationTypeID);
                $("#accomodationpackagename").val(result.AccommodationPackageName);
                $("#noofroom").val(result.NoOfRoom);
                $("#feepernight").val(result.FeePerNight);
            }
        }
    })

}


function Accomodationpackagedeletesrecords(id) {


    $("#accomodationpackageModaldelete").modal("show");
    $("#accomodationpackagedeleteid").val(id);
}

function deleteaccommodationpackage() {

    data = {};
    var accomodationtypeid = $("#accomodationpackagedeleteid").val();

    data.AccommodationPackageID = accomodationtypeid;

    $.ajax({

        type: "POST",
        url: "/AccommodationPackage/DeletedAcccommodatoionpackage",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "deleted") {
                    $("#accomodationpackageModaldelete").modal("hide");
                    ViewAccommodationpackageList();
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


function ResetAccomodationpackageform() {

    $("#accommodationpackageid").val("");
    $("#accomodationtypenamedropdownlist").val(0);
    $("#accomodationpackagename").val("");
    $("#noofroom").val("");
    $("#feepernight").val("");



    $("#accommodationpackagevalidationdrop").html("");
    $("#accommodationpackagenamevalidation").html("");
    $("#accommodationpackagenoofroomvalidation").html("");
    $("#accommodationpackagefeepernightvalidation").html("");
}