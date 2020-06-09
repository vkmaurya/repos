



$(document).ready(function () {

    viewmediatypeList();

})

function viewmediatypeList() {

    var oTable = $("#MediTypetable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $('#MediTypetable').DataTable({
        "ajax": {
            "url": "/Media/ViewMediaTypeList",
            "type": "GET",
            "data": "{}"
        },
        "columns": [


            { "data": "MediaTypeName", "autoWidth": true },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=SearchMediaTypeId(' + row.MediaTypeID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =DeleteMediatypeid(' + row.MediaTypeID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Deleted</button >';
                }
            }


        ]
    });
};



function savemediatype() {

    var mediatypeid = $("#mediatypeid").val();
    var mediatypename = $("#mediatypename").val();

    var regexname = /^[a-zA-Z ]+$/;

    if (mediatypename == '') {
        $("#mediatypemessage").html("Required this field!");
    }
    else if (!regexname.test(mediatypename)) {
        $("#mediatypemessage").html("Please Enter Only Char Name");
    }
    else {
        $("#mediatypemessage").html("");
    }

    if (mediatypename != '' && regexname.test(mediatypename) == true) {
        data = {};
        data.MediaTypeID = mediatypeid;
        data.MediaTypeName = mediatypename;

        $.ajax({

            type: "POST",
            url: "/Media/CreateMediaType",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {
                        $("#mediatypesuccessmessage").html("Save Successfully...");
                        ResetFormMediaType();
                        viewmediatypeList();
                        $("#mediatypemodelModal").modal("hide");
                    }
                    else if (result == "notsave") {

                    }
                    else if (result == "update") {
                        $("#mediatypesuccessmessage").html("Update Successfully...");
                        ResetFormMediaType();
                        $("#mediatypemodelModal").modal("hide");
                        viewmediatypeList();
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


function SearchMediaTypeId(mediatypeid) {

    data = {};
    data.MediaTypeID = mediatypeid;

    $.ajax({

        type: "POST",
        url: "/Media/SearchMediaTypeRecords",
        data: data,
        success: function (result) {
            if (result != null) {



                $("#mediatypemodelModal").modal("show");
                $("#mediatypeid").val(result.MediaTypeID);
                $("#mediatypename").val(result.MediaTypeName);

            }
        }
    })


}


function ResetFormMediaType() {
    $("#mediatypeid").val("");
    $("#mediatypename").val("");

    $("#mediatypemessage").html("");
}



function DeleteMediatypeid(mediatypeid) {

    $("#mediatypupdateid").val(mediatypeid);
    $("#mediatypdeleteModalLabel").modal("show");
}

function mediatypedeleted() {

    data = {};
    var mediaid = $("#mediatypupdateid").val();
    data.MediaTypeID = mediaid;

    $.ajax({

        type: "POST",
        url: "/Media/DeletedMediaType",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "deleted") {

                    $("#mediatypdeleteModalLabel").modal("hide");
                    viewmediatypeList();
                    $("#mediatypesuccessmessage").html("Deleted Successfully...");
                }
                else if (result == "notdeleted") {

                    $("#mediatypdeleteModalLabel").modal("hide");
                    viewmediatypeList();
                    alert("NotDeleted");
                }
                else if (result == "exception") {

                    alert("Server Busy...");
                    $("#mediatypdeleteModalLabel").modal("hide");
                }
                else {

                }

            }
        }
    })
}