$(document).ready(function () {
    var techStatus = $("#techStatus").data("techStat");
    $.ajax({
        url: "/Department/DepartmentData",
        dataType: "text/plain",
        type: "GET"
    }).done(
        function (result) {

        });
});