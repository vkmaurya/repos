
function customerupdaterecordsvalidation() {
    var namevalidation = /^[a-zA-Z ]*$/;
    var datetime = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
    var emailvalidation = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var contactvalidation = /^[1-9]{1}[0-9]{9}$/;
    var addressvalidation = /^[a-zA-Z0-9()--/\  ]*$/;
    //--------------------------------------------
    var id = $("#customeridu").val();
    var name = $("#nameu").val();
    var dob = $("#dobu").val();
    var gender = $("#genderu").val();
    var email = $("#emailu").val();
    var contact = $("#contactu").val();
    var address = $("#addressu").val();
    var password = $("#passwordu").val();
    var membership = $("#membershipu").val();



    //---------------------------------Name Validation -------------------------------------
    if (name == "") {
        $("#nameuErrerMessage").html('**this field required');
        $("#nameuErrerMessage").css("color", "red");
    }
    else if (!namevalidation.test(name)) {
        $("#nameuErrerMessage").html('Please Enter only alphabets in textme');
        $("#nameuErrerMessage").css("color", "red");
    }
    else {
        $("#nameuErrerMessage").html('');
    }

    //-----------------------------------Dob Validation ---------------------------------------------

    if (dob == "") {
        $("#dobuErrerMessage").html('**this field required');
        $("#dobuErrerMessage").css("color", "red");
    }
    else if (!datetime.test(dob)) {
        $("#dobuErrerMessage").html('invalid date Please Enter valide date');
        $("#dobuErrerMessage").css("color", "red");
    }
    else {
        $("#dobuErrerMessage").html('');
    }


    //----------------------------------Gender validation -----------------------------------------------

    if (gender == "") {
        $("#genderuErrerMessage").html('**this field required');
        $("#genderuErrerMessage").css("color", "red");
    }
    else {
        $("#genderuErrerMessage").html('');
    }



    //----------------------------------email validation -------------------------------------------------------

    if (email == "") {

        $("#emailuErrerMessage").html('**this field required');
        $("#emailuErrerMessage").css("color", "red");
    }
    else if (!emailvalidation.test(email)) {
        $("#emailuErrerMessage").html('invalid Email Please Enter valide Email');
        $("#emailuErrerMessage").css("color", "red");
    }
    else {
        $("#emailuErrerMessage").html('');
    }

    //-----------------------Contact Validation -------------------------------------------------------------------



    if (contact == "") {
        $("#contactuErrerMessage").html('**this field required');
        $("#contactuErrerMessage").css("color", "red");
    }
    else if (!contactvalidation.test(contact)) {
        $("#contactuErrerMessage").html('invalid number Please Enter 10 digit');
        $("#contactuErrerMessage").css("color", "red");
    }
    else {
        $("#contactuErrerMessage").html('');
    }

    //-----------------------------Address Validation -------------------------------------------------

    if (address == "") {
        $("#addressuErrerMessage").html('**this field required');
        $("#addressuErrerMessage").css("color", "red");
    }
    else if (!addressvalidation.test(address)) {
        $("#addressuErrerMessage").html('invalid address Please Enter valid address');
        $("#addressuErrerMessage").css("color", "red");
    }
    else {
        $("#addressuErrerMessage").html('');
    }

    //---------------------member ship----------------------------------------------

    if (membership == "") {

        $("#membershipuErrerMessage").html('**this field required');
        $("#membershipuErrerMessage").css("color", "red");
    }
    else {
        $("#membershipuErrerMessage").html('');
    }

    //-------------------------------------------------------------------------------

    if (password == "") {
        $("#passworduErrerMessage").html('**this field required');
        $("#passworduErrerMessage").css("color", "red");
    }
    else {
        $("#passworduErrerMessage").html('');
    }

    //if (name != "" && dob != "" && gender != "" && email != "" && contact != "" && password != "" && membership != "") {
    if (name != "" && namevalidation.test(name) == true && dob != "" && datetime.test(dob) == true && gender != "" && email != "" && emailvalidation.test(email) == true && contact != "" && contactvalidation.test(contact) == true && address != "" && addressvalidation.test(address) == true && password != "" && membership != "") {

        customerupdaterecordsave();


    }


};