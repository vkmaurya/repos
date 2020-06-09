


function CustomerRegistration() {
    var cname = $("#cname").val();
    var cgander = $("#cgander").val();
    var cemail = $("#cemail").val();
    var ccontact = $("#ccontact").val();
    var cpassword = $("#cpassword").val();
    var ccpassword = $("#ccpassword").val();

    var regexcname = /^[a-zA-Z ]+$/;
    var regexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;
    var regexcontact = /^\d{10}$/;
    var regexpassword = /^[a-zA-Z0-9 ]+$/;

    if (cname == '') {
        $("#messagecname").html("Required this fields!");

        $("#cname").css("border", "2px solid red");
    }
    else if (!regexcname.test(cname)) {
        $("#messagecname").html("Name must be in alphabets only");

        $("#cname").css("border", "2px solid red");
    }
    else {

        $("#messagecname").html("");
        $("#cname").css("border", "2px solid green");
    }

    if (cgander == 'Please Select Gander') {
        $("#messagecgander").html("Required this fields!");

        $("#cgander").css("border", "2px solid red");
    }
    else {

        $("#messagecgander").html("");
        $("#cgander").css("border", "2px solid green");
    }

    if (cemail == '') {
        $("#messagecemail").html("Required this fields!");
        $("#cemail").css("border", "2px solid red");
    }
    else if (!regexemail.test(cemail)) {
        $("#messagecemail").html("Invalid email enter valid email!");
        $("#cemail").css("border", "2px solid red");
    }
    else {

        $("#messagecemail").html("");
        $("#cemail").css("border", "2px solid green");
    }

    if (ccontact == '') {
        $("#messageccontact").html("Required this fields!");
        $("#ccontact").css("border", "2px solid red");
    }
    else if (!regexcontact.test(ccontact)) {
        $("#messageccontact").html("Invali Number enter 10 digits!");
        $("#ccontact").css("border", "2px solid red");
    }
    else {

        $("#messageccontact").html("");
        $("#ccontact").css("border", "2px solid green");
    }

    if (cpassword == '') {
        $("#messagecpassword").html("Required this fields!");
        $("#cpassword").css("border", "2px solid red");
    }
    else if (!regexpassword.test(cpassword)) {
        $("#messagecpassword").html("Peasw enter char and numeric");
        $("#cpassword").css("border", "2px solid red");
    }
    else {

        $("#messagecpassword").html("");
        $("#cpassword").css("border", "2px solid green");
    }

    if (ccpassword == '') {
        $("#messageccpassword").html("Required this fields!");
        $("#ccpassword").css("border", "2px solid red");
    }
    else if (ccpassword != cpassword) {
        $("#messageccpassword").html("password not matech");
        $("#ccpassword").css("border", "2px solid red");
    }
    else {

        $("#messageccpassword").html("");
        $("#ccpassword").css("border", "2px solid green");
    }


    if (cname != '' && regexcname.test(cname) == true && cgander != 'Please Select Gander' && cemail != '' && regexemail.test(cemail) == true && ccontact != '' && regexcontact.test(ccontact) == true && cpassword != '' && regexpassword.test(cpassword) == true && ccpassword != '' && ccpassword == cpassword) {

        data = {};


        data.CustomerName = cname;
        data.CustomerGander = cgander;
        data.CustomerEmail = cemail;
        data.CustomerContact = ccontact;
        data.CustomerPassword = ccpassword;



        $.ajax({
            type: "POST",
            url: "/Customer/CustomerRegistration",
            data: data,
            success: function (result) {

                if (result != null) {
                    if (result == "submit") {

                        alert("Registration Succefully...");
                        customerregistrationformreset();
                    }
                    else if (result == "notsubmit") {
                        alert("NotSubmit");
                    }
                    else if (result == "exception") {
                        alert("Server Busy...");
                    }
                    else if (result == "alreadyaddemail")
                    {
                        $("#messagecemail").html("already Used Email");
                    }
                    else if (result == "alreadyaddcontact") {
                        $("#messageccontact").html("Already Used Number");
                    }
                    else {

                    }
                }
            }

        })


    }

}




function customerregistrationformreset() {


    $("#cname").val("");
    $("#cgander").val("Please Select Gander");
    $("#cemail").val("");
    $("#ccontact").val("");
    $("#cpassword").val("");
    $("#ccpassword").val("");


    $("#messagecname").html("");
    $("#cname").css("border", "");

    $("#messagecgander").html("");
    $("#cgander").css("border", "");

    $("#messagecemail").html("");
    $("#cemail").css("border", "");


    $("#messageccontact").html("");
    $("#ccontact").css("border", "");


    $("#messagecpassword").html("");
    $("#cpassword").css("border", "");

    $("#messageccpassword").html("");
    $("#ccpassword").css("border", "");



}