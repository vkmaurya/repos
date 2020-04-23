

function updatemedia() {
  



    var authornamevalidation = /^[a-zA-Z ]*$/;
    var categorynumbervalidation = /^[a-zA-Z0-9]*$/;
    var titlevalidation = /^[a-zA-Z ]*$/;
    var descriptionvalidation = /^[a-zA-Z0-9  ]*$/;
    var pricevalidation = /^[0-9.  ]*$/;


    //--------------------------------------------
    var authorname = $("#uauthorname").val();
    var categoryname = $("#ucategoryname").val();
    var categorynumber = $("#ucategorynumber").val();
    var title = $("#utitle").val();
    var description = $("#udescription").val();
    var price = $("#uprice").val();
    var mediastatus = $("#umediastatus").val();



    //---------------------------------Name Validation -------------------------------------



    if (authorname == "") {
        $("#uauthornameErrerMessage").html('**this field required');
        $("#uauthornameErrerMessage").css("color", "red");
    }
    else if (!authornamevalidation.test(authorname)) {
        $("#uauthornameErrerMessage").html('Please Enter only alphabets in textme');
        $("#u").css("color", "red");
        //return false;
    }
    else {
        $("#uauthornameErrerMessage").html('');
    }




    if (categoryname == "") {
        $("#ucategorynameErrerMessage").html('**this field required');
        $("#ucategorynameErrerMessage").css("color", "red");
    }

    else {
        $("#ucategorynameErrerMessage").html('');
        true;
    }

    ////-----------------------------Address Validation -------------------------------------------------

    if (categorynumber == "") {
        $("#ucategorynumberErrerMessage").html('**this field required');
        $("#ucategorynumberErrerMessage").css("color", "red");
    }
    else if (!categorynumbervalidation.test(categorynumber)) {
        $("#ucategorynumberErrerMessage").html('invalid number Please Enter valid number');
        $("#ucategorynumberErrerMessage").css("color", "red");
    }
    else {
        $("#ucategorynumberErrerMessage").html('');
    }

    ////---------------------member ship----------------------------------------------

    if (title == "") {
        $("#utitleErrerMessage").html('**this field required');
        $("#utitleErrerMessage").css("color", "red");
    }
    else if (!titlevalidation.test(title)) {
        $("#utitleErrerMessage").html('invalid name Please Enter valid name');
        $("#utitleErrerMessage").css("color", "red");
    }
    else {
        $("#utitleErrerMessage").html('');
    }





    if (description == "") {
        $("#udescriptionErrerMessage").html('**this field required');
        $("#udescriptionErrerMessage").css("color", "red");
    }
    else if (!descriptionvalidation.test(description)) {
        $("#udescriptionErrerMessage").html('invalid description Please Enter valid description');
        $("#udescriptionErrerMessage").css("color", "red");
    }
    else {
        $("#udescriptionErrerMessage").html('');
    }
    ////-------------------------------------------------------------------------------

    if (price == "") {
        $("#upriceErrerMessage").html('**this field required');
        $("#upriceErrerMessage").css("color", "red");
    }
    else if (!pricevalidation.test(price)) {
        $("#upriceErrerMessage").html('invalid price Please Enter valid price');
        $("#upriceErrerMessage").css("color", "red");
    }
    else {
        $("#upriceErrerMessage").html('');
    }

    //-------------------------------------------------------


    if (mediastatus == "") {
        $("#umediastatusErrerMessage").html('**this field required');
        $("#umediastatusErrerMessage").css("color", "red");
    }

    else {
        $("#umediastatusErrerMessage").html('');
        true;
    }


    //------------------------------------------------------

    if (authorname != "" && authornamevalidation.test(authorname) == true && categoryname != "" && categorynumber != "" && categorynumbervalidation.test(categorynumber) == true && title != "" && titlevalidation.test(title) == true && description != "" && descriptionvalidation.test(description) == true && price != "" && pricevalidation.test(price) && mediastatus != "") {

       

        updatemediarecordssave();


    }

};