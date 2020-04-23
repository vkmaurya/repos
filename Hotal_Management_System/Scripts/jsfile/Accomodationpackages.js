

$(document).ready(function () {
    showAccomodationpackage();
    dropdownlist();
});

function showAccomodationpackage() {

    var oTable = $("#accomodationpackagetable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $("#accomodationpackagetable").dataTable({
        "ajax": {
            "url": "/AccomodationPackages/AccomodationPackagesView",
            "type": "Post",
            "datatype": "json"
        },
        "columns": [

            { "data": "AccomodationTypeID", "name": "AccomodationTypeID", "searchable": true },

            { "data": "Name", "name": "Name", "searchable": true },
            { "data": "NoOfRoom", "name": "NoOfRoom", "searchable": true },
            { "data": "FeePerNight", "name": "FeePerNight", "searchable": true },


            {
                "data": "", "name": "", "autoWidth": true, "orderable": false,
                render: function (data, type, row) {
                    return '<button class="btn btn-info actionbutton" data-toggle="modal" data-target="#editmedia" onclick=Searchaccomodationpackage(' + row.ID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger actionbuttondelete" onclick =deleteaccomodationrecords(' + row.ID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }


        ],
        "serverSide": "true",
        "order": [0, "asc"],
        "processing": "true",
        "language": {
            "processing": '<i class="fa fa - spinner fa-spin fa-3x fa - fw" style="color: #2a2b2b; "></i><span class="sr - only">processing......please wait</span>'
        }

    });

};

$(document).ready(function () {

    $(".process").hide();
    $(".success").hide();
    $(".success1").hide();
    $(".deletediv").hide();
    $(".deletedivprocess").hide();
    $(".deletedsuccess").hide();

});

$(function dropdownlist() {
    var ddlCustomers = $("#accomodationType");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/AccomodationPackages/dropdownlistaccomodationtype",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {
                ddlCustomers.append($("<option></option>").val(result.ID).html(result.Name));
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
});

function Searchaccomodationpackage(p) {


    data = {};
    data.ID = p;

    $.ajax({

        type: "POST",
        url: "/AccomodationPackages/Searchaccomodationpackage",
        data: data,
        success: function (result) {

            $("#AccomodationPackagemodel").modal("show");
            $("#accomodationpackagesid").val(result.ID);
            $("#accomodationType").val(result.AccomodationTypeID);
            $("#nameofpackage").val(result.Name);
            $("#noofroom").val(result.NoOfRoom);
            $("#feepernight").val(result.FeePerNight);

        }


    });

}

function createandupdate() {
    var Accomodationpackageid = $("#accomodationpackagesid").val();
    var accomodationType = $("#accomodationType").val();
    var nameofpackage = $("#nameofpackage").val();
    var noofroom = $("#noofroom").val();
    var feepernight = $("#feepernight").val();



    var regexnumber = /^[0-9]{1}$/;
    var regexname = /^[a-zA-Z  ]+$/;;


    if (accomodationType == 0) {
        $("#messageaccomodationType").html("***Required this fields!");
        $("#messageaccomodationType").css("color", "red");
        $("#accomodationType").css("border", "2px solid red");
    }
    else {
        $("#messageaccomodationType").html("");
        $("#accomodationType").css("border", "2px solid green");
    }
    //----------------------------nameofpackage---------------------------------------------
    if (nameofpackage == "") {
        $("#messagenameofpackage").html("***Required this fields!");
        $("#messagenameofpackage").css("color", "red");
        $("#nameofpackage").css("border", "2px solid red");
    }
    else if (!regexname.test(nameofpackage)) {
        $("#messagenameofpackage").html("please enter ony character not number!");
        $("#messagenameofpackage").css("color", "red");
        $("#nameofpackage").css("border", "2px solid red");
    }
    else {
        $("#messagenameofpackage").html("");
        $("#nameofpackage").css("border", "2px solid green");
    }
    //------------------------------------noofroom-------------------------------------------

    if (noofroom == "") {
        $("#messagenoofroom").html("***Required this fields!");
        $("#messagenoofroom").css("color", "red");
        $("#noofroom").css("border", "2px solid red");
    }
    else if (!regexnumber.test(noofroom)) {
        $("#messagenoofroom").html("invalid room please enter only  available room 9");
        $("#messagenoofroom").css("color", "red");
        $("#noofroom").css("border", "2px solid red");
    }
    else {
        $("#messagenoofroom").html("");
        $("#noofroom").css("border", "2px solid green");
    }
    //---------------------------------feepernight-------------------------------------------
    if (feepernight == "") {
        $("#messagefeepernight").html("***Required this fields!");
        $("#messagefeepernight").css("color", "red");
        $("#feepernight").css("border", "2px solid red");
    }
    else {
        $("#messagefeepernight").html("");
        $("#feepernight").css("border", "2px solid green");
    }




    if (accomodationType != "" && nameofpackage != "" && regexname.test(nameofpackage) == true && noofroom != "" && regexnumber.test(noofroom) == true && feepernight != "") {

        $(".addandupdate").hide();
        $(".process").show();

        data = {};
        data.ID = Accomodationpackageid;
        data.AccomodationTypeID = accomodationType;
        data.Name = nameofpackage;
        data.NoOfRoom = noofroom;
        data.FeePerNight = feepernight;

        $.ajax({

            type: "POST",
            url: "/AccomodationPackages/CreatedandUpdate",
            data: data,
            success: function (result) {

                if (result != null) {

                    if (result == "addsuccess") {
                        showAccomodationpackage();
                        $(".process").hide();
                        $(".success").show();
                    }
                    else if (result == "notadd") {

                    }
                    else if (result == "exception") {

                    }
                    else if (result == "update") {
                        showAccomodationpackage();
                        $(".process").hide();
                        $(".success1").show();
                    }
                    else if (result == "notupdate") {

                    }
                }
                else {

                }
            }

        });

    }

}

function resetAccomodationpackages() {


    $("#accomodationpackagesid").val("");
    $("#accomodationType").val(0);
    $("#nameofpackage").val("");
    $("#noofroom").val("");
    $("#feepernight").val("");

    $("#accomodationpackagesid").val("");
    $("#messageaccomodationType").html("");
    $("#accomodationType").css("border", "");
    $("#messagenameofpackage").html("");
    $("#nameofpackage").css("border", "");
    $("#messagenoofroom").html("");
    $("#noofroom").css("border", "");
    $("#messagefeepernight").html("");
    $("#feepernight").css("border", "");

    $(".success").hide();
    $(".success1").hide();
    $(".addandupdate").show();
    $(".deletediv").hide();
    $(".deletedivprocess").hide();
    $(".deletedsuccess").hide();
}

function deleteaccomodationrecords(p) {

    $(".addandupdate").hide();
    $("#AccomodationPackagemodel").modal("show");
    $("#accomodationpackagesid").val(p);
    $(".deletediv").show();
}

function deleteaccomodationrecordsconfirm() {

    var ID = $("#accomodationpackagesid").val();
    $(".deletediv").hide();
    $(".deletedivprocess").show();

    data = {};
    data.ID = ID;

    $.ajax({
        type: "POST",
        url: "/AccomodationPackages/DeleteAccomodation",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "delete") {
                    showAccomodationpackage();
                    $(".deletedivprocess").hide();
                    $(".deletedsuccess").show();
                }
                else if (result == "notdelete") {

                }
                else if (result == "Exception") {

                }
                else {

                }


            }
        }


    });

}

