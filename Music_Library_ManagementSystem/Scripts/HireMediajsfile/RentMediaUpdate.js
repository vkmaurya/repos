


$(document).ready(function () {
    viewremtdata();
    showdatamediadata();

});


//--------------------------------------------------------------------------------------------







//-------------------------------------------------------------------------------------------

function ToJsDate(value) {
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


function viewremtdata() {
    //    $("#table").dataTable();

    //});
    var oTable = $("#hiretablemedia").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#hiretablemedia").dataTable({
        "ajax": {
            "url": "/RentData/GetDatarent",
            "type": "Post",
            "datatype": "json"
        },
        "columns": [

            { "data": "CustomerId", "name": "CustomerId" },
            { "data": "CustomerName", "name": "CustomerName" },
            { "data": "MediaId", "name": "MediaId" },
            { "data": "TotalAmount", "name": "TotalAmount" },
            { "data": "Address", "name": "Address" }, 
            { "data": "Contact", "name": "Contact" },
            //{ "data": "Status", "name": "Status" },
            //{ "data": "Startdate", "name": "Startdate" },

            {
                "data": "Startdate", "name": "Startdate",
                "render": function (data) {
                    return ToJsDate(data);
                }
            },

           // { "data": "Enddate", "name": "Enddate" },

            {
                "data": "Enddate", "name": "Enddate",
                "render": function (data) {
                    return ToJsDate(data);
                }
            },




            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn_details btn btn-info" data-toggle="modal" data-target="#customerdetailsmodels" onclick=s(' + row.CustomerId + ');>Details</button> <button class="btn_deete btn btn-danger" onclick=RentDeleterecordssearch(' + row.CustomerId + ');> Delete</button > ';
                }
            }

        ],
        "serverSide": "true",
        //"order": [0, "asc"],
        "processing": "true",
        //"language": {
        //    "processing": "processing......please wait"
        //}
    });

};




function RentDeleterecordssearch(p) {


    data = {};

    data.Id = p;

    $.ajax({
        type: "Post",
        url: "/RentData/Deleterent",
        data: data,
        success: function (model) {

            alert("Delete records ");
            viewremtdata();

        },
        Error: function (error) {

            alert("invalid records");
        }
    });

    viewremtdata();

};

//--------------------------------------------------------------------


function s(p) {

    data = { CustomerId: p };

    $.ajax({
        type: "Post",
        url: "/RentData/SearchCustomerDetails",
        data: data,



        success: function (success) {

            $("#customerhireshowdetails").children().remove();

            $.each(success, function (key, value) {



                $('#customerhireshowdetails').append('<tr><td>' + value.authorName + '</td><td>' + value.categoryName + '</td><td>' + value.categoryNumber + '</td><td>' + value.title + '</td><td>' + value.description + '</td><td>' + value.price + '</td></tr>');


            });




        }

    });
};


