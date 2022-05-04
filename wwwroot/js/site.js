$(document).ready(function () {
    // hide areas that aren't needed yet.
    $("#resultsArea").hide();

    //Give footer current year
    var today = new Date();
    $("#Year").html(today.getFullYear());


});

$('#Reset').click(function (e) {
    location.reload();
})

$('#AddToList').click(function (e) {
    //Prevent refresh
    e.preventDefault();

    //Url for controller method
    var url = "/Home/AddToList";

    //get form data
    var drug = $('#drug').val();
    var dose = $('#dose').val();

    //Make request
    $.get(url, { dose: dose, drug: drug }, function (result) {
        //Enable these buttons now, they're needed.
       
        //Append new data.
        if (!result.errors.trim()) {
            $("#resultsArea").show();
            console.log({ result });
            $("#rData").append("<tr><td><span>" + result.drug + " " + result.dose + "</span><button type=\"submit\" class=\"btn-sm btn-danger\" id=\"remove\">X</button></tr></td>");
        }
        else {
            
            $("#rDataErrors").innerHTML = "Did you forget to choose a drug and/or enter a dose?";
        }
    });
})