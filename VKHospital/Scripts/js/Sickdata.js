
$(document).ready(function () {
    ViewSickAllData();
    DoctorTypenamedropdownlist2();
});




function DoctorTypenamedropdownlist2() {

    var ddlCustomers = $("#dtype");
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



function ViewSickAllData() {
    var oTable = $("#sickalldata").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $('#sickalldata').DataTable({

        "ajax": {

            "url": "/Doctor/ViewSick",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "SickTypeName", "autoWidth": true },
            { "data": "DoctorTypeName", "autoWidth": true },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchSickdata(' + row.SickTypeID + ');>Edit</button> <button class="btn btn-danger" onclick =Deletedoctor(' + row.SickTypeID + ');> Delete</button >';
                }
            }

        ]
    });

};


function savesickname() {

    data = {};
    var sid = $("#sid").val();
    var Sname = $("#sname").val();
    var Dtypename = $("#dtype").val();
    var regexname = /^[a-zA-Z ]+$/;
    if (Sname == '') {

        $(".snamevalidation").html("Required this fields!");
    }
    else if (!regexname.test(Sname))
    {
        $(".snamevalidation").html("Please enter only charectar Name");
    }
    else {
        $(".snamevalidation").html("");
    }

    if (Dtypename == 0) {
        $(".dtypenamevalidation").html("Required this fields!");
    }
    else {
        $(".dtypenamevalidation").html("");
    }

    if (Sname != '' && Dtypename != 0 && regexname.test(Sname) == true) {


        data.SickTypeID = sid;
        data.SickTypeName = Sname;
        data.DoctorTypeID = Dtypename;

        $.ajax({

            type: "POST",
            url: "/Doctor/SickCreateandUpdate",
            data: data,
            success: function (result) {

                if (result != null) {

                    if (result == "save") {
                        $(".alertmessagesick").html("Records Save Successfully...");
                        ViewSickAllData();
                        $("#sickModal").modal("hide");
                        
                    }
                    else if (result == "notesave") {

                        $(".alertmessagesick").html("Records Not Save");
                    }
                    else if (result == "update")
                    {
                        ViewSickAllData();
                        $(".alertmessagesick").html("Records update Successfully...");
                        $("#sickModal").modal("hide");
                    }
                    else if (result == "noteupdate")
                    {
                        $(".alertmessagesick").html("Records notupdate!");
                        $("#sickModal").modal("hide");
                    }
                    else {

                    }
                }
            }
        });

    }
};


function searchSickdata(id) {
    data = {};

    data.SickTypeID = id;
    $.ajax({

        type: "POST",
        url: "/Doctor/SearchSick",
        data: data,
        success: function (result) {
            $("#sickModal").modal('show');
            $("#sid").val(result.SickTypeID);
            $("#dtype").val(result.DoctorTypeID);
            $("#sname").val(result.SickTypeName);

        }

    })
}

function Deletedoctor(p) {

    data = {};

    data.SickTypeID = p;

    $.ajax({

        type: "POST",
        url: "/Doctor/deletedrecordssick",
        data: data,
        success: function (result) {

            if (result != null) {

                if (result == "delete") {
                    $(".alertmessagesick").html("Records Delete Successfully...");
                    ViewSickAllData();

                }
                else if (result == "notdelete") {
                    $(".alertmessagesick").html("Records Not Delete ");
                    ViewSickAllData();
                }
                else {

                }

            }
        }
    })
}


