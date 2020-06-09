


function login() {

    data = {};

    var username = $("#loginemail").val();
    var userpassword = $("#loginpassword").val();
    var rexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;

    var rexpassword = /^[a-zA-Z0-9]{7,15}$/;

    if (username == "") {

        $("#messageemaillogin").html("Required this fields");
    }
    else if (!rexemail.test(username)) {
        $("#messageemaillogin").html("Invalid email lease enter correct email");
    }
    else {
        $("#messageemaillogin").html("");
    }
    //---------------------------------------------------
    if (userpassword == "") {

        $("#messagepasswordlogin").html("Required this fields");
    }
    else if (!rexpassword.test(userpassword)) {
        $("#messagepasswordlogin").html("incorrect password enter correct ");
    }
    else {
        $("#messagepasswordlogin").html("");
    }

    if (username != "" && rexemail.test(username) == true && userpassword != "" && rexpassword.test(userpassword) == true) {
        data.Email = username;
        data.Password = userpassword;

        $.ajax({

            type: "POST",
            url: "/Login/Login",
            data: data,
            success: function (result) {

                if (result != null) {
                    if (result == "patient") {
                        loginformreset();
                        window.location.href = '/Home/Appointmentpage';
                    }
                    else if (result == "doctor") {
                        window.location.href = '/Doctor/DoctorMasterPage';
                        loginformreset();
                        alert("doctor");
                    }
                    else if (result == "invalid") {

                        $("#invalidcrendtials").html("Invalid UserName And Password!");

                    }
                    else if (result == "admin") {
                        loginformreset();
                        alert("admin");
                        window.location.href = '/Admin/AdminMasterPage';
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


}


function loginformreset() {

    $("#messageemaillogin").html("");
    $("#messagepasswordlogin").html("");
    $("#loginemail").val("");
    $("#loginpassword").val("");
    $("#invalidcrendtials").html("");
}




//--------------------------------------password forgate---------------------------------------

function forgatepassword() {

    var email = $("#femail").val();

    var rexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;

    if (email == '') {
        $("#forgatepasswordmessage").html("Required this fields!");
    }
    else if (!rexemail.test(email)) {
        $("#forgatepasswordmessage").html("Invalid please Enter Valid Email");
    }
    else {
        $("#forgatepasswordmessage").html("");
    }


    if (email != '' && rexemail.test(email) == true) {

        data = {};
        data.Email = email;

        $.ajax({
            type: "POST",
            url: "/Login/EmailMatach",
            data: data,
            success: function (result) {
                if (result != null) {

                    if (result == "EmailSend") {

                        $(".otpsend").show();
                        $(".emailsend").hide();
                    }
                    else if (result == "invalidemail") {
                        $("#forgatepasswordmessage").html("invalid email enter valid email");
                    }
                    else {

                    }
                }
            }

        })
    }

}

function resetforgetform() {
    $("#femail").val("");
    $("#forgatepasswordmessage").html("");
     $("#npatientid").val();
    $("#npassord").val();
    $("#cpassword").val();

    $(".otpsend").hide();
    $(".passwordforgate").hide();
}


$(document).ready(function () {
    
    $(".emailsend").show();
    $(".otpsend").hide();
    $(".passwordforgate").hide();

    $("#npatientid").val("");
    $("#npassord").val("");
    $("#cpassword").val("");

})

function otpvarification() {

    var otpvarification = $("#otpmatech").val();
    if (otpvarification == '') {
        $("#otpvarification").html("required this field!");
    }
    else {
        $("#otpvarification").html("");
    }

    if (otpvarification != '') {

        data = {};

        data.EmailOTP= otpvarification;

        $.ajax({

            type: "POST",
            url: "/Login/otpvarification",
            data: data,
            success: function (result) {

                if (result != null) {
                    if (result == "envalaidotp") {
                        alert("invalidotp")
                    }
                    else if (result == "exception")
                    {
                        alert("exception");
                    }
                    else {
                     
                        $(".otpsend").hide();
                        $(".passwordforgate").show();
                        $("#npatientid").val(result.PatientID);
                       
                    }
                }
            }

        })
    }
}


function addnewpassword() {

    data = {};

    var patientId = $("#npatientid").val();
    var npassword = $("#npassord").val();
    var cpassword = $("#cpassword").val();

    data.PatientID = patientId;
    data.Password = cpassword;

    $.ajax({

        type: "POST",
        url: "/Login/Patientpasswordchange",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "passwordchange") {

                    alert("password Change");
                   
                    $(".passwordforgate").hide();
                    $("#passwordforgatemodel").modal("hide");
                    resetforgetform();

                }
                else if (result =="passwordnnotchange")
                {
                    $(".passwordforgate").hide();
                    alert("password Not Change");
                }
                else if (result == "exception")
                {
                    alert("Server Busy");
                }
                else {

                }
            }
        }
    })

}