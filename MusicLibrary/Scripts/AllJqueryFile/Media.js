

$(document).ready(function () {

    $.ajax({

        type: "POST",
        url: "/Media/ViewMediatyoesearch",
        data: "{}",
        success: function (response) {
            $.each(response, function (index, result) {

                var data = '<button class=" buttonmeditype" onclick="getmediatypeid(' + result.MediaTypeID + ')">' + result.MediaTypeName + '</button>';

                $("#mediatypebuttonshow").append(data);

            })
        }
    })

})


function getmediatypeid(mediatypeid) {
    $("#addmediashow").html("");

    data = {};

    data.MediaTypeID = mediatypeid;

    $.ajax({

        type: "POST",
        url: "/Media/ViewMediatypeAllmedia",
        data: data,
        success: function (response) {
            $.each(response, function (index, result) {

                var data = '<div class="col-lg-4 col-md-4 col-sm-12 col-xm-12 alert alert-primary text-center" role = "alert"> <div class="card" style="width: 100%!important"> <div class="card-body"><h5 class="card-title">' + result.MediaTypeName + 'CD</h5><h6 class="card-subtitle mb-2 text-muted"> <span class="ab">SingerName :</span> ' + result.SingerName + '</h6> <p class="card-text"><span class="ab">AuthorName :</span> ' + result.AuthorName + '</p><p class="card-text"><span class="ab">SongName :</span> ' + result.SongName + '</p><p class="card-text"><span class="ab">Rent :</span>' + result.Rent + ' </p><button class="btn btn-primary" onclick="checkmediaavailable(' + result.AddMediaID + ');">Check Available</button><button class="btn btn-success" onclick="mediabooking(' + result.AddMediaID+')">Booking</button></div></div></div>';

                $("#addmediashow").append(data);
            })
        }
    })


}


function checkmediaavailable(Addmediaid) {

    $("#AddmediaID").val(Addmediaid);
    $("#checkmediaavailableModal").modal("show");
}


//---------------------------------------------------

$(function () {
    $("#datecheck").datepicker({
        minDate: -0,
        maxDate: +30
    });
});

function checkdate() {

    data = {};

    var date = $("#datecheck").val();
    var mediaid = $("#AddmediaID").val();
  
    data.AddMediaID = mediaid;
    data.CreatedByDate=date;

    $.ajax({

        type: "POST",
        url: "/Booking/CheckDateAvailable",
        data: data,
        success: function (result) {
            if (result != null) {

                if (result == "notavalibale") {
                    $("#mediacheckavailable").html("NotAvailable");
                    $("#mediacheckavailable").css("color", "red");
                }
                else if (result == "avalibale") {

                    $("#mediacheckavailable").html("Available");
                    $("#mediacheckavailable").css("color", "green");
                }
                else {

                }
            }
        }
    })

}

function AddMediaID() {

    var mediaid = $("#AddmediaID").val();
    alert(mediaid);

}

function reserdateinput() {

    $("#datecheck").val();

}


//---------------------------------------------------

function mediabooking(MediaId) {

    $("#mid").val(MediaId);
    $("#mediabookingid").modal("show");
}

function confirmmediabooking() {

    var mid = $("#mid").val();

    alert(mid);
}