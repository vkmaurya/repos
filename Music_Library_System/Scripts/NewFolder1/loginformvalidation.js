



function loginpage() {


    data = {};
    var email = $("#email").val();

    var password = $("#password").val();

    if (email == "") {
        $("#emailmessage").html('**this field required');
        $("#emailmessage").css('color', 'red');
        return false;
    }

    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (filter.test(email.value)) {
     
        $("#emailmessage").html('Please provide a valid email address');
        $("#emailmessage").css('color', 'red');
        email.focus;
        return false;
    }

    if (password == "") {
        $("#passwordmessage").html('**this field required');
        $("#passwordmessage").css('color', 'red');
        return false;
    }

    data.Email = email;
    data.Password = password;



    $.ajax({
        type: "Post",
        url: "/Login/login",
        data: data,
        success: function (model) {

            alert("data insert Succefully");

        },
        Error: function (error) {
            alert(error);
        }
    });





};



