



$(document).ready(function () {

    viewMemberShipList();

})

function viewMemberShipList() {

    var oTable = $("#MemberShiptable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $('#MemberShiptable').DataTable({
        "ajax": {
            "url": "/MemberShip/ViewMemberShipList",
            "type": "GET",
            "data": "{}"
        },
        "columns": [


            { "data": "MemberShipName", "autoWidth": true },
            { "data": "MemberShipDuration", "autoWidth": true },
            { "data": "MemberShipAmount", "autoWidth": true },
            { "data": "MemberShipDescription", "autoWidth": true },


            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=SearchMemberplaneId(' + row.MemberShipID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =DeleteMembershipid(' + row.MemberShipID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Deleted</button >';
                }
            }


        ]
    });
};



function savemembershipdescription() {

    var membershipid = $("#membershipid").val();
    var membername = $("#membershipname").val();
    var memberduration = $("#membershipduration").val();
    var memberamount = $("#membershipamount").val();
    var memberdescriotion = $("#membershipdescription").val();


    var regex = /^[a-zA-Z ]+$/;
    var regexnum = /^[0-9]+$/;
    var regexdesc = /^[a-zA-Z0-9  ]+$/;

    if (membername == '') {

        $("#validationmembershipname").html("Required this field!");
    }
    else if (!regex.test(membername)) {
        $("#validationmembershipname").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationmembershipname").html("");
    }
    //--------------------------------------------
    if (memberduration == '') {

        $("#validationmembershipduration").html("Required this field!");
    }
    else if (!regexnum.test(memberduration)) {
        $("#validationmembershipduration").html("Please Enter Only Number ");
    }
    else {
        $("#validationmembershipduration").html("");
    }
    //--------------------------------------------

    if (memberamount == '') {

        $("#validationmembershipamount").html("Required this field!");
    }
    else if (!regexnum.test(memberamount)) {
        $("#validationmembershipamount").html("Please Enter Only Char nNme");
    }
    else {
        $("#validationmembershipamount").html("");
    }
    //--------------------------------------------

    if (memberdescriotion == '') {

        $("#validationmembershipdescription").html("Required this field!");
    }
    else if (!regexdesc.test(memberdescriotion)) {
        $("#validationmembershipdescription").html("Please Enter Only Char Name");
    }
    else {
        $("#validationmembershipdescription").html("");
    }
    //--------------------------------------------

    //--------------------------------------------

    if (membername != '' && regex.test(membername) == true && memberduration != '' && regexnum.test(memberduration) == true && memberamount != '' && regexnum.test(memberamount) == true && memberdescriotion != '' && regexdesc.test(memberdescriotion) == true) {

        data = {};
        data.MemberShipID = membershipid;
        data.MemberShipName = membername;
        data.MemberShipDuration = memberduration;
        data.MemberShipAmount = memberamount;
        data.MemberShipDescription = memberdescriotion;

        $.ajax({

            type: "POST",
            url: "/MemberShip/CreateMemberShip",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {
                        $("#membershipsuccessmessage").html("Save Successfully...");
                        ResetFormMemberShip();
                        viewMemberShipList();
                        $("#membershipmodelModal").modal("hide");
                    }
                    else if (result == "notsave") {

                    }
                    else if (result == "update") {
                        $("#membershipsuccessmessage").html("Update Successfully...");
                        ResetFormMemberShip();
                        $("#membershipmodelModal").modal("hide");
                        viewMemberShipList();
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


function SearchMemberplaneId(memberid) {


    data = {};
    data.MemberShipID = memberid;

    $.ajax({

        type: "POST",
        url: "/MemberShip/SearchMemberShipRecords",
        data: data,
        success: function (result) {
            if (result != null) {



                $("#membershipmodelModal").modal("show");

                $("#membershipid").val(result.MemberShipID);
                $("#membershipname").val(result.MemberShipName);
                $("#membershipduration").val(result.MemberShipDuration);
                $("#membershipamount").val(result.MemberShipAmount);
                $("#membershipdescription").val(result.MemberShipDescription);

            }
        }
    })


}


function ResetFormMemberShip() {


    $("#membershipid").val("");
    $("#membershipname").val("");
    $("#membershipduration").val("");
    $("#membershipamount").val("");
    $("#membershipdescription").val("");


    $("#validationmembershipname").html("");
    $("#validationmembershipduration").html("");
    $("#validationmembershipamount").html("");
    $("#validationmembershipdescription").html("");



}



function DeleteMembershipid(memberid) {

    $("#membershipiddeleted").val(memberid);
    $("#membershipmodeldeleted").modal("show");
}

function membershipdeleted() {

    data = {};
    var mediaid = $("#membershipiddeleted").val();
    data.MemberShipID = mediaid;

    $.ajax({

        type: "POST",
        url: "/MemberShip/DeletedMemberShip",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "deleted") {

                    $("#membershipmodeldeleted").modal("hide");
                    viewMemberShipList();
                    $("#membershipsuccessmessage").html("Deleted Successfully...");
                }
                else if (result == "notdeleted") {

                    $("#membershipmodeldeleted").modal("hide");

                    alert("NotDeleted");
                }
                else if (result == "exception") {

                    alert("Server Busy...");
                    $("#membershipmodeldeleted").modal("hide");
                }
                else {

                }

            }
        }
    })
}

//------------------------------------------------------------------


