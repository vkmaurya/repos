
function submitquestion() {

    var question = $("#question").val();
    var opa = $("#opa").val();
    var opb = $("#opb").val();
    var opc = $("#opc").val();
    var opd = $("#opd").val();
    var correctoption = $("#correctoption").val();

    if (question == "") {
        $("#messagequestion").html("***Required this fields!");
        $("#messagequestion").css("color", "red");
        $("#question").css("border","2px solid red")
    }
    else {
        $("#messagequestion").html("");
        $("#question").css("border", "")
    }

    //------------------------------------------------------------

    if (opa == "") {
        $("#messageopa").html("***Required this fields!");
        $("#messageopa").css("color", "red");
        $("#opa").css("border", "2px solid red")
    }
    else {
        $("#messageopa").html("");
        $("#opa").css("border", "")
    }

    //----------------------------------------------------------------

    if (opb == "") {
        $("#messageopb").html("***Required this fields!");
        $("#messageopb").css("color", "red");
        $("#opb").css("border", "2px solid red")
    }
    else {
        $("#messageopb").html("");
        $("#opb").css("border", "")
    }

    //-------------------------------------------------------------------

    if (opc == "") {
        $("#messageopc").html("***Required this fields!");
        $("#messageopc").css("color", "red");
        $("#opc").css("border", "2px solid red")
    }
    else {
        $("#messageopc").html("");
        $("#opc").css("border", "")
    }


    //-------------------------------------------------------------

    if (opd == "") {
        $("#messageopd").html("***Required this fields!");
        $("#messageopd").css("color", "red");
        $("#opd").css("border", "2px solid red")
    }
    else {
        $("#messageopd").html("");
        $("#opd").css("border", "")
    }

    //-----------------------------------------------------------------

    if (correctoption == "") {
        $("#messagecorrectoption").html("***Required this fields!");
        $("#messagecorrectoption").css("color", "red");
        $("#correctoption").css("border", "2px solid red")
    }
    else {
        $("#messagecorrectoption").html("");
        $("#correctoption").css("border", "")
    }



    if (question != "" && opa != "" && opb != "" && opc != "" && opd != "" && correctoption != "") {
        
        create();
       
    }




}

function create() {

    data = {};

    var question = $("#question").val();
    var opa = $("#opa").val();
    var opb = $("#opd").val();
    var opc = $("#opc").val();
    var opd = $("#opd").val();
    var correctoption = $("#correctoption").val();

    data.Question1 = question;
    data.Opa = opa;
    data.Opb = opb;
    data.Opc = opc;
    data.Opd = opd;
    data.Ope = correctoption;

    $("#myModal").modal("hide");

    $.ajax({
        type: "POST",
        url: "/Question/QuestionCreate",
        data: data,

        success: function (result) {

          
            if (result != null) {

                if (result = "add") {
                    
                    $("#headdermessageshow").html("Add Succefully");
                }
                else if (result = "error") {
                    $("#headdermessageshow").html("Records not Add Something wrong");
                }
                else if (result = "exception") {
                    $("#headdermessageshow").html("Server Error  please try agen");
                }

                else {
                    $("#headdermessageshow").html("Server Error please try agen");
                }
            }
            else {

                $("#headdermessageshow").html("opps Error...!");
            }
           
        }

    });

};

$(document).ready(function () {



})

