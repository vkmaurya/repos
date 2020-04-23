

//$(document).ready(function () {
//    var table = $('#accomodationtypetable').DataTable();
//});

$(document).ready(function () {

    showAccomodationType();
    $(".addicon").hide();
    $(".updateIcon").hide();
    $(".hidediv").show();
    $(".hidedivmessage").show();
    $(".hidedivupdate").hide();
    $(".messagehidedive").show();
    $(".deleterecords").hide();
    $(".deleterecordsmessagesuccess").hide();
});

function showAccomodationType() {

    var oTable = $("#accomodationtypetable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $("#accomodationtypetable").dataTable({
        "ajax": {
            "url": "/AccomodationTypes/AccomodationTypeView",
            "type": "Post",
            "datatype": "json"
        },
        "columns": [

            { "data": "Name", "name": "Name", "searchable": true },
            { "data": "Description", "name": "Description", "searchable": true },


            {
                "data": "", "name": "", "autoWidth": true, "orderable": false,
                render: function (data, type, row) {
                    return '<button class="btn btn-info actionbutton" data-toggle="modal" data-target="#editmedia" onclick=Search(' + row.ID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger actionbuttondelete" onclick =deleterecords(' + row.ID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
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

function resetaccomodationtype() {

    $("#messagename").html("");
    $("#name").css("border", "");
    $("#id").val("");
    $("#name").val("");
    $("#messagedescription").html("");
    $("#description").css("border", "");
    $("#description").val("");
    $(".addicon").hide();
    $(".updateIcon").hide();
    $(".hidediv").show();
    $(".hidedivmessage").show();
    $(".hidedivupdate").hide();
    $(".messagehidedive").show();
    $(".deleterecords").hide();
    $(".deleterecordsmessagesuccess").hide();





}


function addAccomodation() {

    data = {};

    var Id = $("#id").val();
    var name = $("#name").val();
    var description = $("#description").val();
    var regName = /^[a-zA-Z  ]+$/;




    if (name == "") {
        $("#messagename").html("***Required this fields");
        $("#messagename").css("color", "red");
        $("#name").css("border", "2px solid red");

    }
    else if (!regName.test(name)) {
        $("#messagename").html("please enter only character! not number");
        $("#messagename").css("color", "red");
        $("#name").css("border", "2px solid red");
    }
    else {
        $("#messagename").html("");
        $("#name").css("border", "2px solid green");
    }

    //---------------------------description validation--------------------------------------------

    if (description == "") {
        $("#messagedescription").html("***Required this fields");
        $("#messagedescription").css("color", "red");
        $("#description").css("border", "2px solid red");

    }

    else if (!regName.test(description)) {
        $("#messagedescription").html("please enter only character! not number");
        $("#messagedescription").css("color", "red");
        $("#description").css("border", "2px solid red");
    }
    else {
        $("#messagedescription").html("");
        $("#description").css("border", "2px solid green");
    }


    if (!name == "" && regName.test(name) == true && !description == "" && regName.test(description) == true) {
        data.ID = Id;
        data.Name = name;
        data.Description = description;


        $.ajax({

            type: "POST",
            url: "/AccomodationTypes/Create",
            data: data,

            success: function (response) {

                if (response != null) {


                    if (response == "success") {
                        showAccomodationType();
                        $(".hidediv").hide();
                        $(".hidedivmessage").hide();
                        $(".updateIcon").hide();
                        $(".addicon").show();
                    }
                    else if (response == "error") {

                    }
                    else if (response == "exception") {

                    }
                    else if (response == "update") {
                        showAccomodationType();
                        $(".hidediv").hide();
                        $(".hidedivmessage").hide();
                        $(".hidedivupdate").hide();
                        $(".updateIcon").show();
                    }
                    else if (response == "notUpdate") {

                    }

                }
                else {

                }
            }



        });
    }



}

function Search(p) {
    data = {};
    data.ID = p;



    $.ajax({

        type: "POST",
        url: "/AccomodationTypes/Search",
        data: data,
        success: function (result) {

            $("#exampleModal").modal("show");
            $(".hidedivmessage").hide();
            $(".hidedivupdate").show();
            $("#id").val(result.ID);
            $("#name").val(result.Name);
            $("#description").val(result.Description);

        }


    })

}


function deleterecords(p) {

    $("#exampleModal").modal("show");
    $(".deleterecordsmessage").show();
    $(".messagehidedive").hide();
    $(".deleterecords").show();
    $("#deleteId").val(p);

}

function deleterecordsconfirm() {

    data = {};

    var Id = $("#deleteId").val();

    data.ID = Id;

    $.ajax({
        type: "POST",
        url: "/AccomodationTypes/Delete",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "delete") {


                    showAccomodationType();
                    $(".deleterecordsmessage").hide();
                    $(".deleterecords1").hide();
                    $(".deleterecordsmessagesuccess").show();


                }
                else if (result == "") {

                }
                else {

                }
            }


        }
    })

}
