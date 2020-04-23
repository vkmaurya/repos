$(document).ready(function () {

    disablecheckbox();
});




//-------------------------------------------------------------------------------------------------
var membership = 0;
var totalmembershipdiscount = 0;
var totalAmount = 0;

var mediaid = {};
//var amountotal = 0;

var p = new Array();
var ids = new Array();

function getmediaId() {
    disablecheckbox();
    //------------------------------------------------------------------------------------
    var EndDate = $("#dayNumber").val();
    //alert(EndDate);

    //var month = EndDate.getUTCMonth() + 1; //months from 1-12
    //var day = EndDate.getUTCDate();
    //var year = EndDate.getUTCFullYear();

    //var startdate = year + "-" + month + "-" + day;
    //--------------------------------------
    var dateObj = new Date();
    var month = dateObj.getUTCMonth() + 1; //months from 1-12
    var day = dateObj.getUTCDate();
    var year = dateObj.getUTCFullYear();

    var newdate = year + "-" + month + "-" + day;

    //alert(newdate);

    //------------------------------------------------------------------------------------
    const startDate = newdate;
    const endDate = EndDate;
    const timeDiff = (new Date(endDate)) - (new Date(newdate));
    const days = timeDiff / (1000 * 60 * 60 * 24)

    //------------------------------------------------------------------------------------

    p = new Array();


    $("#hirerenttable").find("input:checked").each(function () {

        p.push($(this).val())
    });


    data = { Id: p };

    ids = data;



    if (p != '') {

        if (EndDate != '' && days >=4 ) {



            $.ajax({
                type: "Post",
                url: "/RentData/getmediaId",
                data: data,

                success: function (success) {

                    debugger;
                    totalAmount = null;

                    $('#Modal').modal('show');
                    $('#locationbody').children().remove();



                    $.each(success, function (key, value) {

                        $('#locationbody').append('<tr><td></td><td>' + value.Id + '</td><td>' + value.AuthorName + '</td><td>' + value.CategoryName + '</td><td>' + value.CategoryNumber + '</td><td>' + value.Title + '</td><td>' + value.Description + '</td><td>' + value.Price + '</td></tr>');

                        var iNum = parseFloat(value.Price);
                        //amountotal = iNum;
                        totalAmount = totalAmount + iNum * days;

                    });


                    //  $("#totalAmount").val(totalAmount);

                    typecustomer();



                }

            });
        }

        else {
            alert("please select date");
        }
    }

    else {
        alert("please select checkbox");
    }
};

//------------------------------------------------------------------------------


function typecustomer() {
    var quntityNumber = 0;

    var membership = $("#membershiptype").val();


    if (membership == "Yes") {

        var Ta = totalAmount;

        console.log(totalAmount);
        membership = Ta / 100 * 10;
        var discountprice = membership.toFixed(2);

        totalmembershipdiscount = totalAmount - membership;

        $("#membershipdiscount").val(discountprice);
        //----------------------------------------------------------------------

        for (var i = 0; i <= p.length - 1; i++) {

            quntityNumber = p.length;
        }

        if (quntityNumber >= 3) {
            var amount = totalAmount / 100 * 30;
            var discount = amount.toFixed(2);

            $("#mediadiscount").val(discount);

            var after3cddiscount = totalmembershipdiscount - discount;
            var rent3cddiscount = after3cddiscount.toFixed(2);

            var t = Ta + after3cddiscount;
            var total = t.toFixed(2)

            $("#securitycharge").val(Ta);

            $("#mediarent").val(rent3cddiscount);

            $("#totalAmount").val(total);


            // alert("30% discount" + after3cddiscount);
        }
        else {
            //-----------------------------------------------------------------------
         //   $("#securitycharge").val(amountotal);

            $("#mediarent").val(totalmembershipdiscount);

         //   var b = Ta + totalmembershipdiscount;

         //   var totalamount = b.toFixed(2);

            $("#totalAmount").val(totalmembershipdiscount);
        }
    }
    else {//--without membership 
        var amount = amountotal;

        var a = 0;
        var discountprice = a.toFixed(2);
        $("#membershipdiscount").val(discountprice);
        //---------------------------------------------------------------------------------------

        for (var i = 0; i <= p.length - 1; i++) {


            quntityNumber = p.length;


        }

        if (quntityNumber >= 3) {

            var amount = totalAmount / 100 * 30;
            var discount = amount.toFixed(2);
            var withoutmembershipdiscount = totalAmount - discount;


            var amo = totalAmount + withoutmembershipdiscount;
            var discountamount = amo.toFixed(2);
            $("#mediadiscount").val(discount);

          //  $("#securitycharge").val(amountotal);



            $("#mediarent").val(withoutmembershipdiscount);

            $("#totalAmount").val(discountamount);


        }
        else {
             //-----------------------------------------------------------------------
            //  var a = totalAmount + amount;
           // var Amount = a.toFixed(2);

            $("#securitycharge").val(amountotal);



            $("#mediarent").val(totalAmount);


            $("#totalAmount").val(totalAmount);
        }

        //----------------------------------------------------------------------------------------


    }


};

//-----------------------------------------------------------------------------------




function AddMediaRent() {


    var contactvalidation = /^[1-9]{1}[0-9]{9}$/;

    var address = $("#address").val();
    var contact = $("#contact").val();
    var EndDate = $("#dayNumber").val();
    alert(EndDate);
    var totalamount = $("#totalAmount").val();



    if (address == "") {
        $("#validaddressmessage").html('**this field required');
        $("#validaddressmessage").css("color", "red");
    }
    else {
        $("#nameErrerMessage").html('');
    }


    if (contact == "") {
        $("#contactErrerMess").html('**this field reguired');
        $("#contactErrerMess").css("color", "red");
    }
    else if (!contactvalidation.test(contact)) {
        $("#contactErrerMess").html('invalid number Please Enter 10 digit');
        $("#contactErrerMess").css("color", "red");
        return false;
    }
    else {
        $("#contactErrerMess").html('');
        true;
    }



    ////$('.d').val("");
    ////$("#Modal").modal('hide');

    data = {};
    data.Id = p;

    data.Address = address;
    data.Contact = contact;
    data.Enddate= EndDate;
    data.TotalAmount = totalamount;
    if (address != "" && contact != "" && contactvalidation.test(contact) == true) {
        $.ajax({
            type: "Post",
            url: "/RentData/hirerentmedia",
            data: data,
            success: function (model) {
                alert("ok");

                $('.d').val("");
                $('.check').val("");
                $("#Modal").modal('hide');


            },
            Error: function (error) {

            }
        });
    }
    else {

    }


};






//$(document).ready(function () {
function disablecheckbox() {
    //array2 = new Array();

    //$("input:checkbox:not(:checked)").each(function () {
    //    array2.push($(this).val());
    //});

    data = {};
    $.ajax({
        type: "Post",
        url: "/Home/checked1",
        data: data,

        success: function (result) {

            $.each(result, function (key, value) {

                $("#mediaid_" + value.MediaId).attr("disabled", true);
                $("#messagecheckbox_" + value.MediaId).html("Not Available");
                $("#messagecheckbox_" + value.MediaId).css("color", "red");

                //$("#messagecheckbox_"+ value.MediaId).html("Available");
               //$("#messagecheckbox_" + value.Id).html("Not Available");

            });

        }

    });
};
//});












