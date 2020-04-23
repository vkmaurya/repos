
function ToJSDate(value) {
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

};



$(document).ready(function () {
    showmediadata();

});




function showmediadata() {
    //  $("#table").dataTable();

    //});
    var oTable = $("#customerTable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#customerTable").dataTable({
        "ajax": {
            "url": "/Customer/GetData",
            "type": "Post",
            "datatype": "json"
        },
        "dataSrc": function (json) {
           debugger
        },
        "columns": [

            { "data": "Name", "name": "Name" },
            { "data": "Gender", "name": "Gender" },
            //{ "data": "Dob", "name": "Dob" },

            {
                "data": "Dob", "name": "Dob",
                "render": function (data) {
                    return ToJSDate(data);
                }
            },

            { "data": "Email", "name": "Email" },
            { "data": "Contact", "name": "Contact" },
            { "data": "Address", "name": "Address" },
            { "data": "Membership", "name": "Membership" },
            { "data": "Roll", "name": "Roll" },
            //{ "data": "IsValid", "name": "IsValid" },

            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn_edt btn btn-info" data-toggle="modal" data-target="#mycustomerupdateModal" onclick=CustomerUpdaterecordssearch(' + row.Id + ');>Edit</button> <button class="btn_deete btn btn-danger" onclick=CustomerDeleterecordssearch(' + row.Id + ');> Delete</button > ';
                }
            }

        ],
        "serverSide": "true",
       // "order": [0, "asc"],
        "processing": "true",
        //"language": {
        //    "processing": "processing......please wait"
        //}
    });

};




