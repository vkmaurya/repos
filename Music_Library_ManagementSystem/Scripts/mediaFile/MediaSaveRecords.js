

function MediaSaveRecords() {

   

    var authorname = $("#authorname").val();
    var categoryname = $("#categoryname").val();
    var categorynumber = $("#categorynumber").val();
    var title = $("#title").val();
    var description = $("#description").val();
    var price = $("#price").val();
    var mediastatus = $("#mediastatus").val();



    data = {};

    $('.m').val("");
    $("#mymediaModal").modal('hide');
  
    data.AuthorName = authorname;
    data.CategoryName = categoryname;
    data.CategoryNumber = categorynumber;
    data.Title = title;
    data.Description = description;
    data.Price = price;
    data.Media_Status = mediastatus;
   




    $.ajax({
        type: "Post",
        url: "/Media/CreateMedia",
        data: data,
        success: function (model) {

            alert("data insert Succefully");
            $("#myinsersuccessfillyModal").modal('toggle');

        },
        Error: function (error) {
            alert("not insert" + error);
            showdatamediadata();
            $("#myinsersuccessfillyModal").modal('toggle');
        }
    });

    showdatamediadata();
    $('.m').val("");
    $("#mymediaModal").modal('hide');


};