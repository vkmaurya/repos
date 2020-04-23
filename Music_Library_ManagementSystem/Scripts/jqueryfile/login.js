


function loginfunction() {
    data = {};

    var username = $("#username").val();
    var password = $("#password").val();
 
    data.Email = username;
    data.Password = password;

    debugger;
    $.ajax({
        type: "Post",
        url: "/login/Login",
        //data: "{customer:" + JSON.stringify(data)+"}",
        data: data,
        success: function (result) {
            debugger;
            if (result != null) {
                if (result == "InvalidUsernamePasssword") {
                    alert("Invalid Username And Password Enter valid ");
                    // var s="Invalid Username And Password Enter valid ";

                    //$("#messageshow").append();
                }
                else if (result == "userSuccess") {
                    window.location.href = '/Home/HireMediaRent';

                }
                else if (result == "adminSuccess") {

                    window.location.href = '/Admin/Masterpage';
                }
                else {
                    alert("Unknown error");

                }
               
            }
            
            

        },
        Error: function (error) {
            alert(error);
        }
    });


};