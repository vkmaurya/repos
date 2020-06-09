


$(document).ready(function () {
    $('#allpatientList').DataTable({

        "ajax": {

            "url": "/Patient/GetAllPatientsdata",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "PatientName", "autoWidth": true },
            { "data": "SSNumber", "autoWidth": true },
            //   { "data": "DOB", "autoWidth": true },

            {
                "data": "DOB", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },


            { "data": "Gander", "autoWidth": true },

            { "data": "PhoneNumber", "autoWidth": true },
            { "data": "Email", "autoWidth": true },
            { "data": "Address", "autoWidth": true }

        ]
    });
});



//{ "data": "PatientName", "autoWidth": true },
//{ "data": "SSNumber", "autoWidth": true },
//{ "data": "DOB", "autoWidth": true }
//{ "data": "Gander", "autoWidth": true },
//{ "data": "PhoneNumber", "autoWidth": true },
//{ "data": "Email", "autoWidth": true },
//{ "data": "Address", "autoWidth": true },
//{ "data": "Roll", "autoWidth": true },
//{ "data": "AddrIsValidess", "autoWidth": true }