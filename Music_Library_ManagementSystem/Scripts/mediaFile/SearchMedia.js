
function searchmedia(p) {
    data = {};
    data.Id = p;

    $.ajax({
        type: "Post",
        url: "/Media/MediaSearchdata",
        data: data,
        success: function (model) {

            $("#uid").val(model.Id);
            $("#umediastatus").val(model.Media_Status);
            $("#uauthorname").val(model.AuthorName);
            $("#ucategoryname").val(model.CategoryName);
            $("#ucategorynumber").val(model.CategoryNumber);
            $("#udescription").val(model.Description); 
            $("#utitle").val(model.Title);
            $("#uprice").val(model.Price);
          
           

        },
        Error: function (error) {
            // alert("not insert"+error);
            alert("invalid records");
        }
    });

    //$("#mycustomerupdateModal").modal('hide');
};





function mediaDeleterecordssearch(p) {
    data = {};
    alert("update records" + p);
    data.Id = p;


    $.ajax({
        type: "Post",
        url: "/Media/Deletemedia",
        data: data,
        success: function (model) {
            showdatamediadata();
        },
        Error: function (error) {

            alert("invalid records");
        }
    });

    showdatamediadata();
};