
$(document).ready(function () {
    StudentTable();
});


function StudentTable() {
  
    data = {};
    $.ajax({
        type: "Post",
        url: "/Student/ViewStudentRecords",
        data:data,

        success: function (result) {
     
            $.each(result, function (key, value) {

                var a = '<tr><td>' + value.Id + '</td><td>' + value.Name + '</td><td>' + value.Email + '</td><td>' + value.Address + '</td><td>' + value.Password + '</td><td></td></tr>';
                $("#studentrecords").append(a);

            });

        }

    });
};

