

function customerregistration()
{
    var namevalidation = /^[a-zA-Z ]*$/;
   // var datetime = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
 

  //  var datetime= /^(0[1-9]|[12][0-9]|3[01])[\- \/.](?:(0[1-9]|1[012])[\- \/.](19|20)[0-9]{2})$/;
    var emailvalidation = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var contactvalidation = /^[1-9]{1}[0-9]{9}$/;
    var addressvalidation = /^[a-zA-Z0-9()--/\  ]*$/;
    //--------------------------------------------
    var name = $("#name").val();
    var dob = $("#dob").val();
  
    //var myDate = new Date(dob);
    //var today = new Date();

    var gender = $("#gender").val();
    var email = $("#email").val();
    var contact = $("#contact").val();
    var address = $("#address").val();
    var password = $("#password").val();
    var membership = $("#membership").val();


    //---------------------------------Name Validation -------------------------------------

 

    if (name == "") {
        $("#nameErrerMessage").html('**this field required');
        $("#nameErrerMessage").css("color", "red");
    }
    else if (!namevalidation.test(name))
    {
        $("#nameErrerMessage").html('Please Enter only alphabets in textme');
        $("#nameErrerMessage").css("color", "red");
        //return false;
    }
    else
    {
        $("#nameErrerMessage").html('');      
    }

    //-----------------------------------Dob Validation ---------------------------------------------

    if (dob == "") {
        $("#dobErrerMessage").html('**this field required');
        $("#dobErrerMessage").css("color", "red");
    }
    //else if (!datetime.test(dob))
    //{
    //    $("#dobErrerMessage").html('invalid date Please Enter valide date');
    //    $("#dobErrerMessage").css("color", "red");
    //}
    //else if ( myDate <= today)
    //     {
    //    $("#dobErrerMessage").html('invalid dob Please Enter valide Dob');
    //    $("#dobErrerMessage").css("color", "red");
    //    }
    else {
        $("#dobErrerMessage").html('');
    }


//----------------------------------Gender validation -----------------------------------------------

    if (gender == "") {
        $("#genderErrerMessage").html('**this field required');
        $("#genderErrerMessage").css("color", "red");
    }
    else {
        $("#genderErrerMessage").html('');
    }



    //----------------------------------email validation -------------------------------------------------------

    if (email == "") {
        $("#emailErrerMessage").html('**this field required');
        $("#emailErrerMessage").css("color", "red");
    }
    else if (!emailvalidation.test(email))
    {
        $("#emailErrerMessage").html('invalid Email Please Enter valide Email');
        $("#emailErrerMessage").css("color", "red");
    }
    else {
        $("#emailErrerMessage").html('');
    }

    //-----------------------Contact Validation -------------------------------------------------------------------



    if (contact == "") {
        $("#contactErrerMessage").html('**this field reguired');
        $("#contactErrerMessage").css("color", "red");
    }
    else if (!contactvalidation.test(contact))
    {
        $("#contactErrerMessage").html('invalid number Please Enter 10 digit');
        $("#contactErrerMessage").css("color", "red");
        return false;
    }
    else {
        $("#contactErrerMessage").html('');
        true;
    }

    //-----------------------------Address Validation -------------------------------------------------

    if (address == "") {
        $("#addressErrerMessage").html('**this field required');
        $("#addressErrerMessage").css("color", "red");
    }
    else if (!addressvalidation.test(address))
    {
        $("#addressErrerMessage").html('invalid address Please Enter valid address');
        $("#addressErrerMessage").css("color", "red");
    }
    else {
        $("#addressErrerMessage").html('');
    }

    //---------------------member ship----------------------------------------------

    if (membership == "") {

        $("#membershipErrerMessage").html('**this field reguired');
        $("#membershipErrerMessage").css("color", "red");
    }
    else {
        $("#membershipErrerMessage").html('');
    }

    //-------------------------------------------------------------------------------

    if (password == "") {
        $("#passwordErrerMessage").html('**this field reguired');
        $("#passwordErrerMessage").css("color", "red");
    }
    else {
        $("#passwordErrerMessage").html('');
    }

    if (name != "" && namevalidation.test(name) == true && dob != "" && /*datetime.test(dob) == true &&*/ gender != "" && email != "" && emailvalidation.test(email) == true && contact != "" && contactvalidation.test(contact) == true && address != "" && addressvalidation.test(address) == true && password != "" && membership != "") {

        customersaverecords();
      
       
    }


};