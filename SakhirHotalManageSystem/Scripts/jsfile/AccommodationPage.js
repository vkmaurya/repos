
$(document).ready(function () {

    ViewAccommodationTypeList();
});

function ViewAccommodationTypeList() {

    var oTable = $("#viewAccommodationTypelist").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#viewAccommodationTypelist").DataTable({

        "ajax": {

            "url": "/AccommodationType/ViewAccommodationType",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "AccommodationTypeName"},
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchaccommodationtypeid(' + row.AccommodatioTypeID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =Accomodationtypedeletes(' + row.AccommodatioTypeID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }
        ]
    })
}


function accommodationtypeaddandupdate() {

    var AccommmodationTypeID = $("#accommodationtypeid").val();
    var AccommodationTypename = $("#accomodationtypename").val();
    var Accommodationdescription = $("#accommodationdescription").val();
    var Accommodationtypeimages = $("#accommodationtypeimages").val();

    var regexAccmmodation = /^[a-zA-Z ]+$/;
    if (AccommodationTypename == '') {
        $("#accommodationtypevalidation").html("Name Field cannot be left empty");
        $("#accomodationtypename").css("border-bottom", "2px solid red");
    }
    else if (!regexAccmmodation.test(AccommodationTypename)) {
        $("#accommodationtypevalidation").html("Name must be in alphabets only");
        $("#accomodationtypename").css("border-bottom", "2px solid red");
    }
    else {
        $("#accommodationtypevalidation").html("");
        $("#accomodationtypename").css("border-bottom", "");
    }

    if (Accommodationdescription == '') {
        $("#accommodationtypevalidationdescription").html("Name Field cannot be left empty");
        $("#accommodationdescription").css("border-bottom", "2px solid red");
    }
    else if (!regexAccmmodation.test(Accommodationdescription)) {
        $("#accommodationtypevalidationdescription").html("Name must be in alphabets only");
        $("#accommodationdescription").css("border-bottom", "2px solid red");
    }
    else {
        $("#accommodationtypevalidationdescription").html("");
        $("#accommodationdescription").css("border-bottom", "");
    }


    if (AccommodationTypename != '' && regexAccmmodation.test(AccommodationTypename) == true && Accommodationdescription != '' && regexAccmmodation.test(Accommodationdescription) == true) {

        alert("ldfkldfkl");

        var formData = new FormData();
        var files = $("#accommodationtypeimages").get(0).files;
        if (files.length > 0) {
            formData.append("HelpSectionImages", files[0]);
        }

        formData.append("file", files[0]);
        formData.append("AccommodatioTypeID", AccommmodationTypeID );
        formData.append("AccommodationTypeName", AccommodationTypename );
        formData.append("AccommodationTypeDescription", Accommodationdescription );
        formData.append("AccommodationTypeImage", files[0].name);

        //data = {};
        //data.AccommodatioTypeID = AccommmodationTypeID;
        //data.AccommodationTypeName = AccommodationTypename;
        //data.AccommodationTypeDescription= Accommodationdescription;
        $.ajax({

            type: "POST",
            url: "/AccommodationType/Accommodationtypeaddandupdate",
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {

                        $("#accomodationallmessage").html("Save Successfully...");
                        ViewAccommodationTypeList();
                        $("#AccomodationModal").modal("hide");
                        ResetAccomodationtypeform();
                    }
                    else if (result == "notsave") {
                        alert("notsave")
                    }
                    else if (result == "exception") {
                        alert("server busy...")
                    }
                    else if (result == "update") {

                        $("#accomodationallmessage").html("Update Successfully...");
                        ViewAccommodationTypeList();
                        $("#AccomodationModal").modal("hide");
                        ResetAccomodationtypeform();
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



function searchaccommodationtypeid(accomodationtypeId) {

    var accomodationid = accomodationtypeId;

    data = {};
    data.AccommodatioTypeID = accomodationid;

    $.ajax({

        type: "POST",
        url: "/AccommodationType/SearchAccomodationtypeid",
        data: data,
        success: function (result) {


            if (result != null) {

                $("#AccomodationModal").modal("show");
                $("#accommodationtypeid").val(result.AccommodatioTypeID);
                $("#accomodationtypename").val(result.AccommodationTypeName);
                $("#accommodationdescription").val(result.AccommodationTypeDescription);
            }
        }
    })

}


function Accomodationtypedeletes(id) {

    $("#accomodationtypeModaldelete").modal("show");
    $("#accomodationtypedeleteid").val(id);
}

function deleteaccommodationtype() {
 

    data = {};
    var accomodationtypeid = $("#accomodationtypedeleteid").val();

    data.AccommodatioTypeID = accomodationtypeid;

    $.ajax({

        type: "POST",
        url: "/AccommodationType/DeletedAcccommodatoiontype",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "deleted") {
                    $("#accomodationtypeModaldelete").modal("hide");
                    ViewAccommodationTypeList();
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


function ResetAccomodationtypeform() {

    $("#accommodationtypeid").val("");
    $("#accomodationtypename").val("");
    $("#accommodationtypevalidation").html("");
    $("#accomodationtypename").css("border-bottom", "");
}