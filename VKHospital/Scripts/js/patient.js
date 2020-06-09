
$(document).ready(function () {

    $("#dob").datepicker();

});

/*-----------------------------------------registration ---------------------------------------------------------------------------------------------*/


function registration() {

    data = {};
    var name = $("#name").val();
    var gander = $("#gander").val();
    var dob = $("#dob").val();
    var contact = $("#contact").val();
    var email = $("#email").val();
    var password = $("#password").val();
    var address = $("#address").val();


    var rgxname = /^[a-zA-Z  ]+$/;
    var rexcontact = /^\d{10}$/;
    var rexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;

    var rexpassword = /^[a-zA-Z0-9]{7,15}$/;
    var rexaddress = /^[a-zA-Z0-9 ]+$/;



    if (name == '') {
        $("#messagename").html("required this fields!");
    }
    else if (!rgxname.test(name)) {
        $("#messagename").html("please enter only character Name");
    }
    else {
        $("#messagename").html("");
    }

    /*-------------------------------------------------------------------*/
    if (gander == 'Please Select') {
        $("#messagegander").html("required this fields!");
    }
    else {
        $("#messagegander").html("");
    }
    /*-------------------------------------------------------------------*/
    if (dob == '') {
        $("#messagedob").html("required this fields!");
    }
    else {
        $("#messagedob").html("");
    }
    /*-------------------------------------------------------------------*/
    if (contact == '') {
        $("#messagecontact").html("required this fields!");
    }
    else if (!rexcontact.test(contact)) {
        $("#messagecontact").html("please enter correct number 10 digit");
    }
    else {
        $("#messagecontact").html("");
    }

    /*-------------------------------------------------------------------*/
    if (email == '') {
        $("#messageemail").html("required this fields!");
    }
    else if (!rexemail.test(email)) {
        $("#messageemail").html("invalid email enter valid email");
    }
    else {
        $("#messageemail").html("");
    }
    /*-------------------------------------------------------------------*/
    if (password == '') {
        $("#messagepassword").html("required this fields!");
    }
    else if (!rexpassword.test(password)) {

        $("#messagepassword").html("7 to 15 characters least one numeric digit");
    }
    else {
        $("#messagepassword").html("");
    }

    /*-------------------------------------------------------------------*/
    if (address == '') {
        $("#messageaddress").html("required this fields!");
    }
    else if (!rexaddress.test(address)) {
        $("#messageaddress").html("invalid address please correct address");
    }
    else {
        $("#messageaddress").html("");
    }


    if (name != "" && rgxname.test(name) == true && gander != 'Please Select' && dob != '' && contact != '' && rexcontact.test(contact) == true && email != '' && rexemail.test(email) == true && password != '' && rexpassword.test(password) == true && address != '' && rexaddress.test(address) == true) {

        data.PatientName = name;
        data.Gander = gander;
        data.DOB = dob;
        data.PhoneNumber = contact;
        data.Email = email;
        data.Password = password;
        data.Address = address;

        $.ajax({

            type: "POST",
            url: "/Patient/RegistrationandUpdate",
            data: data,
            success: function (response) {
                if (response != null) {
                    if (response == "save") {
                        alert("add");
                        ResetRegistration();
                        window.location.href = '/Login/LoginPage/';
                    }
                    else if (response == "alreadyemailexit") {

                        $("#messageemail").html("Already used email");
                    }
                    else if (response == "alreadycontactexit") {

                        $("#messagecontact").html("Already used Number");
                    }
                    else if (response == "notsave") {

                        alert("notsave");
                    }

                    else {
                        alert("exception");
                    }
                }
            }
        })

    }


}

$(document).ready(function () {

    ResetRegistration();


})

function ResetRegistration() {

    $("#name").val("");
    $("#gander").val("Please Select");
    $("#dob").val("");
    $("#contact").val("");
    $("#email").val("");
    $("#password").val("");
    $("#address").val("");


    $("#messagename").html("");
    $("#messagegander").html("");
    $("#messagedob").html("");
    $("#messagecontact").html("");
    $("#messageemail").html("");
    $("#messagepassword").html("");
    $("#messageaddress").html("");
}


/*----------------------------------------------------------------------------------------------------------*/

$(document).ready(function () {

    patientviewrecords();
})

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}

function patientviewrecords() {



    $.ajax({

        type: "GET",
        url: "/Patient/ViewPatientprofile",
        data: "{0}",
        success: function (result) {
            
            $(".ssnumber").html(result.SSNumber);
            $(".Patientname").html(result.PatientName);
            $(".DOB").html(ToJavaScriptDate(result.DOB));
            $(".Gander").html(result.Gander);
            $(".Contact").html(result.PhoneNumber);
            $(".Email").html(result.Email);
            $(".Address").html(result.Address);
            $(".ptaintid").html(result.PatientID);
            $("#PatientIDget").val(result.PatientID);

        }
    })

}


function updateprofile() {
    data = {};
    var patientid = $("#PatientIDget").val();

    data.PatientID = patientid;
    $.ajax({
        type: "POST",
        url: "/Patient/SearchProfiledata",
        data: data,
        success: function (result) {

            $("#upatientid").val(result.PatientID);
            $("#uname").val(result.PatientName);
            $("#ugander").val(result.Gander);
            $("#udob").val(ToJavaScriptDate(result.DOB));
            $("#ucontact").val(result.PhoneNumber);
            $("#uemail").val(result.Email);
            $("#uaddress").val(result.Address);

        }
    })
}




$(document).ready(function () {

    $("#udob").datepicker();

});





function patientprofileupdate() {

    data = {};

    var patientid = $("#upatientid").val();
    var name = $("#uname").val();
    var gander = $("#ugander").val();
    var dob = $("#udob").val();
    var contact = $("#ucontact").val();
    var email = $("#uemail").val();
    var address = $("#uaddress").val();


    var rgxname = /^[a-zA-Z  ]+$/;
    var rexcontact = /^\d{10}$/;
    var rexemail = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@{[a-zA-Z0-9_\-\.]+0\.([a-zA-Z]{2,5}){1,25})+)*$/;

    var rexaddress = /^[a-zA-Z0-9 ]+$/;



    if (name == '') {
        $("#umessagename").html("required this fields!");
    }
    else if (!rgxname.test(name)) {
        $("#umessagename").html("please enter only character Name");
    }
    else {
        $("#umessagename").html("");
    }

    /*-------------------------------------------------------------------*/
    if (gander == 'Please Select') {
        $("#umessagegander").html("required this fields!");
    }
    else {
        $("#umessagegander").html("");
    }
    /*-------------------------------------------------------------------*/
    if (dob == '') {
        $("#umessagedob").html("required this fields!");
    }
    else {
        $("#umessagedob").html("");
    }
    /*-------------------------------------------------------------------*/
    if (contact == '') {
        $("#umessagecontact").html("required this fields!");
    }
    else if (!rexcontact.test(contact)) {
        $("#umessagecontact").html("please enter correct number 10 digit");
    }
    else {
        $("#umessagecontact").html("");
    }

    /*-------------------------------------------------------------------*/
    if (email == '') {
        $("#umessageemail").html("required this fields!");
    }
    else if (!rexemail.test(email)) {
        $("#umessageemail").html("invalid email enter valid email");
    }
    else {
        $("#umessageemail").html("");
    }
    /*-------------------------------------------------------------------*/

    /*-------------------------------------------------------------------*/

    if (address == '') {
        $("#umessageaddress").html("required this fields!");
    }
    else if (!rexaddress.test(address)) {
        $("#umessageaddress").html("invalid address please correct address");
    }
    else {
        $("#umessageaddress").html("");
    }


    if (name != "" && rgxname.test(name) == true && gander != 'Please Select' && dob != '' && contact != '' && rexcontact.test(contact) == true && email != '' && rexemail.test(email) == true && address != '' && rexaddress.test(address) == true) {

        data.PatientID = patientid;
        data.PatientName = name;
        data.Gander = gander;
        data.DOB = dob;
        data.PhoneNumber = contact;
        data.Email = email;
        data.Address = address;

        $.ajax({

            type: "POST",
            url: "/Patient/patientupdateprofile",
            data: data,
            success: function (response) {
                if (response != null) {
                    if (response == "save") {
                        
                        alert("update Successfully...");

                        patientviewrecords();
                        $("#patientprofileupdatemodel").modal("hide");

                        

                    }
                    else if (response == "alreadyemailexit") {

                        $("#umessageemail").html("Already used email");
                    }
                    else if (response == "alreadycontactexit") {

                        $("#umessagecontact").html("Already used Number");
                    }
                    else if (response == "notsave") {

                        alert("notsave");
                    }

                    else {
                        alert("exception");
                    }
                }
            }
        })

    }


}

//------------------------------------------------------------------
