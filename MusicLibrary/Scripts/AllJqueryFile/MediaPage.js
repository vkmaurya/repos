



$(document).ready(function () {

    viewmediaList();

})

function viewmediaList() {

    var oTable = $("#Meditable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $('#Meditable').DataTable({
        "ajax": {
            "url": "/Media/ViewMediaList",
            "type": "GET",
            "data": "{}"
        },
        "columns": [


            { "data": "SongName", "autoWidth": true },
            { "data": "SingerName", "autoWidth": true },
            { "data": "AuthorName", "autoWidth": true },
            { "data": "Composer", "autoWidth": true },
            { "data": "Labale", "autoWidth": true },

            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=SearchMediaId(' + row.MediaID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =DeleteMediaid(' + row.MediaID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Deleted</button >';
                }
            }


        ]
    });
};



function savemedia() {

    var mediaid = $("#mediaeid").val();
    var songname = $("#songname").val();
    var singername = $("#singername").val();
    var authorname = $("#authorname").val();
    var composername = $("#composername").val();
    var labale = $("#labale").val();

    var regex = /^[a-zA-Z ]+$/;

    if (songname == '') {

        $("#validationsongname").html("Required this field!");
    }
    else if (!regex.test(songname)) {
        $("#validationsongname").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationsongname").html("");
    }
    //--------------------------------------------
    if (singername == '') {

        $("#validationsingername").html("Required this field!");
    }
    else if (!regex.test(singername)) {
        $("#validationsingername").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationsingername").html("");
    }
    //--------------------------------------------

    if (authorname == '') {

        $("#validationauthorname").html("Required this field!");
    }
    else if (!regex.test(authorname)) {
        $("#validationauthorname").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationauthorname").html("");
    }
    //--------------------------------------------

    if (composername == '') {

        $("#validationcomposername").html("Required this field!");
    }
    else if (!regex.test(composername)) {
        $("#validationcomposername").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationcomposername").html("");
    }
    //--------------------------------------------

    if (labale == '') {

        $("#validationlabale").html("Required this field!");
    }
    else if (!regex.test(labale)) {
        $("#validationlabale").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationlabale").html("");
    }
    //--------------------------------------------

    if (songname != '' && regex.test(songname) == true && singername != '' && regex.test(singername) == true && authorname != '' && regex.test(authorname) == true && composername != '' && regex.test(composername) == true && labale != '' && regex.test(labale) == true) {

        data = {};
        data.MediaID = mediaid;
        data.SongName = songname;
        data.SingerName = singername;
        data.AuthorName = authorname;
        data.Composer = composername;
        data.Labale = labale;

        $.ajax({

            type: "POST",
            url: "/Media/CreateMedia",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {
                        $("#mediasuccessmessage").html("Save Successfully...");
                        ResetFormMedia();
                        viewmediaList();
                        $("#mediamodelModal").modal("hide");
                    }
                    else if (result == "notsave") {

                    }
                    else if (result == "update") {
                        $("#mediasuccessmessage").html("Update Successfully...");
                        ResetFormMedia();
                        $("#mediamodelModal").modal("hide");
                        viewmediaList();
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


function SearchMediaId(mediaid) {


    data = {};
    data.MediaID = mediaid;

    $.ajax({

        type: "POST",
        url: "/Media/SearchMediaRecords",
        data: data,
        success: function (result) {
            if (result != null) {



                $("#mediamodelModal").modal("show");

                $("#mediaeid").val(result.MediaID);
                $("#songname").val(result.SongName);
                $("#singername").val(result.SingerName);
                $("#authorname").val(result.AuthorName);
                $("#composername").val(result.Composer);
                $("#labale").val(result.Labale);


            }
        }
    })


}


function ResetFormMedia() {


    $("#mediaeid").val("");
    $("#songname").val("");
    $("#singername").val("");
    $("#authorname").val("");
    $("#composername").val("");
    $("#labale").val("");


    $("#validationsongname").html("");
    $("#validationsingername").html("");
    $("#validationauthorname").html("");
    $("#validationcomposername").html("");
    $("#validationlabale").html("");


}



function DeleteMediaid(mediaid) {

    $("#mediaupdateid").val(mediaid);
    $("#mediadeleteModalLabel").modal("show");
}

function mediadeleted() {

    data = {};
    var mediaid = $("#mediaupdateid").val();
    data.MediaID = mediaid;

    $.ajax({

        type: "POST",
        url: "/Media/DeletedMedia",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "deleted") {

                    $("#mediadeleteModalLabel").modal("hide");
                    viewmediaList();
                    $("#mediasuccessmessage").html("Deleted Successfully...");
                }
                else if (result == "notdeleted") {

                    $("#mediadeleteModalLabel").modal("hide");

                    alert("NotDeleted");
                }
                else if (result == "exception") {

                    alert("Server Busy...");
                    $("#mediadeleteModalLabel").modal("hide");
                }
                else {

                }

            }
        }
    })
}