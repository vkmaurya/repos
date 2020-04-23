

$(document).ready(function () {
    dropdownlist();
});



function dropdownlist() {

    var ddlCustomers = $("#courses");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Home/GetCourseName",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            ddlCustomers.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function (index, result) {

                ddlCustomers.append($("<option></option>").val(result.Id).html(result.CouresesName));
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



function resetform() {
    $("#name").val("");
    $("#gander").val("Select Option");
    $("#contact").val("");
    $("#email").val("");
    $("#password").val("");
    $("#address").val("");
    $("#images").val("");
    $("#courses").val(0);
    $("#dob").val("");
    $("#pincode").val("");


    $("#messagename").html("");
    $("#name").css("border", "");

    $("#messagegander").html("");
    $("#gander").css("border", "");

    $("#messagecontact").html("");
    $("#contact").css("border", "");

    $("#messageemail").html("");
    $("#email").css("border", "");

    $("#messagepassword").html("");
    $("#password").css("border", "");


    $("#messageaddress").html("");
    $("#address").css("border", "");

    $("#messageimages").html("");
    $("#images").css("border", "");

    $("#messagecourses").html("");
    $("#courses").css("border", "");

    $("#messagedob").html("");
    $("#dob").css("border", "");

    $("#messagepincode").html("");
    $("#pincode").css("border", "");


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

    if (courses == 0) {
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

    if (name != "" && namevalidation.test(name) == true && gander != "Select Option" && contact != "" && contactvalidation.test(contact) == true && email != "" && emailvalidation.test(email) == true && password != "" && passwordvalidation.test(password) == true && address != "" && addressvalidation.test(address) == true && images != "" && courses != "" && dob != "" && pincode != "" && pincodevalidation.test(pincode))
    {
       
        registration();
    }

};

function registration() {

    data = {};
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

    var formData = new FormData();
    var files = $("#images").get(0).files;


    formData.append("file", files[0]);
    formData.append("Name", name);
    formData.append("Gander", gander);
    formData.append("Contact", contact);
    formData.append("Email", email);
    formData.append("Password", password);
    formData.append("Address", address);
    formData.append("CoursesId", courses);
    formData.append("Dob", dob);
    formData.append("Pincode", pincode);
    formData.append("Images", files[0].name);
  

    $.ajax({
        type: "POST",
        url: "/Student/registration",
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,

        success: function (response) {
            if (response != null) {
                if (response == "successfully") {
                    alert("Registration Successsfully...");
                    window.location = "/Home/Index";
                }
                else if (response =="error") {
                    alert("Registration faields ! ")
                }
                else if (response == "exception") {
                    alert("oops Server Error !")
                }
                else {
                    alert("Somthing wonts Wrongs !")
                }
            }
            else {
                alert("Somthing wonts Wrongs !")
            }

        },

    });

};
