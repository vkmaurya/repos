

$(document).ready(function () {
    dropdownlist();
});

function dropdownlist() {

    var ddlCustomers = $("#coursesupdate");
    ddlCustomers.empty().append('<option selected="selected" value="0" disabled="disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Student/GetCoursnameupdate",
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








$(document).ready(function () {
    data = {};
    var id = $("#id").val();
    data.Id = id;

    $.ajax({
        type: "POST",
        url: "/Student/Search",
        data: data,
        success: function (response) {

            alert(response.Dob);
            $("#nameu").val(response.Name);
            $("#ganderu").val(response.Gander);
            $("#contactu").val(response.Contact);
            $("#emailu").val(response.Email);
            $("#pincodeu").val(response.Pincode);
            $("#addressu").val(response.Address);
            $("#dateofbirth").val(response.Dob);
            $("#imagesu").val(response.Images);

            var sdate = Date.parse(response.Dob);
            alert(sdate)
            //$("#coursesupdate").val(response.CoursesId);
           


        }

    });

});





function updaterecords() {

    var id = $("#id").val();
    var name = $("#nameu").val();
    var gander = $("#ganderu").val();

    var contact = $("#contactu").val();
    var email = $("#emailu").val();
    var password = $("#passwordu").val();
    var address = $("#addressu").val();
    var images = $("#imagesu").val();
    //var courses = $("#coursesupdate").val();
    var dob = $("#dateofbirth").val();
    var pincode = $("#pincodeu").val();

    //----------------------------reg expression--- start--------------------------------------------

    var namevalidation = /^[a-zA-Z  ]+$/;
    var contactvalidation = /^\d{10}$/;
    var emailvalidation = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var pincodevalidation = /^\d{6}$/;
    var addressvalidation = /^[a-zA-Z0-9,/\s,.'-]{3,}$/;
    var passwordvalidation = /^[A-Za-z0-9]\w{7,14}$/;

    //-------------------------------reg express end--------------------------------------------------------------

    if (name == "") {
        $("#messagenameu").html("***this fields requireds")
        $("#messagenameu").css("color", "red");
        $("#nameu").css("border", "2px solid red");
    }
    else if (!namevalidation.test(name)) {
        $("#messagenameu").html("please enter only charector not digit")
        $("#messagenameu").css("color", "red");
        $("#nameu").css("border", "2px solid red");

    }
    else {
        $("#messagenameu").html("");
        $("#nameu").css("border", "");
    }

    //--------------------------------------------------------------------------

    if (gander == "Select Option") {
        $("#messageganderu").html("***this fields requireds")
        $("#messageganderu").css("color", "red");
        $("#ganderu").css("border", "2px solid red");
    }

    else {
        $("#messageganderu").html("");
        $("#ganderu").css("border", "");
    }


    //--------------------------------------------------------------------------

    if (contact == "") {
        $("#messagecontactu").html("***this fields requireds")
        $("#messagecontactu").css("color", "red");
        $("#contactu").css("border", "2px solid red");
    }
    else if (!contactvalidation.test(contact)) {
        $("#messagecontactu").html("please enter only 10 digits mobile number")
        $("#messagecontactu").css("color", "red");
        $("#contactu").css("border", "2px solid red");
    }
    else {
        $("#messagecontactu").html("");
        $("#contactu").css("border", "");
    }

    //--------------------------------------------------------------------------

    if (email == "") {
        $("#messageemailu").html("***this fields requireds");
        $("#messageemailu").css("color", "red");
        $("#emailu").css("border", "2px solid red");
    }
    else if (!emailvalidation.test(email)) {
        $("#messageemailu").html("invalid email plaese enter valid email");
        $("#messageemailu").css("color", "red");
        $("#emailu").css("border", "2px solid red");

    }
    else {
        $("#messageemailu").html("");
        $("#emailu").css("border", "");
    }


    //--------------------------------------------------------------------------

    if (address == "") {
        $("#messageaddressu").html("***this fields requireds");
        $("#messageaddressu").css("color", "red");
        $("#addressu").css("border", "2px solid red");
    }
    else if (!addressvalidation.test(address)) {
        $("#messageaddressu").html("wrong adderess please enter wright address");
        $("#messageaddressu").css("color", "red");
        $("#addressu").css("border", "2px solid red");
    }
    else {
        $("#messageaddressu").html("");
        $("#addressu").css("border", "");
    }



    //--------------------------------------------------------------------------

    //if (courses == 0) {
    //    $("#messagecoursesu").html("***this fields requireds")
    //    $("#messagecoursesu").css("color", "red");
    //    $("#coursesupdate").css("border", "2px solid red");
    //}
    //else {
    //    $("#messagecoursesu").html("");
    //    $("#coursesupdate").css("border", "");
    //}



    //--------------------------------------------------------------------------

    if (dob == "") {
        $("#messagedobu").html("***this fields requireds")
        $("#messagedobu").css("color", "red");
        $("#dateofbirth").css("border", "2px solid red");
    }
    else {
        $("#messagedobu").html("");
        $("#dateofbirth").css("border", "");
    }



    //--------------------------------------------------------------------------

    if (pincode == "") {
        $("#messagepincodeu").html("***this fields requireds")
        $("#messagepincodeu").css("color", "red");
        $("#pincodeu").css("border", "2px solid red");
    }
    else if (!pincodevalidation.test(pincode)) {
        $("#messagepincodeu").html("please enter only six digits number")
        $("#messagepincodeu").css("color", "red");
        $("#pincodeu").css("border", "2px solid red");

    }
    else {
        $("#messagepincodeu").html("");
        $("#pincodeu").css("border", "");
    }

    


    if (name != "" && namevalidation.test(name) == true && gander != "Select Option" && contact != "" && contactvalidation.test(contact) == true && email != "" && emailvalidation.test(email) == true &&  address != "" && addressvalidation.test(address) == true  && dob != "" && pincode != "" && pincodevalidation.test(pincode)) {

        updaterecord();
    }

}

function resetformupdate() {

    $("#messagenameu").html("");
    $("#nameu").css("border", "");
    $("#nameu").val("");

    $("#messageganderu").html("");
    $("#ganderu").css("border", "");
    $("#ganderu").val("Select Option");

    $("#messagecontactu").html("");
    $("#contactu").css("border", "");
    $("#contactu").val("");

    $("#messageemailu").html("");
    $("#emailu").css("border", "");
    $("#emailu").val("");

    $("#messageaddressu").html("");
    $("#addressu").css("border", "");
    $("#addressu").val("");

    //$("#messagecoursesu").html("");
    //$("#coursesupdate").css("border", "");
    //$("#coursesupdate").val(0);

    $("#messagedobu").html("");
    $("#dateofbirth").css("border", "");
    $("#dateofbirth").val("");

    $("#messagepincodeu").html("");
    $("#pincodeu").css("border", "");
    $("#pincodeu").val("");
}





function updaterecord() {

    data = {};
    var id = $("#id").val();
    var name = $("#nameu").val();
    var gander = $("#ganderu").val();

    var contact = $("#contactu").val();
    var email = $("#emailu").val();
    var password = $("#passwordu").val();
    var address = $("#addressu").val();
    var images = $("#imagesu").val();
    //var courses = $("#coursesupdate").val();
    var dob = $("#dateofbirth").val();
    var pincode = $("#pincodeu").val();

    var formData = new FormData();
    var files = $("#imagesu").get(0).files;


    formData.append("file", files[0]);
    formData.append("Id", id);
    formData.append("Name", name);
    formData.append("Gander", gander);
    formData.append("Contact", contact);
    formData.append("Email", email);
    formData.append("Password", password);
    formData.append("Address", address);
    //formData.append("CoursesId", courses);
    formData.append("Dob", dob);
    formData.append("Pincode", pincode);
    //formData.append("Images", files[0].name);


    $.ajax({
        type: "POST",
        url: "/Student/updaterecords",
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,

        success: function (response) {
            if (response != null) {
                if (response == "successfullyupdate") {
                    alert("Registration Successsfully...");

                    window.location = "/Exame/studentMasterPage";
                }
                else if (response == "errorupdate") {
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

