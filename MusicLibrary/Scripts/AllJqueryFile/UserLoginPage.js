

function UserLogin() {

    var UserEmail = $("#useremail").val();
    var UserPasswoed = $("#userpassword").val();


    var regexpassword = /^[a-zA-Z0-9  ]+$/;
    var regexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;


    if (UserEmail == '') {

        $("#useremailmessage").html("Required this field!");
    }
    else if (!regexemail.test(UserEmail)) {

        $("#useremailmessage").html("Invalid UserName!");
    }

    else {
        $("#useremailmessage").html("");
    }
    //-----------------------------------------------
    if (UserPasswoed == '') {
        $("#userpasswordmessage").html("Required this field!");
    }
    else if (!regexpassword.test(UserPasswoed)) {
        $("#userpasswordmessage").html("Invalid password");
    }
    else {
        $("#userpasswordmessage").html("");
    }

    if (UserEmail != '' && UserPasswoed != '' && regexpassword.test(UserPasswoed) == true && regexemail.test(UserEmail) == true) {

        data = {};

        data.UserEmail = UserEmail;
        data.UserPasword = UserPasswoed;

        $.ajax({

            type: "POST",
            url: "/Login/UserLogin",
            data: data,
            success: function (result) {

                if (result != null) {

                    if (result == "User") {


                        
                        resetloginform();

                        window.location.href = "/Home/Index";
                    }
                    else if (result == "Admin") {

                       
                        resetloginform();
                        window.location.href = "/Admin/AdminMasterPage";
                    }
                    else if (result == "InvalidUserNameAndPassword") {

                        $("#invalidmessage").html("Invalid UserName And Password!")
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



function resetloginform() {


    $("#useremail").val("");
    $("#userpassword").val("");

    $("#useremailmessage").html("");
    $("#userpasswordmessage").html("");
}