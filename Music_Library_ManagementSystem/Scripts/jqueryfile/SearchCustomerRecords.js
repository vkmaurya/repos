function datetimeconvert(value) {
    if (value == null) {
        return "";
    }
    else {
        if (value != '') {
            var pattern = /Date\(([^)]+)\)/;
            var result = pattern.exec(value);
            var dt = new Date(parseFloat(result[1]));
            return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
        }
        else {
            return "";
        }
    }

}

function CustomerUpdaterecordssearch(p) {
    data = {};
 
    data.Id = p;
 

    $.ajax({
        type: "Post",
        url: "/Customer/UserSearchdata",
        data: data,
        success: function (model) {


           
            $("#customeridu").val(model.Id);
            $("#nameu").val(model.Name);
            $("#genderu").val(model.Gender);
            var datetime = datetimeconvert(model.Dob);
            $("#dobu").val(datetime);
            $("#emailu").val(model.Email);
            $("#contactu").val(model.Contact);
            $("#passwordu").val(model.Password);
            $("#addressu").val(model.Address);
            $("#membershipu").val(model.Membership);



        },
        Error: function (error) {
         
           
        }
    });

    $("#mycustomerupdateModal").modal('hide');
};





function CustomerDeleterecordssearch(p) {
 

    data = {};
  
    data.Id = p;
  

    $.ajax({
        type: "Post",
        url: "/Customer/Deletemedicustomer",
        data: data,
        success: function (result) {
            showmediadata();

            if (result != null) {
                if (result == "DeleteRecords") {
                    alert("Delete Records ");

                }
                else if (result == "thisisAdmin") {
                    alert("this id admin please try again");


                }
                else {

                   // alert("Unknown error");
                }
            }
            else {
               // alert("Unknown error");
            }
        },
        Error: function (error) {
           
            
        }
    });

    showmediadata();

};