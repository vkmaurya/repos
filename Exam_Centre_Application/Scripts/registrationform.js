function resetform() {
    $("#name").val("");
    $("#gander").val("");
    $("#contact").val("");
    $("#email").val("");
    $("#password").val("");
    $("#address").val("");
    $("#images").val("");
    $("#courses").val("");
    $("#dob").val("");
    $("#pincode").val("");
};


function Submit() {


    var name = $("#name").val();
    var gander = $("#gander").val();

    var contact = $("#contact").val();
    var email = $("#email").val();
    var password = $("#password").val();
    var address = $("#address").val();
    var images = $("#images").val();
    var courses = $("#courses").val();
    var dob = $("#dob").val();
    var pincode = $("#pincode").val();

    //-----------------------regulaerExpression validation-------------------------------------------
    var namevalidation = /^[a-zA-Z  ]+$/;
    var contactvalidation = /^\d{10}$/;
    var emailvalidation = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var pincodevalidation = /^\d{6}$/;
    var addressvalidation = /^[a-zA-Z0-9,/\s,.'-]{3,}$/;
    var passwordvalidation = /^[A-Za-z0-9]\w{7,14}$/;
    //var passwordvalidation = /^(?=.*\d)(?=.*[a-z0-9])(?=.*[A-Z0-9]).{7,17}$/;




    //-------------------------dob--------------------------------------------

    //-----------------------------------------------------------------------------------------------

    if (name == "") {
        $("#messagename").html("*** Required this fields");
        $("#messagename").css("color", "red");
        $("#name").css("border", "2px solid red");

    }
    else if (!namevalidation.test(name)) {
        $("#messagename").html("***Enter Only Charcater not Number");
        $("#messagename").css("color", "red");
        $("#name").css("border", "2px solid red");

    }
    else {
        $("#messagename").html("");
        $("#name").css("border", "");

    }

    //----------------------------gander-------------------------------------
    if (gander == "Select Option") {
        $("#messagegander").html("*** Required this fields");
        $("#messagegander").css("color", "red");
        $("#gander").css("border", "2px solid red");

    }
    else {
        $("#messagegander").html("");
        $("#gander").css("border", "");

    }
    //---------------------------------------------------------------------------------
    if (contact == "") {
        $("#messagecontact").html("*** Required this fields");
        $("#messagecontact").css("color", "red");
        $("#contact").css("border", "2px solid red");

    }
    else if (!contactvalidation.test(contact)) {
        $("#messagecontact").html("***Please Enter only 10 Digit number");
        $("#messagecontact").css("color", "red");
        $("#contact").css("border", "2px solid red");

    }
    else {
        $("#messagecontact").html("");
        $("#contact").css("border", "");

    }
    //---------------------------------------------------------------------------------
    if (email == "") {
        $("#messageemail").html("*** Required this fields");
        $("#messageemail").css("color", "red");
        $("#email").css("border", "2px solid red");

    }
    else if (!emailvalidation.test(email)) {

        $("#messageemail").html("*** Invalid Email Please Enter Valid Email ");
        $("#messageemail").css("color", "red");
        $("#email").css("border", "2px solid red");

    }
    else {
        $("#messageemail").html("");
        $("#email").css("border", "");

    }

    //--------------------------------------------------------------------------------

    if (password == "") {
        $("#messagepassword").html("*** Required this fields");
        $("#messagepassword").css("color", "red");
        $("#password").css("border", "2px solid red");

    }
    else if (!passwordvalidation.test(password)) {
        $("#messagepassword").html("***Please enter Minimum 8 digits 2 charactor must");
        $("#messagepassword").css("color", "red");
        $("#password").css("border", "2px solid red");
    }
    else {
        $("#messagepassword").html("");
        $("#password").css("border", "");

    }


    //--------------------------------------------------------------------------------------
    if (address == "") {
        $("#messageaddress").html("*** Required this fields");
        $("#messageaddress").css("color", "red");
        $("#address").css("border", "2px solid red");

    }
    else if (!addressvalidation.test(address)) {
        $("#messageaddress").html("***Invalid Address Please Enter Valide Address");
        $("#messageaddress").css("color", "red");
        $("#address").css("border", "2px solid red");

    }

    else {
        $("#messageaddress").html("");
        $("#address").css("border", "");

    }

    //-----------------------------------------------------------------------------------------

    if (images == "") {
        $("#messageimages").html("*** Required this fields");
        $("#messageimages").css("color", "red");
        $("#images").css("border", "2px solid red");

    }
    else {
        $("#messageimages").html("");
        $("#images").css("border", "");

    }

    //-------------------------------------------------------------------------------------------

    if (courses == "Select Option") {
        $("#messagecourses").html("*** Required this fields");
        $("#messagecourses").css("color", "red");
        $("#courses").css("border", "2px solid red");

    }
    else {
        $("#messagecourses").html("");
        $("#courses").css("border", "");

    }


    //---------------------------------------------------------------------------------------------------------------



    if (dob == "") {
        $("#messagedob").html("*** Required this fields");
        $("#messagedob").css("color", "red");
        $("#dob").css("border", "2px solid red");

    }
    else {
        $("#messagedob").html("");
        $("#dob").css("border", "");

    }

    //---------------------------------------------------------------------------------------------------------------------

    if (pincode == "") {
        $("#messagepincode").html("*** Required this fields");
        $("#messagepincode").css("color", "red");
        $("#pincode").css("border", "2px solid red");

    }

    else if (!pincodevalidation.test(pincode)) {
        $("#messagepincode").html("***Invalid Pincode Please Enter valide pincode");
        $("#messagepincode").css("color", "red");
        $("#pincode").css("border", "2px solid red");
    }
    else {
        $("#messagepincode").html("");
        $("#pincode").css("border", "");

    }

};