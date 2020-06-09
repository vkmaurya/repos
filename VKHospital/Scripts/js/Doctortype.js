

$(document).ready(function () {
    DoctortypeListallview();
});

function DoctortypeListallview() {

    var oTable = $("#AlldoctorTypeList").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $('#AlldoctorTypeList').DataTable({
      
        "ajax": {

            "url": "/Doctor/ViewDoctorType",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "DoctorTypeName", "autoWidth": true },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchdoctortypedata(' + row.DoctorTypeID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =Deletedoctortype(' + row.DoctorTypeID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }


        ]
    });

};




function adddoctortypename() {

    data = {};
    var doctortypeid = $("#doctortypeid").val();
    var doctortypename = $("#doctortypename").val();
    var nameregex = /^[a-zA-Z  ]+$/;
    if (doctortypename == '') {
        $(".doctortypenamemessage").html("Required this field!");
    }
    else if (!nameregex.test(doctortypename)) {

        $(".doctortypenamemessage").html("please enter only  character!");
    }
    else {
        $(".doctortypenamemessage").html("");
    }
    if (doctortypename != '' && nameregex.test(doctortypename) == true) {

        data.DoctorTypeID = doctortypeid;
        data.DoctorTypeName = doctortypename;

        $.ajax({

            type: "POST",
            url: "/Doctor/CreateAndUpdate",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "doctortypeadd") {
                        DoctortypeListallview();
                        resetdoctortypeform();
                        $(".alertmessagedoctortype").html("Save Records Successfully...");
                      //  $('#doctortypenamemodel').modal('hide');

                        $("#doctortypenamemodel").modal("hide");

                    }
                    else if (result == "notsavedoctortype") {
                        $(".alertmessagedoctortype").html("Not Add Records...");
                    }
                    else if (result == "update")
                    {
                        DoctortypeListallview();
                        $(".alertmessagedoctortype").html("Update Successfully Records...");
                        $("#doctortypenamemodel").modal("hide");
                    }
                    else if (result == "notupdate")
                    {
                        $(".alertmessagedoctortype").html("Not Update Records...");
                    }
                    else {
                        alert("server busy...");
                    }
                }
            }
        });
    }
};


function searchdoctortypedata(p) {

   // $("#doctortypenamemodel").modal("show");
    data = {};

    data.DoctorTypeID = p;

    $.ajax({

        type: "POST",
        url: "/Doctor/Search",
        data: data,
        success: function (result) {


            $("#doctortypenamemodel").modal("show");

            $("#doctortypeid").val(result.DoctorTypeID);
            $("#doctortypename").val(result.DoctorTypeName);
        }
    })
}




function Deletedoctortype(p) {

    data = {};

    data.DoctorTypeID = p;

    $.ajax({

        type: "POST",
        url: "/Doctor/deletedrecords",
        data: data,
        success: function (result) {

            if (result != null) {

                if (result == "delete") {
                    DoctortypeListall();
                    resetdoctortypeform();
                    $(".alertmessagedoctortype").html("Delete Records Successfully...");

                }
                else if (result == "notdelete") {
                    alert("notdeleted")
                }
                else {



                }

            }
        }
    })
}


function resetdoctortypeform() {

    $("#doctortypeid").val("");
    $("#doctortypename").val("");
    $(".doctortypenamemessage").html("");
}

$(document).ready(function () {

    resetdoctortypeform();
    $(".alertmessagedoctortype").html("");
    $("#doctortypeid").val("");
    $("#doctortypename").val("");
    $(".doctortypenamemessage").html("");
})