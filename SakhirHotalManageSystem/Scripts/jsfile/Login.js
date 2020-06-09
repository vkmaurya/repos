


function CustomerLogin() {

    var cemail = $("#cemaillogin").val();
    var cpassword = $("#cpasswordlogin").val();



    var regexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;
    var regexpassword = /^[a-zA-Z0-9 ]+$/;

    if (cemail == '') {
        $("#messagecemaillogin").html("Required this fields!");
        $("#cemaillogin").css("border", "2px solid red");
    }
    else if (!regexemail.test(cemail)) {
        $("#messagecemaillogin").html("Invalid email enter valid email!");
        $("#cemaillogin").css("border", "2px solid red");
    }
    else {

        $("#messagecemaillogin").html("");
        $("#cemaillogin").css("border", "2px solid green");
    }



    if (cpassword == '') {
        $("#messagecpasswordlogin").html("Required this fields!");
        $("#cpasswordlogin").css("border", "2px solid red");
    }
    else if (!regexpassword.test(cpassword)) {
        $("#messagecpasswordlogin").html("Peasw enter char and numeric");
        $("#cpasswordlogin").css("border", "2px solid red");
    }
    else {

        $("#messagecpasswordlogin").html("");
        $("#cpasswordlogin").css("border", "2px solid green");
    }




    if (cemail != '' && regexemail.test(cemail) == true && cpassword != '' && regexpassword.test(cpassword) == true) {


        data = {};
        data.CustomerEmail = cemail;
        data.CustomerPassword = cpassword;

        $.ajax({

            type: "POST",
            url: "/Login/CustomerLogin",
            data: data,
            success: function (result) {
                if (result != null) {
                    if (result == "ligin") {

                        alert("Login");
                        resetcutomerloginform();

                    }
                    else if (result == "invalid") {

                        $("#Invalimessageshow").html("Invalid UserName And Password");

                    }

                    else if (result == "exception") {

                    }
                    else {

                    }
                }
            }
        })

    }
}



function resetcutomerloginform() {

    $("#cemaillogin").val("");
    $("#cpasswordlogin").val("");


    $("#messagecpasswordlogin").html("");
    $("#cpasswordlogin").css("border", "");
    $("#messagecemaillogin").html("");
    $("#cemaillogin").css("border", "");

    $("#Invalimessageshow").html("");
}