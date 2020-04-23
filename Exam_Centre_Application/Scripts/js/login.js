

function login() {
    var username = $("#email").val();
    var password = $("#password").val();

    var emailvalidation = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var passwordvalidation = /^[A-Za-z0-9]\w{7,14}$/;


    if (username == "") {
        $("#messageemail").html("***Required this fields");
        $("#email").css("border-bottom", "2px solid red");
        $("#messageemail").css("color", "red");
    }
    else if (!emailvalidation.test(username)) {
        $("#messageemail").html("***please Enter Valid Email");
        $("#email").css("border-bottom", "2px solid red");
        $("#messageemail").css("color", "red");
      
    }
    else {
        $("#messageemail").html("");
        $("#email").css("border-bottom", "");
    }

    if (password == "") {
        $("#messagepassword").html("***Required this fields");
        $("#password").css("border-bottom", "2px solid red");
        $("#messagepassword").css("color", "red");
    }

    else if (!passwordvalidation.test(password)) {
        $("#messagepassword").html("Please enter correct password");
        $("#password").css("border-bottom", "2px solid red");
        $("#messagepassword").css("color", "red");

    }

    else {

        $("#messagepassword").html("");
        $("#password").css("border-bottom", "");
    }

    if (username != "" && emailvalidation.test(username) == true && password != "" && passwordvalidation.test(password) == true) {

        loginstudent();
    }
};




function loginstudent() {

    data = {};
    var username = $("#email").val();
    var password = $("#password").val();

    data.Email = username;
    data.Password = password;

    $.ajax({
        type: "Post",
        url: "/Home/StudentLogin",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "login") {


                    window.location = "/Exame/studentMasterPage/";

                }
                else if (result == "invalid") {

                    alert("Invalid username And Password");

                }
            }
            else {


            }
        }
    });


};



$(document).ready(function () {

    dropdownlistemail();
});


function dropdownlistemail() {

    var ddlCustomers = $("#emaildropdownlist");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Home/emaildropdownlist",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {

                ddlCustomers.append($("<option></option>").val(result.Email).html(result.Email));
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
};

$(document).ready(function () {

    $("#emaildropdownlis").chosen({
        disable_search_threshold: 5
    });
});



function reset() {

    $("#emailvalidation").html("");
    $("#emaildropdownlist").css("border-bottom", "");
    
}

$(document).ready(function () {

    $(".otpconfirm").hide();
    $(".passworddive").hide();

});


function otpsend() {

    var email = $("#emaildropdownlist").val();

    $("#emaisend").html("Please Waite EmailSend...");
    $("#emaisend").css("color", "green");
    $(".emailsendotp").hide();
    $("#a").hide();
    $("#b").hide();
    
    if (email == 0) {

        $("#emailvalidation").html("***Please Select Email");
        $("#emailvalidation").css("color", "red");
        $("#emaildropdownlist").css("border-bottom", "2px solid red");
    }
    else {
        $("#emailvalidation").html("");
        $("#emaildropdownlist").css("border-bottom", "");
    }

    if (email != "") {
        data = {};
        data.Email = email;

        $.ajax({
            type: "POST",
            url: "/Student/emailotpsend",
            data: data,
            success: function (response) {
                if (response != null) {
                    if (response == "EmailSend") {

                        
                        $(".otpsend").hide()
                        $(".otpconfirm").show()
                    }
                    else if (response == "invalid") {
                        alert("MailFaield");
                    }
                    else {

                    }
                }
            }
        });

    }
}