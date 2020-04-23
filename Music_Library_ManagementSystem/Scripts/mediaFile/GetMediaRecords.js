


$(document).ready(function () {
    showdatamediadata();

});




function showdatamediadata() {
    //    $("#table").dataTable();

    //});
    var oTable = $("#Tableshow").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#Tableshow").dataTable({
        "ajax": {
            "url": "/Media/GetMediaData",
            "type": "Post",
            "datatype": "json"
        },
        "columns": [
        
            { "data": "AuthorName", "name": "AuthorName" },
            { "data": "CategoryName", "name": "CategoryName" },
            { "data": "CategoryNumber", "name": "CategoryNumber" },
            { "data": "Title", "name": "Title" },
            { "data": "Description", "name": "Description" },
            { "data": "Price", "name": "Price" },
            //{ "data": "Media_Status", "name": "Media_Status" },


            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn_edt btn btn-info" data-toggle="modal" data-target="#myupdatemediaModal" onclick=searchmedia(' + row.Id + ');>Edit</button><button class="btn_deete btn btn-danger" onclick=mediaDeleterecordssearch(' + row.Id + ');> Delete</button >';
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




