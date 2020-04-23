$(document).ready(function () {

    showUser();

});


function showUser() {

    var oTable = $("#usertable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#usertable").dataTable({
        "ajax": {
            "url": "/User/UserView",
            "type": "Post",
            "datatype": "json"
        },
        "columns": [




            { "data": "Name", "name": "Name", "searchable": true },
            { "data": "Countery", "name": "Countery", "searchable": true },
            { "data": "City", "name": "City", "searchable": true },

            { "data": "Address", "name": "Address", "searchable": true },
            { "data": "Email", "name": "Email", "searchable": true },
            // { "data": "Dob", "name": "Dob",  },

            {
                "data": "Dob", "name": "Dob", "searchable": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },


            {
                "data": "", "name": "", "autoWidth": true, "orderable": false,
                render: function (data, type, row) {
                    return '<button class="btn btn-info actionbutton"  onclick=SearchUserId(' + row.Id + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger actionbuttondelete" onclick =deleteuser(' + row.Id + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }


        ],
        "serverSide": "true",
        "order": [0, "asc"],
        "processing": "true",
        "language": {
            "processing": '<i class="fa fa - spinner fa-spin fa-3x fa - fw" style="color: #2a2b2b; "></i><span class="sr - only">processing......please wait</span>'
        }

    });

};


function resetformuser() {
    $(".addupdatediv").show();
    $(".userprocess").hide();
    $(".userstatus").hide();
    $(".deletemessage").hide();
    $(".deletestatus").hide();
    $(".updatemessage").hide();
    $(".addupdatemessage").show();
    $(".password").show();
    $(".userdeletestatus").hide();
}


$(document).ready(function () {

    $(".addupdatediv").show();
    $(".userprocess").hide();
    $(".userstatus").hide();
    $(".deletemessage").hide();
    $(".deletestatus").hide();
    $(".updatemessage").hide();
    $(".addupdatemessage").show();
    $(".password").show();
    $(".userdeletestatus").hide();
})


function CreateUser() {
    data = {};
    var id = $("#id").val();
    var name = $("#name").val();
    var countery = $("#countery").val();
    var city = $("#city").val();
    var email = $("#email").val();
    var dob = $("#dob").val();
    var address = $("#address").val();
    var password = $("#password").val();



    data.Id = id;
    data.Name = name;
    data.Countery = countery;
    data.City = city;
    data.Address = address;
    data.Email = email;
    data.Password = password;
    data.Dob = dob;

    $(".addupdatediv").hide();
    $(".userprocess").show();
    $.ajax({
        type: "POST",
        url: "/User/AddAndUpdate",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "addsuccessfully") {
                    showUser();
                    $(".userprocess").hide();
                    $(".userstatus").show();
                }
                else if (result == "notadd") {

                }
                else if (result == "update") {
                    $(".userprocess").hide();
                    $(".userdeletestatus").show();
                }
                else if (result == "notupdate") {

                }
                else if (result == "exception") {

                }
                else {

                }
            }
        }

    })
}

function deleteuser(id) {
    $("#userModal").modal("show");
    $("#id").val(id);
    $(".addupdatediv").hide();
    $(".deletemessage").show();
}

function confirmdelete() {
    data = {};
    var id = $("#id").val();
    $(".deletemessage").hide();
    $(".userprocess").show();
    data.Id = id;
  
    $.ajax({
        type: "POST",
        url: "/User/UserDelete",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "delete") {
                    showUser();
                    $(".userprocess").hide();
                    $(".deletestatus").show();
                }
                else if (result == "notdelete") {

                }
                else if (result == "excepetion") {

                }
                else {

                }
            }

        }
    })


}


function SearchUserId(id) {
    data = {};

    data.Id = id;
    $.ajax({
        type: "POST",
        url: "/User/Search",
        data: data,
        success: function (result) {
            $("#userModal").modal("show");
            $(".addupdatemessage").hide();
            $(".updatemessage").show();
            $(".password").hide();
            
            $("#id").val(result.Id);
            $("#name").val(result.Name);
            $("#countery").val(result.Countery);
            $("#city").val(result.City);
            $("#email").val(result.Email);
            $("#dob").val(result.Dob);
            $("#address").val(result.Address); 
        }

    });
}
