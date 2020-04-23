

$(document).ready(function () {

    showAccomodation();
    dropdownlistAccomodation();

});


function showAccomodation() {

    var oTable = $("#accomodationtable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $("#accomodationtable").dataTable({
        "ajax": {
            "url": "/Accomodation/AccomodationView",
            "type": "Post",
            "datatype": "json"
        },
        "columns": [



            { "data": "AccomodationName", "name": "AccomodationName", "searchable": true },
            { "data": "AccomodationDescription", "name": "AccomodationDescription", "searchable": true },
            { "data": "AccomodationPackageId", "name": "AccomodationPackageId", "searchable": true },


            {
                "data": "", "name": "", "autoWidth": true, "orderable": false,
                render: function (data, type, row) {
                    return '<button class="btn btn-info actionbutton" data-toggle="modal" data-target="#editmedia" onclick=SearchaccomodationId(' + row.Id + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger actionbuttondelete" onclick =deleteaccomodation(' + row.Id + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
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

$(function dropdownlistAccomodation() {
    var ddlCustomers = $("#AccomodationPackage");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Accomodation/Accomodationdropdownlist",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (result, index) {
                ddlCustomers.append($("<option></option>").val(index.ID).html(index.Name));
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


function Addaccomodation() {


    data = {};
    var accomodationpackage = $("#AccomodationPackage").val();
    var Name = $("#AccomodationName").val();
    var Description = $("#Description").val();
    var regvalidation = /^[A-Za-z0-9  ]+$/;
    var id = $("#accomodationid").val();
    if (accomodationpackage == 0) {
        $("#msgAccomodationPackage").html("***Required this fields");
        $("#msgAccomodationPackage").css("color", "red");
        $("#AccomodationPackage").css("border-bottom", "2px solid red");
    }
    else {
        $("#msgAccomodationPackage").html("");
        $("#AccomodationPackage").css("border-bottom", "2px solid green");
    }


    //-------------------------------------------------------------------------------------


    if (Name == "") {
        $("#msgAccomodationName").html("***Required this fields");
        $("#msgAccomodationName").css("color", "red");
        $("#AccomodationName").css("border-bottom", "2px solid red");
    }
    else if (!regvalidation.test(Name)) {

        $("#msgAccomodationName").html("please enter valid name");
        $("#msgAccomodationName").css("color", "red");
        $("#AccomodationName").css("border-bottom", "2px solid red");
    }
    else {
        $("#msgAccomodationName").html("");
        $("#AccomodationName").css("border-bottom", "2px solid green");
    }

    //----------------------------------------------------------------------------------------------------

    if (Description == "") {
        $("#msgDescription").html("please enter valid Description");
        $("#msgDescription").css("color", "red");
        $("#Description").css("border-bottom", "2px solid red")
    }
    else if (!regvalidation.test(Description)) {
        $("#msgDescription").html("***Required this fields");
        $("#msgDescription").css("color", "red");
        $("#Description").css("border-bottom", "2px solid red")
    }
    else {
        $("#msgDescription").html("");
        $("#Description").css("border-bottom", "2px solid green");
    }



    if (accomodationpackage != 0 && Name != "" && regvalidation.test(Name) == true && Description != "" && regvalidation.test(Description) == true) {

        data.ID = id;
        data.AccomodationPackageId = accomodationpackage;
        data.AccomodationName = Name;
        data.AccomodationDescription = Description;

        $(".addandupdatediv").hide();
        $(".addheading").hide();
        $(".accomodationprocess").show();
        $(".accomodationprocess1").show();

        $.ajax({

            type: "POST",
            url: "/Accomodation/CreateandUpdate",
            data: data,
            success: function (result) {
                if (result != null) {

                    if (result == "addsuccess") {
                        showAccomodation();
                        $(".accomodationprocess").hide();
                        $(".accomodationstatus").show();

                    }
                    else if (result == "notadd") {

                    }
                    else if (result == "update") {
                        showAccomodation();
                        $(".accomodationprocess").hide();
                        $(".accomodationstatus1").show();
                    }
                    else if (result == "notupdate") {

                    }
                    else if (result == "exception") {

                    }
                    else {

                    }

                }
                else {

                }

            }
        })

    }
}


$(document).ready(function () {
    $(".addandupdatediv").show();
    $(".addheading").show();
    $(".updateheading").hide();
    $(".accomodationprocess").hide();
    $(".accomodationstatus").hide();

    $(".accomodationstatus1").hide();
    $(".allhide").show();
    $(".deletedive").hide();

    $(".accomodationstatus2").hide();
})

function accomodationreset() {
    $("#AccomodationPackage").val(0);
    $("#AccomodationName").val("");
    $("#Description").val("");
    $("#msgAccomodationPackage").html("");
    $("#AccomodationPackage").css("border-bottom", "");
    $("#msgAccomodationName").html("");
    $("#AccomodationName").css("border-bottom", "");
    $("#msgDescription").html("");
    $("#Description").css("border-bottom", "");



    $(".addandupdatediv").show();
    $(".addheading").show();

    $(".accomodationprocess").hide();
    $(".accomodationstatus").hide();

    $(".accomodationstatus1").hide();
    $(".addheading").show();
    $(".updateheading").hide();

    $(".allhide").show();
    $(".deletedive").hide();

    $(".accomodationstatus2").hide();
}

function SearchaccomodationId(p) {

    data = {};
    data.Id = p;

    $.ajax({

        type: "POST",
        url: "/Accomodation/Search",
        data: data,
        success: function (result) {

            $("#exampleModal").modal("show");
            $(".addheading").hide();
            $(".updateheading").show();
            $("#AccomodationPackage").val(result.AccomodationPackageId);
            $("#AccomodationName").val(result.AccomodationName);
            $("#Description").val(result.AccomodationDescription);
            $("#accomodationid").val(result.Id);


        }

    });
}


function deleteaccomodation(p) {

    $("#exampleModal").modal("show");
    $(".allhide").hide();
    $("#accomodationid").val(p);
    $(".deletedive").show();

}

function deleteAccomodationconfirm() {

  
    data = {};
    $(".deletedive").hide();
    $(".accomodationprocess").show();
    var id = $("#accomodationid").val();
    data.Id = id;

    $.ajax({

        type: "POST",
        url: "/Accomodation/Accomoddel",
        data: data,

        success: function (result) {
            if (result != null) {
                if (result == "delete") {
                    showAccomodation();
                    $(".accomodationprocess").hide();
                    $(".accomodationstatus2").show();
                }
                else if (result == "notdelete") {

                }

                else {

                }
            }
        }
    });
}