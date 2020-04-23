function customersaverecords() {
    data = {};


    //$(".error").html('');
    //$(".error").removeClass("error");



    var name = $("#name").val();
    var gender = $("#gender").val();
    var dob = $("#dob").val();
    var email = $("#email").val();
    var contact = $("#contact").val();
    var password = $("#password").val();
    var address = $("#address").val();
    var membership = $("#membership").val();

    if (name != "" && dob != "" && gender != "" && email != "" && contact != "" && password != "" && membership != "") {
        $('.a').val("");
        $("#mycustomerModal").modal('hide');

        data.Name = name;
        data.Gender = gender;
        data.Dob = dob;
        data.Email = email;
        data.Contact = contact;
        data.Password = password;
        data.Address = address;
        data.Membership = membership;



        $.ajax({
            type: "Post",
            url: "/Customer/AddCustomerRecords",
            data: data,
            success: function (result) {

                showmediadata();
                if (result != null) {

                    if (result == "Registrationsuccessfully") {
                        alert("Registration successfully");
                    }
                    else if (result == "Registrationfieldpleasetryagen") {
                        alert("Registration field please try agen");
                    }
                    else {
                        alert("some problem");
                    }
                }

            },
            Error: function (error) {
                showmediadata();

            }
        });
    }
    else {

    }
    showmediadata();
    $('.a').val("");
    $("#mycustomerModal").modal('hide');
};