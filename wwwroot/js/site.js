$(document).ready(function () {
    // hide areas that aren't needed yet.
    $("#resultsArea").hide();
    $("#warnings").hide();

    //Give footer current year
    updateFooterCopyrightDate();

});

$('#Reset').click(function (e) {
    location.reload();
})

$('#AddToList').click(function (e) {
    //Prevent refresh
    e.preventDefault();

    //Variables for building request.
    var url = "/Home/ProcessDrug",
        drugId = $('#drug').val(),
        drugName = $('#drug :selected').attr("drugName"),
        maxDose = $('#drug :selected').attr("maxDose"),
        dose = $('#dose').val();

    //Make request
    $.get(url, { dose: dose, drugId: drugId, drugName: drugName, maxDose: maxDose }, function (result) {
        //Append new data if no errors.
        if (!result.errors.trim()) {

            $("#resultsArea").show();
            createResultsHtml(result);
            tallyPercentage(result);
        }
        else {
            alert("Did you forget to choose a drug and/or enter a dose? Try again.");
        }
    });
})

function createResultsHtml(result) {
    $("#resultData").append("<tr class=\"card\"><td>"
        + "<p><b>Drug</b>: " + result.drugName + "</p>"
        + "<p><b>Dose:</b> " + result.dose + "</p>"
        + "<p><b>Max Dose:</b> " + result.maxDose + "</p>"
        + "<p><b>Max dose utilisation:</b> " + result.maxDoseUtilisation + "%" + "</p>"
        + "<br></td></tr>");
}

function tallyPercentage(result) {
    var getCurrentPercentage = $("#percentage").val();
    newPercentage = parseInt(getCurrentPercentage) + parseInt(result.maxDoseUtilisation)
    $("#percentage").val(newPercentage)
    checkMaxDoseUsage(newPercentage);
}

function updateFooterCopyrightDate() {
    var today = new Date();
    $("#Year").html(today.getFullYear());
}

function checkMaxDoseUsage(newPercentage) {
    if (newPercentage >= 100) {

        //Disable add button to prevent spamming
        $("#AddToList").attr("disabled", "disabled").addClass("btn-disabled btn-danger");

        //Display max dose usage warning 
        displayMaxDosePercentWarning();
    }
}

function displayMaxDosePercentWarning() {
    $("#warnings").show();
    $("#percentageWarning").text("The maximum dose percentage has been reached.");
    $("#utilisationContainer").addClass("alert-danger").removeClass("alert-info");
    

}