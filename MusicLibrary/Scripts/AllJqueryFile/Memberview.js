

$(document).ready(function () {


    $.ajax({

        type: "POST",
        url: "/MemberShip/ViewFrontPageMembership",
        data: "{}",
        success: function (result) {
            $.each(result, function (index, response) {

                var data = '<div class="col-lg-4 col-md-4 col-sm-12  text-center"><div class="alert alert-primary" role = "alert" ><div class="card bl-5" style="width:100%;"><div class="card-body"><h5 class="card-title">' + response.MemberShipName + '</h5><h6 class="card-subtitle mb-2 text-muted">Rs :' + response.MemberShipAmount + '</h6><p class="card-text" style="color:black"> Duration:' + response.MemberShipDuration + ' Days</p><p class="card-text">' + response.MemberShipDescription + '</p><button class="btn btn-success" onclick="savemembership(' + response.MemberShipID + ')">Submit</button></div></div></div></div >';
                $("#membershipview").append(data);
            });
        }
    })

})


function savemembership(membershipid) {


    $("#addmemvershipid").val(membershipid);
    $("#memberaddmodel").modal("show");
}

function membershipplaneid() {

    data = {};
    var memberid = $("#addmemvershipid").val();

    data.MemberShipID= memberid;

    $.ajax({

        type: "POST",
        url: "/MemberShip/CreateUserMembership",
        data: data,
        success: function (result) {
            if (result != null) {
                if (result == "save") {
                    alert("save");
                    $("#memberaddmodel").modal("hide");
                }
                else if (result == "notsave") {

                    alert("NotSave")
                }
                else if (result == "exception") {

                    alert("Server Busy...")
                }
                else {

                }
            }
        }
    })

}