
$(document).ready(function () {

    ViewrolseList();
});

function ViewrolseList() {

    var oTable = $("#viewrolselist").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#viewrolselist").DataTable({

        "ajax": {

            "url": "/Roles/ViewRoles",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "RolesName" },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchrolesid(' + row.RolesId + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =Rolesdeletes(' + row.RolesId + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }
        ]
    })
}


function rolseaddandupdate() {

    var rollid = $("#rolseid").val();
    var rollname = $("#rolsename").val();
    var regexAccmmodation = /^[a-zA-Z ]+$/;
    if (rollname == '') {
        $("#accommodationtypevalidation").html("Name Field cannot be left empty");
        $("#accomodationtypename").css("border-bottom", "2px solid red");
    }
    else if (!regexAccmmodation.test(rollname)) {
        $("#accommodationtypevalidation").html("Name must be in alphabets only");
        $("#accomodationtypename").css("border-bottom", "2px solid red");
    }
    else {
        $("#accommodationtypevalidation").html("");
        $("#accomodationtypename").css("border-bottom", "");
    }

    if (rollname != '' && regexAccmmodation.test(rollname) == true) {

        data = {};
        data.RolesId = rollid;
        data.RolesName = rollname;
        $.ajax({

            type: "POST",
            url: "/Roles/Rolesaddandupdate",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {

                        $("#accomodationallmessage").html("Save Successfully...");
                        ViewrolseList();
                        $("#RolseModal").modal("hide");
                        Resetrolseform();
                    }
                    else if (result == "notsave") {
                        alert("notsave")
                    }
                    else if (result == "exception") {
                        alert("server busy...")
                    }
                    else if (result == "update") {

                        $("#accomodationallmessage").html("Update Successfully...");
                        ViewrolseList();
                        $("#RolseModal").modal("hide");
                        Resetrolseform();
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



function searchrolesid(roleId) {

    var rolseid = roleId;

    data = {};
    data.RolesId = rolseid;

    $.ajax({

        type: "POST",
        url: "/Roles/SearchRolesid",
        data: data,
        success: function (result) {


            if (result != null) {

                $("#RolseModal").modal("show");
                $("#rolseid").val(result.RolesId);
                $("#rolsename").val(result.RolesName);
            }
        }
    })

}


function Rolesdeletes(id) {

    $("#rolesModaldelete").modal("show");
    $("#rolseiddelete").val(id);
}

function deleterolseconfirms() {

    data = {};
    var rolesid = $("#rolseiddelete").val();

    data.RolesId = rolesid;

    $.ajax({

        type: "POST",
        url: "/Roles/DeletedRoles",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "deleted") {
                    $("#rolesModaldelete").modal("hide");
                    ViewrolseList();
                    $("#accomodationallmessage").html("Deleted Successfully...");
                    Resetrolseform();
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


function Resetrolseform() {

    $("#rolseid").val("");
    $("#rolsename").val("");
    $("#accommodationtypevalidation").html("");
    $("#accomodationtypename").css("border-bottom", "");
}