
$(document).ready(function () {

    Viewlistuser();
});

$(function () {
    $("#userdob").datepicker();
});

function Viewlistuser() {

    var oTable = $("#viewUserList").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#viewUserList").DataTable({

        "ajax": {

            "url": "/User/ViewUserListAll",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "UserName" },
            { "data": "UserAdharNumber" },
            { "data": "UserEmail" },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-primary"  onclick=SearchUserId(' + row.UserID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-info" onclick =userdetailsrecords(' + row.UserID + ');><i class="fa fa-info" aria-hidden="true"></i> Details</button > <button class="btn btn-success" onclick =userassigen(' + row.UserID + ');><i class="fa fa-user-o" aria-hidden="true"></i> RoleAssign</button ><button class="btn btn-danger" onclick =userdeleted(' + row.UserID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }
        ]
    })
}




function addandupdateuser() {

    data = {};

    var userid = $("#userid").val();
    var username = $("#username").val();
    var usergander = $("#usergander").val();
    var useremail = $("#useremail").val();
    var usercontact = $("#usercontact").val();
    var userdob = $("#userdob").val();
    var useradharnumber = $("#useradharnumber").val();
    var userpassword = $("#userpassword").val();
    var useraddress = $("#useraddress").val();


    var regexname = /^[a-zA-Z  ]+$/;
    var regexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;
    var regxphoneno = /^\d{10}$/;
    var regxadhar = /^\d{14}$/;
    var regexpasword = /^[a-zA-Z0-9  ]+$/;
    var regeaddress = /^[a-zA-Z0-9\-/ ]+$/;




    if (username == '') {
        $("#messageusername").html("Required this fileds!");
    }
    else if (!regexname.test(username)) {

        $("#messageusername").html("Name must be in alphabets only");
    }
    else {
        $("#messageusername").html("");
    }
    //----------------------------------------------------

    if (usergander == 'Please Select') {
        $("#messageusergander").html("Reqiored this fileds!");
    }
    else {
        $("#messageusergander").html("");
    }
    //----------------------------------------------------
    if (useremail == '') {
        $("#messageuseremail").html("Required this fileds!");
    }
    else if (!regexemail.test(useremail)) {

        $("#messageuseremail").html("This is not a valid email address");
    }
    else {
        $("#messageuseremail").html("");
    }
    //----------------------------------------------------
    if (usercontact == '') {
        $("#messageusercontact").html("Required this fileds!");
    }
    else if (!regxphoneno.test(usercontact)) {
        $("#messageusercontact").html("This is not a valid phone number");
    }
    else {
        $("#messageusercontact").html("");
    }
    //----------------------------------------------------
    if (userdob == '') {
        $("#messageuserdob").html("Required this fileds!");
    }
    else {
        $("#messageuserdob").html("");
    }
    //----------------------------------------------------
    if (useradharnumber == '') {
        $("#messageuseradharnumber").html("Required this fileds!");
    }
    else if (!regxadhar.test(useradharnumber)) {
        $("#messageuseradharnumber").html("please enter 14 digit number");
    }
    else {
        $("#messageuseradharnumber").html("");
    }
    //----------------------------------------------------
    if (userpassword == '') {
        $("#messageuserpassword").html("Required this fileds!");
    }
    else if (!regexpasword.test(userpassword)) {
        $("#messageuserpassword").html("Please enter only char and numeric digits");
    }
    else {
        $("#messageuserpassword").html("");
    }
    //----------------------------------------------------
    if (useraddress == '') {
        $("#messageuseraddress").html("Required this fileds!");
    }
    else if (!regeaddress.test(useraddress)) {
        $("#messageuseraddress").html("Invalid Address Enter valid address");
    }
    else {
        $("#messageuseraddress").html("");
    }
    //----------------------------------------------------

    if (username != '' && regexname.test(username) == true && useremail != '' && regexemail.test(useremail) == true && usercontact != '' && regxphoneno.test(usercontact) == true && useraddress != '' && regeaddress.test(useraddress) == true && userpassword != '' && regexpasword.test(userpassword) == true && useradharnumber != '' && regxadhar.test(useradharnumber) == true && userdob != '' && usergander != 'Please Select') {


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


                        Viewlistuser();
                        $("#useraddModal").modal("hide");
                        resetuserform();
                        $("#usermeddage").html("Save Successfully...");
                    }
                    else if (result == "notsave") {
                        alert("notsave")
                    }
                    else if (result == "update") {
                        resetuserform();
                        $("#usermeddage").html("Update Successfully...");
                        Viewlistuser();
                        $("#useraddModal").modal("hide");
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

function SearchUserId(userid) {

    data = {};

    data.UserID = userid

    $.ajax({

        type: "POST",
        url: "/User/Searchuseridrecords",
        data: data,
        success: function (result) {
            if (result != null) {

                $("#useraddModal").modal("show");
                $("#userid").val(result.UserID);
                $("#username").val(result.UserName);
                $("#usergander").val(result.Gander);
                $("#useremail").val(result.UserEmail);
                $("#usercontact").val(result.UserContact);
                $("#userdob").val(ToJsDate(result.DOB));
                $("#useradharnumber").val(result.UserAdharNumber);
                $("#userpassword").val(result.UserPassword);
                $("#useraddress").val(result.UserAddress);
            }
            else {

            }
        }

    })


}

function userdetailsrecords(userid) {

    data = {};
    data.UserID = userid;

    $.ajax({

        type: "POST",
        url: "/User/ViewUserDetails",
        data: data,
        success: function (result) {
            if (result != null) {

                $("#userdetailsModal").modal("show");

                $("#dusername").html(result.UserName);
                $("#duserrole").html(result.RolesId);
                $("#dgander").html(result.Gander);
                $("#ddob").html(ToJsDate(result.DOB));
                $("#duseradharnumber").html(result.UserAdharNumber);
                $("#duseremail").html(result.UserEmail);
                $("#dusercontact").html(result.UserContact);
                $("#duserpassword").html(result.UserPassword);
                $("#duseraddress").html(result.UserAddress);
                $("#dcreatedate").html(ToJsDate(result.CreatedByDate));

            }
        }
    });

}


function userassigen(userId) {

    $("#RoleAssignModal").modal("show");
    $("#userroleassignid").val(userId);
}

$(document).ready(function () {

    $.ajax({

        type: "GET",
        url: "/Roles/ViewRolesDropdownlist",
        data: "{}",
        success: function (result) {

            $.each(result, function (index, response) {

                var data = '<tr><th>' + response.RolesName + '</th> <td><button style="margin-left:40px;" type="button" class="btn btn-success" onclick="roleuserassign(' + response.RolesId + ');"> <span><i class="fa fa-user-circle" aria-hidden="true"></i> RoleAssign</span></button></td></tr>';
                $("#roleview").append(data);
            });
        }

    })

})


function roleuserassign(roleid) {

    data = {};
    var rolid = roleid;
    var userid = $("#userroleassignid").val();


    data.UserRolesID = roleid;
    data.UserID = userid;

    $.ajax({

        type: "POST",
        url: "/User/RoleAssignUser",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "save") {
                    Viewlistuser();
                    $("#RoleAssignModal").modal("hide");
                    $("#usermeddage").html("RoleAssign Successfully...");
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

//------------------------------------------------------------------------------


function userdeleted(userid) {

    $("#uuserdeletedid").val(userid);
    $("#uuserdeleteModal").modal("show");
}

function userconfirmuserdeleted() {

    data = {};
    var userid = $("#uuserdeletedid").val();
    data.UserID = userid;

    $.ajax({

        type: "POST",
        url: "/User/Deleteduser",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "deleted") {
                    $("#usermeddage").html("Deleted Successfully...");
                    Viewlistuser();
                    $("#uuserdeleteModal").modal("hide");
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

function resetuserform() {

    $("#userid").val("");
    $("#username").val("");
    $("#usergander").val("Please Select");
    $("#useremail").val("");
    $("#usercontact").val("");
    $("#userdob").val("");
    $("#useradharnumber").val("");
    $("#userpassword").val("");
    $("#useraddress").val("");


    $("#messageusername").html("");
    $("#messageusergander").html("");
    $("#messageuseremail").html("");
    $("#messageusercontact").html("");
    $("#messageuserdob").html("");
    $("#messageuseradharnumber").html("");
    $("#messageuserpassword").html("");
    $("#messageuseraddress").html("");
}