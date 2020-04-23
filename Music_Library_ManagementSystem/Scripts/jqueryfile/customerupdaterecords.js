function customerupdaterecordsave() {
    data = {};

    


    var id = $("#customeridu").val();
    var name = $("#nameu").val();
    var gender = $("#genderu").val();
    var dob = $("#dobu").val();
    var email = $("#emailu").val();
    var contact = $("#contactu").val();
    //var password = $("#passwordu").val();
    var address = $("#addressu").val();
    var membership = $("#membershipu").val();

  
    data.Id = id;
    data.Name = name;
    data.Gender = gender;
    data.Dob = dob;
    data.Email = email;
    data.Contact = contact;
    //data.Password = password;
    data.Address = address;
    data.Membership = membership;



    $.ajax({
        type: "Post",
        url: "/Customer/customerupdaterecords",
        data: data,
        success: function (model) {

            showmediadata()
            // alert("data insert Succefully");

        },
        Error: function (error) {
            // alert("not insert"+error);
        }
    });
    showmediadata();
    $("#mycustomerupdateModal").modal('hide');
};