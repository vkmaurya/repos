



$(document).ready(function () {

    viewUserList();

})

function viewUserList() {

    var oTable = $("#Usertable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();


    $('#Usertable').DataTable({
        "ajax": {
            "url": "/User/ViewUserList",
            "type": "GET",
            "data": "{}"
        },
        "columns": [


            { "data": "UserName", "autoWidth": true },
            { "data": "UserEmail", "autoWidth": true },
            { "data": "UserContact", "autoWidth": true },
            { "data": "UserAddress", "autoWidth": true },
            { "data": "UserRoll", "autoWidth": true }





        ]
    });
};
