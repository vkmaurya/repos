
$(document).ready(function () {

    ViewuserroleList();
});

$(function () {
    $("#ruserdob").datepicker();
});


function ViewuserroleList() {

    var oTable = $("#viewUserRoleList").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#viewUserRoleList").DataTable({

        "ajax": {

            "url": "/User/ViewUserListAllRoledefine",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "UserName" },
            { "data": "UserAdharNumber" },
            { "data": "RolesName" },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-primary"  onclick=rSearchUserId(' + row.UserID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-info" onclick =ruserdetails(' + row.UserID + ');><i class="fa fa-info" aria-hidden="true"></i> Details</button > <button class="btn btn-success" onclick =ruserassigen(' + row.UserID + ');><i class="fa fa-user-o" aria-hidden="true"></i>  RoleAssign</button ><button class="btn btn-danger" onclick =userdelete(' + row.UserID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }
        ]
    })
}




function roleaddandupdateuser() {

    data = {};

    var userid = $("#ruserid").val();
    var username = $("#rusername").val();
    var usergander = $("#rusergander").val();
    var useremail = $("#ruseremail").val();
    var usercontact = $("#rusercontact").val();
    var userdob = $("#ruserdob").val();
    var useradharnumber = $("#ruseradharnumber").val();
    var userpassword = $("#ruserpassword").val();
    var useraddress = $("#ruseraddress").val();

    var regexname = /^[a-zA-Z  ]+$/;
    var regexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;
    var regxphoneno = /^\d{10}$/;
    var regxadhar = /^\d{14}$/;
    var regexpasword = /^[a-zA-Z0-9  ]+$/;
    var regexaddres = /^[a-zA-Z0-9\-/ ]+$/;




    if (username == '') {
        $("#messageusernamee").html("Required this fileds!");
    }
    else if (!regexname.test(username)) {

        $("#messageusernamee").html("Name must be in alphabets only");
    }
    else {
        $("#messageusernamee").html("");
    }
    //----------------------------------------------------

    if (usergander == 'Please Select') {
        $("#messageusergandere").html("Reqiored this fileds!");
    }
    else {
        $("#messageusergandere").html("");
    }
    //----------------------------------------------------
    if (useremail == '') {
        $("#messageuseremaile").html("Required this fileds!");
    }
    else if (!regexemail.test(useremail)) {

        $("#messageuseremaile").html("This is not a valid email address");
    }
    else {
        $("#messageuseremaile").html("");
    }
    //----------------------------------------------------
    if (usercontact == '') {
        $("#messageusercontacte").html("Required this fileds!");
    }
    else if (!regxphoneno.test(usercontact)) {
        $("#messageusercontacte").html("This is not a valid phone number");
    }
    else {
        $("#messageusercontacte").html("");
    }
    //----------------------------------------------------
    if (userdob == '') {
        $("#messageuserdobe").html("Required this fileds!");
    }
    else {
        $("#messageuseruserdobe").html("");
    }
    //----------------------------------------------------
    if (useradharnumber == '') {
        $("#messageuseradharnumbere").html("Required this fileds!");
    }
    else if (!regxadhar.test(useradharnumber)) {
        $("#messageuseradharnumbere").html("please enter 14 digit number");
    }
    else {
        $("#messageuseradharnumbere").html("");
    }
    //----------------------------------------------------
    if (userpassword == '') {
        $("#messageuserpassworde").html("Required this fileds!");
    }
    else if (!regexpasword.test(userpassword)) {
        $("#messageuserpassworde").html("Please enter only char and numeric digits");
    }
    else {
        $("#messageuserpassworde").html("");
    }
    //----------------------------------------------------
    if (useraddress == '') {
        $("#messageuseraddresse").html("Required this fileds!");
    }
    else if (!regexaddres.test(useraddress)) {
        $("#messageuseraddresse").html("Invalid Address Enter valid address");
    }
    else {
        $("#messageuseraddresse").html("");
    }
    //----------------------------------------------------

    if (username != '' && regexname.test(username) == true && useremail != '' && regexemail.test(useremail) == true && usercontact != '' && regxphoneno.test(usercontact) == true && useraddress != '' && regexaddres.test(useraddress) == true && userpassword != '' && regexpasword.test(userpassword) == true && useradharnumber != '' && regxadhar.test(useradharnumber) == true && userdob != '' && usergander != 'Please Select') {

        data.UserID = userid;
        data.UserName = username;
        data.UserEmail = useremail;
        data.UserContact = usercontact;
        data.UserAddress = useraddress;
        data.UserPassword = userpassword;
        data.UserAdharNumber = useradharnumber;
        data.DOB = userdob;
        data.Gander = usergander;

        $.ajax({

            type: "POST",
            url: "/User/Useraddandupdate",
            data: data,
            success: function (result) {

                if (result != null) {
                    if (result == "save") {

                        $("#userrolemessage").html("Sve Successfully...");
                        ViewuserroleList();
                        $("#ruseraddModal").modal("hide");
                    }
                    else if (result == "notsave") {
                        alert("notsave")
                    }
                    else if (result == "update") {
                        $("#userrolemessage").html("Update Successfully...");
                        ViewuserroleList();
                        resetrolsesform();
                        $("#ruseraddModal").modal("hide");
                    }

                    else if (result == "notupdate") {
                        alert("notupdate")
                    }
                    else if (result == "exception") {
                        alert("exception")
                    }
                    else {

                    }
                }
            }
        })

    }


}

function resetrolsesform() {
    $("#messageusernamee").html("");
    $("#messageusergandere").html("");
    $("#messageuseremaile").html("");
    $("#messageusercontacte").html("");
    $("#messageuserdobe").html("");
    $("#messageuseradharnumbere").html("");
    $("#messageuserpassworde").html("");
    $("#messageuseraddresse").html("");
}

function rSearchUserId(userid) {

    data = {};

    data.UserID = userid

    $.ajax({

        type: "POST",
        url: "/User/Searchuseridrecords",
        data: data,
        success: function (result) {
            if (result != null) {


                $("#ruseraddModal").modal("show");
                resetrolsesform();
                $("#ruserid").val(result.UserID);
                $("#rusername").val(result.UserName);
                $("#rusergander").val(result.Gander);
                $("#ruseremail").val(result.UserEmail);
                $("#rusercontact").val(result.UserContact);
                $("#ruserdob").val(ToJsDate(result.DOB));
                $("#ruseradharnumber").val(result.UserAdharNumber);
                $("#ruserpassword").val(result.UserPassword);
                $("#ruseraddress").val(result.UserAddress);
            }
            else {

            }
        }

    })


}

function ruserdetails(userid) {

    data = {};
    data.UserID = userid;

    $.ajax({

        type: "POST",
        url: "/User/ViewUserDetailsRole",
        data: data,
        success: function (result) {
            if (result != null) {

                $("#ruserdetailsModal").modal("show");


                $("#rdusername").html(result.UserName);
                $("#rduserrole").html(result.RolesName);
                $("#rdgander").html(result.Gander);
                $("#rddob").html(ToJsDate(result.DOB));
                $("#rduseradharnumber").html(result.UserAdharNumber);
                $("#rduseremail").html(result.UserEmail);
                $("#rdusercontact").html(result.UserContact);
                $("#rduserpassword").html(result.UserPassword);
                $("#rduseraddress").html(result.UserAddress);
                $("#rdcreatedate").html(ToJsDate(result.CreatedByDate));

            }
        }
    });

}


function ruserassigen(userId) {

    $("#rRoleAssignModal").modal("show");
    $("#ruserroleassignid").val(userId);
}

$(document).ready(function () {

    $.ajax({

        type: "GET",
        url: "/Roles/ViewRolesDropdownlist",
        data: "{}",
        success: function (result) {

            $.each(result, function (index, response) {

                var data = '<tr><th>' + response.RolesName + '</th> <td><button style="margin-left:40px;" type="button" class="btn btn-success" onclick="rroleuserassign(' + response.RolesId + ');"> <span><i class="fa fa-user-circle" aria-hidden="true"></i> RoleAssign</span></button></td></tr>';
                $("#rroleview").append(data);
            });
        }

    })

})


function rroleuserassign(roleid) {

    data = {};
    var rolid = roleid;
    var userid = $("#ruserroleassignid").val();


    data.UserRolesID = roleid;
    data.UserID = userid;

    $.ajax({

        type: "POST",
        url: "/User/RoleAssignUser",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "save") {
                    ViewuserroleList();
                    $("#userrolemessage").html("RoleAsign Change Successfully...");
                    $("#rRoleAssignModal").modal("hide");
                }

                else if (result == "notsave") {
                    alert("RpleNotAssign");
                }
                else if (result == "exception") {
                    alert("exception");
                }
            }
        }
    })


}


function userdelete(userid) {

    $("#userdeletedid").val(userid);
    $("#userdeleteModal").modal("show");
}

function confirmuserdeleted() {

    data = {};
    var userid = $("#userdeletedid").val();
    data.UserID = userid;

    $.ajax({

        type: "POST",
        url: "/User/Deleteduser",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "deleted") {
                    $("#userrolemessage").html("Deleted Successfully...");
                    ViewuserroleList();
                    $("#userdeleteModal").modal("hide");
                }
                else if (result == "notdelete") {
                    alert("notdelete");
                }
                else if (result == "exception") {
                    alert("exception");
                }
                else {

                }
            }
        }
    })


}