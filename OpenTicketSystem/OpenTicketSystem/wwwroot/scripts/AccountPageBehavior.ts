$(document).ready(function () {
    var techStatus = $("#techStatus").data("techStat");

    $.getJSON(
        "/Department/DepartmentData",
        "data.json",
        function (result) {
            DrawDropDown(result, "deptdd");
        });

    $.ajax({
        url: "/Department/DepartmentData",
        type: "GET"
    }).done(
        function (result) {
            console.log("querying depts");
            
            console.log("depts done queried.");
        });

    $.ajax({
        url: "/Building/BuildingData",
        type: "GET"
    }).done(
        function (result) {

        });
});

function DrawDropDown(drawData, selectId) {
    var html = "";
    for (var key in drawData) {
        html += "<option value=" + key["id"] + ">" + key["name"] + "</option>";
    }
    document.getElementById(selectId).innerHTML = html;
}