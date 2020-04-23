

function updatemediarecordssave() {

   

    var id = $("#uid").val();
    var authorname = $("#uauthorname").val();
    var categoryname = $("#ucategoryname").val();
    var categorynumber = $("#ucategorynumber").val();
    var title = $("#utitle").val();
    var description = $("#udescription").val();
    var price = $("#uprice").val();
    var mediastatus = $("#umediastatus").val();


  
    data = {};

  
    $("#myupdatemediaModal").modal('hide');
    data.Id = id;
    data.AuthorName = authorname;
    data.CategoryName = categoryname;
    data.CategoryNumber = categorynumber;
    data.Title = title;
    data.Description = description;
    data.Price = price;
    data.Media_Status = mediastatus;





    $.ajax({
        type: "Post",
        url: "/Media/mediaupdaterecords",
        data: data,
        success: function (model) {
            showdatamediadata();
            alert("data insert Succefully");
            $("#myinsersuccessfillyModal").modal('toggle');

        },
        Error: function (error) {
            alert("not insert" + error);
            $("#myinsersuccessfillyModal").modal('toggle');
        }
    });
    showdatamediadata();
    $("#myupdatemediaModal").modal('hide');

};