$(document).ready(function () {
    DoctortypeListall();
});

function DoctortypeListall() {

    var oTable = $("#appoimentlistpatientList").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $('#appoimentlistpatientList').DataTable({

        "ajax": {

            "url": "/Appoiment/Viewpandingpatientlist",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "AppointmentBookingDate", "autoWidth": true },
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=searchdoctortypedata(' + row.DoctorTypeID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Edit</button> <button class="btn btn-danger" onclick =Deletedoctortype(' + row.DoctorTypeID + ');><i class="fa fa-trash-o" aria-hidden="true"></i> Delete</button >';
                }
            }


        ]
    });

};

