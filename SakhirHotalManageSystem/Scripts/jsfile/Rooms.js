
$(document).ready(function () {
    RoomsList() 
})

function RoomsList() {

    var oTable = $("#rooms").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#rooms").DataTable({

        "ajax": {

            "url": "/Rooms/ViewRooms",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "AccommodationTypeName" },
            { "data": "AccommodationPackageName" },
            { "data": "FeePerNight" },
            { "data": "NoOfRoom" },         
             { "data": "AccommodationName" }

        ]
    })
}
