
$(document).ready(function () {

    ViewHotalBookingList();
    ViewHotalBookingListcheckin();
    ViewHotalBookingoutList();
})




function ViewHotalBookingList() {

    var oTable = $("#hotalbookingtable").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#hotalbookingtable").DataTable({

        "ajax": {

            "url": "/Booking/ViewBookingList",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "GuestName", "autoWidth": true, },
            { "data": "BookingEmail", "autoWidth": true, },
            {
                "data": "BookingDate", "autoWidth": true,

                render: function (data) {
                    return data = ToJsDate(data);
                    
                }
            },

            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=bookingDetails(' + row.BookingID + ');><i class="fa fa-asterisk" aria-hidden="true"></i> Details</button> <button class="btn btn-primary" onclick =HotalBookingCheckin(' + row.BookingID + ');><i class="fa fa-angle-double-down" aria-hidden="true"></i> CheckIn</button >';
                }
            }
        ]
    })
}


function bookingDetails(bookingid) {

    var id = bookingid;

    data = {};

    data.BookingID = id;

    $.ajax({

        type: "POST",
        url: "/Booking/ViewHotalBookingRecords",
        data: data,
        success: function (response) {

            if (response != null) {

                $("#hotalbookingdetailsModal").modal("show");

                $("#GuestName").html(response.GuestName);
                $("#BookingEmail").html(response.BookingEmail);
                $("#BookingDate").html(ToJsDate(response.BookingDate));
                $("#CheckInDate").html(ToJsDate(response.CheckInDate));
                $("#AccommodationTypeName").html(response.AccommodationTypeName);
                $("#AccommodationPackageName").html(response.AccommodationPackageName);
                $("#FeePerNight").html(response.FeePerNight);
                $("#Duration").html(response.Duration);
                $("#NoOfAdults").html(response.NoOfAdults);
                $("#NoOfChildren").html(response.NoOfChildren);
                $("#AccommodationName").html(response.AccommodationName);
                $("#NoOfRoom").html(response.NoOfRoom);
                $("#CustomerName").html(response.CustomerName);
                $("#CustomerContact").html(response.CustomerContact);

                var total = response.Duration * response.FeePerNight;
                $("#totalAmount").html(total);
            }


        }
    })


}


function HotalBookingCheckin(bookingId) {

    $("#bookingcheckinid").val(bookingId);
    $("#hotalcheckinmodel").modal("show");

}


function customercheckin()
{
    data = {};
    var bookinid = $("#bookingcheckinid").val();

    data.BookingID = bookinid;

    $.ajax({
        type: "POST",
        url: "/Booking/BookingCheckIn",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "checkIn") {

                    ViewHotalBookingList();
                    $("#bookingstatusmessage").html("CheckIn Done")
                    $("#hotalcheckinmodel").modal("hide")
                }
                else if (result == "notcheckin")
                {
                    

                    alert("notcheckIn");

                }

                else if (result == "exception") {

                    alert("Server Busy...");
                }
                else {

                }
            }
        }
    })
}

//------------------------------Booking checkin---------------------------------------------



function ViewHotalBookingListcheckin() {

    var oTable = $("#hotalbookingtableCheckin").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#hotalbookingtableCheckin").DataTable({

        "ajax": {

            "url": "/Booking/ViewBookingListCheckIn",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "GuestName", "autoWidth": true, },
            { "data": "BookingEmail", "autoWidth": true, },
            {
                "data": "CheckInDate", "autoWidth": true,

                render: function (data) {
                    return data = ToJsDate(data);

                }
            },

            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=bookingDetailscheckin(' + row.BookingID + ');><i class="fa fa-asterisk" aria-hidden="true"></i> Details</button> <button class="btn btn-primary" onclick =CustomerCheckOut(' + row.BookingID + ');><i class="fa fa-angle-double-up" aria-hidden="true"></i> CheckOut</button >';
                }
            }
        ]
    })
}


function bookingDetailscheckin(bookingid) {

    var id = bookingid;

    data = {};

    data.BookingID = id;

    $.ajax({

        type: "POST",
        url: "/Booking/ViewHotalBookingRecordsCheckList",
        data: data,
        success: function (response) {

            if (response != null) {

                $("#hotalbookingdetailsModalCheck").modal("show");

                $("#GuestNamecheckin").html(response.GuestName);
                $("#BookingEmailcheckin").html(response.BookingEmail);
                $("#BookingDatecheckin").html(ToJsDate(response.BookingDate));
                $("#CheckInDatecheckin").html(ToJsDate(response.CheckInDate));
                $("#AccommodationTypeNamecheckin").html(response.AccommodationTypeName);
                $("#AccommodationPackageNamecheckin").html(response.AccommodationPackageName);
                $("#FeePerNightcheckin").html(response.FeePerNight);
                $("#Durationcheckin").html(response.Duration);
                $("#NoOfAdultscheckin").html(response.NoOfAdults);
                $("#NoOfChildrencheckin").html(response.NoOfChildren);
                $("#AccommodationNamecheckin").html(response.AccommodationName);
                $("#NoOfRoomcheckin").html(response.NoOfRoom);
                $("#CustomerNamecheckin").html(response.CustomerName);
                $("#CustomerContactcheckin").html(response.CustomerContact);

                var total = response.Duration * response.FeePerNight;
                $("#totalAmountcheckin").html(total);
            }


        }
    })


}


function CustomerCheckOut(bookingid) {

    $("#bookingcheckout").val(bookingid);

    $("#bookingcheckoutmodel").modal("show");
}


function bookingcheckout() {

    var bookingid = $("#bookingcheckout").val();
    data = {};
    data.BookingID = bookingid;

    $.ajax({

        type: "POST",
        url: "/Booking/BookingCheckOut",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "checkOut") {

                    ViewHotalBookingListcheckin();
                    $("#bookingstatusmessagecheckout").html("CheckOut Customer Successfully")
                    $("#bookingcheckoutmodel").modal("hide");
                }
                else if (result == "notcheckOut")
                {

                }
                else if (result == "exception") {

                }
                else {

                }
            }
        }
    })

}

//-----------------------------Booking checkout-----------------------------------------------------------

function ViewHotalBookingoutList() {

    var oTable = $("#hotalbookingtableCheckout").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $("#hotalbookingtableCheckout").DataTable({

        "ajax": {

            "url": "/Booking/ViewBookingListCheckOu",
            "type": "GET",
            "datatype": "Json"
        },

        "columns": [

            { "data": "GuestName", "autoWidth": true, },
            { "data": "BookingEmail", "autoWidth": true, },
            {
                "data": "CheckInDate", "autoWidth": true,

                render: function (data) {
                    return data = ToJsDate(data);

                }
            },

            {
                "data": "CheckOutDate", "autoWidth": true,

                render: function (data) {
                    return data = ToJsDate(data);

                }
            },

            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<button class="btn btn-info"  onclick=bookingDetailsout(' + row.BookingID + ');><i class="fa fa-asterisk" aria-hidden="true"></i> Details</button>';
                }
            }
        ]
    })
}


function bookingDetailsout(bookingid) {

    var id = bookingid;

    data = {};

    data.BookingID = id;

    $.ajax({

        type: "POST",
        url: "/Booking/ViewHotalBookingRecordsChecoutkList",
        data: data,
        success: function (response) {

            if (response != null) {

                $("#hotalbookingdetailsModalcheckout").modal("show");

                $("#GuestNamecheckout").html(response.GuestName);
                $("#BookingEmailcheckout").html(response.BookingEmail);
                $("#BookingDatecheckout").html(ToJsDate(response.BookingDate));
                $("#CheckInDatecheckout").html(ToJsDate(response.CheckInDate));
                $("#AccommodationTypeNamecheckout").html(response.AccommodationTypeName);
                $("#AccommodationPackageNamecheckout").html(response.AccommodationPackageName);
                $("#FeePerNightcheckout").html(response.FeePerNight);
                $("#Durationcheckout").html(response.Duration);
                $("#NoOfAdultscheckout").html(response.NoOfAdults);
                $("#NoOfChildrencheckout").html(response.NoOfChildren);
                $("#AccommodationNamecheckout").html(response.AccommodationName);
                $("#NoOfRoomcheckout").html(response.NoOfRoom);
                $("#CustomerNamecheckout").html(response.CustomerName);
                $("#CustomerContactcheckout").html(response.CustomerContact);

                var total = response.Duration * response.FeePerNight;
                $("#totalAmountcheckout").html(total);
            }


        }
    })


}
