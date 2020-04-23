

function login() {

    var emailvalidation = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    //------------------------------------------
    var username = $("#username").val();
    var password = $("#password").val();


    //-----------------------username validation -------------------------------------
    if (username == "") {
        $("#emailErrerMessage").html('**this field required');
        $("#emailErrerMessage").css("color", "red");
    }
    else if (!emailvalidation.test(username)) {
        $("#emailErrerMessage").html('invalid Email Please Enter valide Email');
        $("#emailErrerMessage").css("color", "red");
    }
    else {
        $("#emailErrerMessage").html('');
    }
    //---------------------password validation -------------------------------------------
    if (password == "") {
        $("#passwordErrerMessage").html('**this field required');
        $("#passwordErrerMessage").css("color", "red");
    }
    else {
        $("#passwordErrerMessage").html('');
    }

    if (username != "" && emailvalidation.test(username) == true && password != "") {
   


        loginfunction();

    }
};