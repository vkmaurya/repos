


function addmedia() {



    var authornamevalidation = /^[a-zA-Z ]*$/;
    var categorynumbervalidation = /^[a-zA-Z0-9]*$/;
    var titlevalidation = /^[a-zA-Z ]*$/;
    var descriptionvalidation = /^[a-zA-Z0-9  ]*$/;
    var pricevalidation = /^[0-9.  ]*$/;
  
 
    //--------------------------------------------
    var authorname = $("#authorname").val();
    var categoryname = $("#categoryname").val();
    var categorynumber = $("#categorynumber").val();
    var title = $("#title").val();
    var description = $("#description").val();
    var price = $("#price").val();
    var mediastatus = $("#mediastatus").val();
  

  
    //---------------------------------Name Validation -------------------------------------



    if (authorname == "") {
        $("#authornameErrerMessage").html('**this field required');
        $("#authornameErrerMessage").css("color", "red");
    }
    else if (!authornamevalidation.test(authorname)) {
        $("#authornameErrerMessage").html('Please Enter only alphabets in textme');
        $("#authornameErrerMessage").css("color", "red");
        //return false;
    }
    else {
        $("#authornameErrerMessage").html('');
    }
   

   

    if (categoryname == "") {
        $("#categorynameErrerMessage").html('**this field required');
        $("#categorynameErrerMessage").css("color", "red");
    }

    else {
        $("#categorynameErrerMessage").html('');
        true;
    }

    ////-----------------------------Address Validation -------------------------------------------------

    if (categorynumber == "") {
        $("#categorynumberErrerMessage").html('**this field required');
        $("#categorynumberErrerMessage").css("color", "red");
    }
    else if (!categorynumbervalidation.test(categorynumber)) {
        $("#categorynumberErrerMessage").html('invalid number Please Enter valid number');
        $("#categorynumberErrerMessage").css("color", "red");
    }
    else {
        $("#categorynumberErrerMessage").html('');
    }

    ////---------------------member ship----------------------------------------------

    if (title == "") {
        $("#titleErrerMessage").html('**this field required');
        $("#titleErrerMessage").css("color", "red");
    }
    else if (!titlevalidation.test(title)) {
        $("#titleErrerMessage").html('invalid name Please Enter valid name');
        $("#titleErrerMessage").css("color", "red");
    }
    else {
        $("#titleErrerMessage").html('');
    }





    if (description == "") {
        $("#descriptionErrerMessage").html('**this field required');
        $("#descriptionErrerMessage").css("color", "red");
    }
    else if (!descriptionvalidation.test(description)) {
        $("#descriptionErrerMessage").html('invalid description Please Enter valid description');
        $("#descriptionErrerMessage").css("color", "red");
    }
    else {
        $("#descriptionErrerMessage").html('');
    }
    ////-------------------------------------------------------------------------------

    if (price == "") {
        $("#priceErrerMessage").html('**this field required');
        $("#priceErrerMessage").css("color", "red");
    }
    else if (!pricevalidation.test(price)) {
        $("#priceErrerMessage").html('invalid price Please Enter valid price');
        $("#priceErrerMessage").css("color", "red");
    }
    else {
        $("#priceErrerMessage").html('');
    }

    //-------------------------------------------------------


    if (mediastatus == "") {
        $("#mediastatusErrerMessage").html('**this field required');
        $("#mediastatusErrerMessage").css("color", "red");
    }

    else {
        $("#mediastatusErrerMessage").html('');
        true;
    }


    //------------------------------------------------------

    if (authorname != "" && authornamevalidation.test(authorname) == true && categoryname != "" && categorynumber != "" && categorynumbervalidation.test(categorynumber) == true && title != "" && titlevalidation.test(title) == true && description != "" && descriptionvalidation.test(description) == true && price != "" && pricevalidation.test(price) && mediastatus != "") {

        MediaSaveRecords();


    }


};