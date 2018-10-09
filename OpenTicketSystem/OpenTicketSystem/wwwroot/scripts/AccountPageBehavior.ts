$(document).ready(function () {
    var techStatus = $("#techStatus").data("techStat");
    $.getJSON(
        "/Department/DepartmentData",
        function (result) {
            DrawDropDown(result, "deptdd");
        });

    $.getJSON(
        "/Building/BuildingData",
        function (result) {
            DrawDropDown(result, "buildingdd");
        });

    $("#buildingdd").change(function () {
        var url = "/Room/RoomData?buildingid=" + $("#buildingdd option:selected").val;
        $.getJSON(
            "/Room/RoomData?buildingid=",
            function (result) {
                DrawDropDown(result, "roomdd");
            });
    });

    $.getJSON(
        "/TechnicalGroup/TechnicalGroupData",
        function (result) {
            DrawDropDown(result, "techgroupdd");
        });

    $("#techgroupdd").change(function () { 
    $.getJSON(
        "/TechnicalGroup/TechnicalGroupData",
        function (result) {
            DrawDropDown(result, "subtechgroupdd");
            });
    });
});

function DrawDropDown(drawData: [object], selectId) {
    var html = "";
    for (var key in drawData) {
        html += "<option value=" + drawData[key]["id"] + ">" + drawData[key]["name"] + "</option>";
    }
    document.getElementById(selectId).innerHTML = html;
}