$(document).ready(function () {
    DoctortypeListall();
    appoimentdone();
    appoimentdonecomplates();
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
            {
                "data": "", "name": "", "autoWidth": true,
                render: function (data, type, row) {
                    return '<span><button class="btn btn-success"  onclick=setpatientappoiment(' + row.PatientID + ');><i class="fa fa-pencil-square-o" aria-hidden="true"></i> Set Appoiment</button> <button class="btn btn-info"  onclick =searchappoimentinformation(' + row.PatientID + ');><i class="fa fa-info" aria-hidden="true"></i> Details</button ></span>';
                }
            },

            { "data": "PatientName", "autoWidth": true },
            { "data": "SSNumber", "autoWidth": true },
            { "data": "DoctorName", "autoWidth": true },
            // { "data": "AppointmentDateStart", "autoWidth": true },
            // { "data": "AppointmentDateEnd", "autoWidth": true },
            // { "data": "AppointmentBookingDate", "autoWidth": true },

            {
                "data": "AppointmentDateStart", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },
            {
                "data": "AppointmentDateEnd", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },

            {
                "data": "AppointmentBookingDate", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },

            { "data": "AppointmentPatientSession", "autoWidth": true }


        ]
    });

};



function searchappoimentinformation(patientid) {

    $("#sickdata").html("");
    data = {};
    data.PatientID = patientid;

    $.ajax({

        type: "POST",
        url: '/Appoiment/GetpatientAppointmentsick',
        data: data,
        success: function (result) {
            $.each(result, function (index, res) {
                $("#showsickModal").modal("show");

                var sickdata = '<h5>' + res.SickTypeName + '</h5>';
                $("#sickdata").append(sickdata);


            });
        }
    })


}





function setpatientappoiment(patientid) {

    $("#appoimentsetmodel").modal("show");

    $("#patientappoimentid").val(patientid);
}




function addappoiment() {
    $("#time").val("");
    data = {};
    var stime = $('#stime').val();
    var etime = $('#etime').val();
    var apppimentpatientid = $("#patientappoimentid").val();

    var date1 = new Date(stime);
    var date2 = new Date(etime);
    var ElapsedSeconds = (date2 - date1) / 1000;
    var ElapsedHours = ElapsedSeconds / 3600;
    var minut = ElapsedHours * 60;
    $("#time").val(minut);

    data.PatientID= apppimentpatientid;
    data.AppointmentDateStart= stime;
    data.AppointmentDateEnd= etime;
    data.AppointmentPatientSession = minut+" : minute";
    $.ajax({

        type: "POST",
        url: "/Appoiment/SetAppoimentPatient",
        data: data,
        success: function (result) {
            if (result == "save") {
                DoctortypeListall();
                $("#appoimentsetmodel").modal("hide");
                alert("appoiment Save");

            }
            else if (result == "notsave") {

            }
            else {

            }
        }
    })

}



function appoimentdone() {

    var oTable = $("#patientappoimentdone").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $('#patientappoimentdone').DataTable({

        "ajax": {

            "url": "/Appoiment/ViewDoctorsetaptinetappoimentdone",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "", "name": "",
                render: function (data, type, row) {
                    return '<span><button class="btn btn-success"  onclick=appoimentcomplats(' + row.PatientID + ');><i class="fa fa fa-check-square-o" aria-hidden="true"></i>  Done</button> <button class="btn btn-info"  onclick =searchappoimentinformation(' + row.PatientID + ');><i class="fa fa-info" aria-hidden="true"></i> Details</button ></span>';
                }
            },

            { "data": "PatientName", "autoWidth": true },
            { "data": "SSNumber", "autoWidth": true },
            { "data": "DoctorName", "autoWidth": true },
        

            {
                "data": "AppointmentDateStart", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },
            {
                "data": "AppointmentDateEnd", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },

            {
                "data": "AppointmentBookingDate", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },

            { "data": "AppointmentPatientSession", "autoWidth": true }


        ]
    });

};



function appoimentcomplats(p) {

    data = {};

    data.PatientID = p;

    $.ajax({

        type: "POST",
        url: "/Appoiment/AppimentConfirmdone",
        data: data,
        success: function (result) {

            if (result != null) {
                if (result == "save") {

                    alert("save");

                }
                else if (result == "notsave") {

                    alert("notsave");

                }
            }
        }
    })
    
    
}



//---------------------------Appoiment Complates--------------------------------------------



function appoimentdonecomplates() {

    var oTable = $("#appoimentlistpatientListcomplates").dataTable();
    oTable.fnDestroy();
    oTable.fnClearTable();

    $('#appoimentlistpatientListcomplates').DataTable({

        "ajax": {

            "url": "/Appoiment/ViewDoctorsetaptinetappoimentcomplates",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "", "name": "",
                render: function (data, type, row) {
                    return '<span> <button class="btn btn-info"  onclick =searchappoimentinformation(' + row.PatientID + ');><i class="fa fa-info" aria-hidden="true"></i> Details</button ></span>';
                }
            },

            { "data": "PatientName", "autoWidth": true },
            { "data": "SSNumber", "autoWidth": true },
            { "data": "DoctorName", "autoWidth": true },


            {
                "data": "AppointmentDateStart", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },
            {
                "data": "AppointmentDateEnd", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },

            {
                "data": "AppointmentBookingDate", "autoWidth": true,
                "render": function (data) {
                    return ToJsDate(data);
                }
            },

            { "data": "AppointmentPatientSession", "autoWidth": true }


        ]
    });

};

//---------------------------patient check appoiment---------------------------------------------------------



