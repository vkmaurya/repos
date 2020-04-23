

function customerorderlist(p) {

    data = {CustomerId: p };



    $.ajax({
        type: "Post",
        url: "/RentData/SearchCustomerDetails",
        data: data,
        


        success: function (success) {

            $('#customerorderdetails').modal('show');


            $("#customerorderlist").children().remove();

            $.each(success, function (key, value) {

                $('#customerorderlist').append('<tr><td>' + value.authorName + '</td><td>' + value.categoryName + '</td><td>' + value.categoryNumber + '</td><td>' + value.title + '</td><td>' + value.description + '</td><td>' + value.price + '</td><td><button class="btn btn-danger" id="DeleteButton" onclick="cancleorder(' + value.MediaId+ ');">cancle</button></td></tr>');


            });




        }

    });
};



function cancleorder(mediaid) {

    data = { MediaId: mediaid};
    alert("cancleorder" + mediaid);

    $.ajax({
        type: "Post",
        url: "/RentData/MediaOrderCancle",
        data: data,
        success: function (success) {
            alert("ordercancle");
            customerorderlist(p);
        }
    });
   
    $("#customerorderlist").on("click", "#DeleteButton", function () {
        $(this).closest("tr").remove();
    });
  
};

