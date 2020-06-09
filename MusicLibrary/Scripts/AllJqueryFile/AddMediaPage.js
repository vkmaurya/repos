

$(document).ready(function () {

    viewaddmediaList();

})

function viewaddmediaList() {

    var oTable = $("#AddMeditable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $('#AddMeditable').DataTable({
        "ajax": {
            "url": "/Media/ViewAddMediaList",
            "type": "GET",
            "data": "{}"
        },
        "columns": [


            { "data": "MediaTypeName", "autoWidth": true },
            { "data": "SongName", "autoWidth": true },
            { "data": "Dscription", "autoWidth": true },
            { "data": "Rent", "autoWidth": true },


            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=SearchaddMediaId(' + row.AddMediaID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =DeleteaddMediaid(' + row.AddMediaID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Deleted</button >';
                }
            }


        ]
    });
};



function saveaddmedia() {

    var addmediaid = $("#addmediaid").val();
    var mediatype = $("#mediatypeiddropdownlist").val();
    var mediaid = $("#mediadropdownlist").val();
    var rent = $("#rent").val();
    var description = $("#description").val();


    var regex = /^[a-zA-Z ]+$/;
    var regexrent = /^[0-9]+$/;
    if (mediatype == 0) {

        $("#validationmediatyp").html("Required this field!");
    }
    else {
        $("#validationmediatyp").html("");
    }
    //--------------------------------------------
    if (mediaid == 0) {

        $("#validationmedia").html("Required this field!");
    }

    else {
        $("#validationmedia").html("");
    }
    //--------------------------------------------

    if (rent == '') {

        $("#validationrent").html("Required this field!");
    }
    else if (!regexrent.test(rent)) {
        $("#validationrent").html("Please Enter Only Number");
    }
    else {
        $("#validationrent").html("");
    }
    //--------------------------------------------

    if (description == '') {

        $("#validationdescription").html("Required this field!");
    }
    else if (!regex.test(description)) {
        $("#validationdescription").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationdescription").html("");
    }
    //--------------------------------------------


    if (mediatype != 0 && mediaid != 0 && rent != '' && regexrent.test(rent) == true && description != '' && regex.test(description) == true) {

        data = {};

        data.AddMediaID = addmediaid;
        data.MediaTypeID = mediatype;
        data.MediaID = mediaid;
        data.Rent = rent;
        data.Dscription = description;


        $.ajax({

            type: "POST",
            url: "/Media/CreateAddMedia",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {
                        $("#addmediasuccessmessage").html("Save Successfully...");
                        ResetFormAddMedia();
                        viewaddmediaList();
                        $("#addmediamodelModal").modal("hide");
                    }
                    else if (result == "notsave") {

                    }
                    else if (result == "update") {
                        $("#addmediasuccessmessage").html("Update Successfully...");
                        ResetFormAddMedia();
                        $("#addmediamodelModal").modal("hide");
                        viewaddmediaList();
                    }
                    else if (result == "notupdate") {

                    }

                    else if (result == "exception") {


                    }
                    else {

                    }
                }
            }
        });

    }
}


function SearchaddMediaId(mediaid) {


    data = {};
    data.AddMediaID = mediaid;

    $.ajax({

        type: "POST",
        url: "/Media/SearchAddMediaRecords",
        data: data,
        success: function (result) {
            if (result != null) {



                $("#addmediamodelModal").modal("show");

                $("#addmediaid").val(result.AddMediaID);
                $("#mediatypeiddropdownlist").val(result.MediaTypeID);
                $("#mediadropdownlist").val(result.MediaID);
                $("#rent").val(result.Rent);
                $("#description").val(result.Dscription);


            }
        }
    })


}


function ResetFormAddMedia() {


    $("#addmediaid").val("");
    $("#mediatypeiddropdownlist").val(0);
    $("#mediadropdownlist").val(0);
    $("#rent").val("");
    $("#description").val("");

    $("#validationmediatyp").html("");
    $("#validationmedia").html("");
    $("#validationrent").html("");
    $("#validationdescription").html("");
}



function DeleteaddMediaid(addmediaid) {

    $("#addmediaupdateid").val(addmediaid);
    $("#addmediadeleteModalLabel").modal("show");
}

function addmediadeleted() {

    data = {};
    var mediaid = $("#addmediaupdateid").val();
    data.AddMediaID = mediaid;

    $.ajax({

        type: "POST",
        url: "/Media/DeletedAddMedia",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "deleted") {

                    $("#addmediadeleteModalLabel").modal("hide");
                    viewaddmediaList();
                    $("#addmediasuccessmessage").html("Deleted Successfully...");
                }
                else if (result == "notdeleted") {

                    $("#addmediadeleteModalLabel").modal("hide");

                    alert("NotDeleted");
                }
                else if (result == "exception") {

                    alert("Server Busy...");
                    $("#addmediadeleteModalLabel").modal("hide");
                }
                else {

                }

            }
        }
    })
}



//---------------------------------------------------------------------------


$(document).ready(function () {

    var ddlCustomers = $("#mediatypeiddropdownlist");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Media/Mediatypedropdownlist",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {
                ddlCustomers.append($("<option></option>").val(result.MediaTypeID).html(result.MediaTypeName));
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




//-----------------------------------------------------------------------------


$(document).ready(function () {

    var ddlCustomers = $("#mediadropdownlist");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Media/Mediadropdownlist",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {
                ddlCustomers.append($("<option></option>").val(result.MediaID).html(result.SongName));
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