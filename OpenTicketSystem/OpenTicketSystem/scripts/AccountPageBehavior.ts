$(document).ready(function () {
    var techStatus = $("#techStatus").data("techStat");
 
    $("#buildingdd").change(function () {
        var buildingid = document.getElementById("buildingdd") as HTMLSelectElement;
        var url = "/Room/RoomData?buildingid=" + (buildingid.selectedOptions.item(0) as HTMLOptionElement).value;
        QueryJson(url, "roomdd");
    });      

    $.getJSON(
        "/TechnicalGroup/TechnicalGroupData",
        function (result) {
            DrawDropDown(result, "techgroupdd");
        });

    $("#techgroupdd").change(function () { 
        $.getJSON(
            "/SubTechnicalGroup/SubTechnicalGroupData",
            function (result) {
                DrawDropDown(result, "subtechgroupdd");
            });
    });
});

function QueryJson(url: string, htmlId: string) {
    $.getJSON(
        url,
        function (result) {
            DrawDropDown(result, htmlId);
        });
}

function DrawDropDown(drawData: [object], selectId) {
    var html = "";
    for (var key in drawData) {
        html += "<option value=" + drawData[key]["id"] + ">" + drawData[key]["name"] + "</option>";
    }
    document.getElementById(selectId).innerHTML = html;
}