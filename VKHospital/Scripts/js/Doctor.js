

$(document).ready(function () {
    DoctorListall();
    DoctorTypenamedropdownlist();
});

function DoctorTypenamedropdownlist() {

    var ddlCustomers = $("#doctortypenamedropdown");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "GET",
        url: "/Doctor/Doctordatatypedropdownlist",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {
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
}

function DoctorListall() {

    var oTable = $("#doctorList").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $('#doctorList').DataTable({


        "ajax": {

            "url": "/Doctor/Viewdoctor",
            "type": "POST",
            "dataType": "json",
            "contentType": 'application/json; charset=utf-8',
        },
        "columns": [

            { "data": "DoctorName", "autoWidth": true },
            { "data": "DoctorTypeName", "autoWidth": true },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchdoctordata(' + row.DoctorId + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =Deletedoctors(' + row.DoctorId + ');><i class="fa fa-trash-o" aria-hidden="true"></i>  Delete</button >';
                }
            }


        ]
    });

};







function adddoctorname() {

    data = {};
    var doctorid = $("#doctorid").val();
    var doctortypeId = $("#doctortypenamedropdown").val();
    var doctornames = $("#doctorname").val();
    var regex = /^[a-zA-Z  ]+$/;

    if (doctortypeId == 0) {
        $(".doctortypenamedropdownvalidation").html("Required this fields!");
    }
    else {
        $(".doctortypenamedropdownvalidation").html("");
    }

    if (doctornames == '') {
        $(".doctnamevalidation").html("Required this fields!");
    }
    else if (!regex.test(doctornames)) {
        $(".doctnamevalidation").html("Invalid Name please enter Valid Name");
    }
    else {
        $(".doctnamevalidation").html("");
    }

    if (doctortypeId != 0 && doctornames != '' && regex.test(doctornames) == true) {
        data.DoctorId = doctorid;
        data.DoctorTypeID = doctortypeId;
        data.DoctorName = doctornames;

        $.ajax({

            type: "POST",
            url: "/Doctor/DoctorCreateAndUpdate",
            data: data,
            success: function (result) {
                if (result != null) {

                    if (result == "add") {
                        $(".alertmessagedoctorname").html("records  Save Successfully..")
                        DoctorListall();
                        resetdoctorform();
                        $("#doctornamemodel").modal("hide");
                        $("#doctornamemodel").modal("hide");

                    }
                    else if (result == "notsave") {
                        $(".alertmessagedoctorname").html("records Not  Save")
                       
                    }
                    else if (result == "update") {
                        DoctorListall();
                        $(".alertmessagedoctorname").html("records Update successfully...")
                        $("#doctornamemodel").modal("hide");
                    }
                    else if (result == "notupdate")
                    {
                        $("#doctornamemodel").modal("hide");
                        $(".alertmessagedoctorname").html("records Not  Update!")
                    }
                    else {
                        alert("notadd")
                    }

                }
            }
        })
    }


}


function searchdoctordata(p) {

    

    data = {};
    data.DoctorId = p;

    $.ajax({

        type: "POST",
        url: "/Doctor/Searchdoctor",
        data: data,
        success: function (result) {

            if (result != null) {
                $("#doctornamemodel").modal("show");
              
                $("#doctorid").val(result.DoctorId); 
                $("#doctortypenamedropdown").val(result.DoctorTypeID);
                $("#doctorname").val(result.DoctorName);

              
            }
        }
    })
}




function Deletedoctors(p) {
   
    data = {};

    data.DoctorId = p;

    $.ajax({

        type: "POST",
        url: "/Doctor/deletedrecordsdocor",
        data: data,
        success: function (result) {

            if (result != null) {

                if (result == "delete") {
                    DoctorListall();
                    resetdoctorform();
                    $(".alertmessagedoctorname").html("records Delete  Successfully...")

                }
                else if (result == "notdelete") {
                    $(".alertmessagedoctorname").html("records not Delete")
                }
                else {

                }

            }
        }
    })
}



$(document).ready(function () {
    $(".alertmessagedoctorname").html("");
    $(".doctnamevalidation").html("");
    $(".doctortypenamedropdownvalidation").html("");
    $("#doctorid").val("");
    $("#doctortypenamedropdown").val(0);
    $("#doctorname").val("");
    resetdoctorform();
})


function resetdoctorform()
{
    $(".doctnamevalidation").html("");
    $(".doctortypenamedropdownvalidation").html("");
    $("#doctorid").val("");
    $("#doctortypenamedropdown").val(0);
    $("#doctorname").val("");
}