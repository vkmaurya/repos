



function uSerRegistration() {



    var username = $("#name").val();
    var UserEmail = $("#email").val();
    var UserContact = $("#contact").val();
    var UserPasword = $("#password").val();
    var UserAddress = $("#address").val();


    var regexusername = /^[a-zA-Z  ]+$/;
    var regexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;
    var phoneno = /^\d{10}$/;
    var regexuserpassword = /^[a-zA-Z0-9  ]+$/;
    var regexuseraddress = /^[a-zA-Z0-9\-/  ]+$/;


    if (username == '') {

        $("#namevalidation").html("Required this field!");
    }
    else if (!regexusername.test(username)) {
        $("#namevalidation").html("Please enter only char");
    }
    else {
        $("#namevalidation").html("");
    }

    //----------------------------------------
    if (UserEmail == '') {
        $("#emailvalidation").html("Required this field!");
    }
    else if (!regexemail.test(UserEmail)) {
        $("#emailvalidation").html("Invalid Email enter valid email");
    }
    else {
        $("#emailvalidation").html("");
    }
    //-----------------------------------------------
    if (UserContact == '') {
        $("#contactvalidation").html("Required this field!");
    }
    else if (!phoneno.test(UserContact)) {
        $("#contactvalidation").html("Invalid Number");
    }
    else {
        $("#contactvalidation").html("");
    }
    //---------------------------------------------------------
    if (UserPasword == '') {
        $("#paswordvalidation").html("Required this field!");
    }
    else if (!regexuserpassword.test(UserPasword)) {
        $("#paswordvalidation").html("Enter only char and numeric");
    }
    else {
        $("#paswordvalidation").html("");
    }
    //------------------------------------------------------------
    if (UserAddress == '') {
        $("#validationaddress").html("Required this field!");
    }
    else if (!regexuseraddress.test(UserAddress)) {
        $("#validationaddress").html("Invalid address enter valid address");
    }
    else {
        $("#validationaddress").html("");
    }
    //----------------------------------------------------------

    if (username != '' && UserEmail != '' && UserContact != '' && UserPasword != '' && regexusername.test(username) == true && regexemail.test(UserEmail) == true && phoneno.test(UserContact) == true && regexuseraddress.test(UserContact) == true) {

        data = {};

        data.username = username;
        data.UserEmail = UserEmail;
        data.UserContact = UserContact;
        data.UserPasword = UserPasword;
        data.UserAddress = UserAddress;

        $.ajax({

            type: "POST",
            url: "/User/UserAccountCreate",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "save") {

                        alert("save");
                        resetform();
                    }
                    else if (result == "alredyusedemail") {
                        $("#emailvalidation").html("already used email");
                    }
                    else if (result == "alreadycontactused") {
                        $("#contactvalidation").html("already used contact");
                    }
                    else if (result == "notsave") {

                        alert("notsave");
                    }
                    else if (result == "exception") {

                        alert("Server Busy...");

                    }
                    else {

                    }
                }

            }

        })


    }


}


function resetform() {

    $("#name").val("");
    $("#email").val("");
    $("#contact").val("");
    $("#password").val("");
    $("#address").val("");



    $("#namevalidation").html("");
    $("#emailvalidation").html("");
    $("#contactvalidation").html("");
    $("#paswordvalidation").html("");
    $("#validationaddress").html("");
}