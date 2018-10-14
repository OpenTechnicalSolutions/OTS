$(document).ready(function () {
    ///Adds roles
    $("#add-role-button").click(function () {
        var selectedrole = document.getElementById("roleSelector").selectedOptions[0];
        if (selectedrole.value === "")
            return;
        var tableobj = document.getElementById("role-table");
        ///new TR data
        var newTr = document.createElement("TR");
        newTr.setAttribute("id", selectedrole.value + "-row");
        newTr.setAttribute("value", selectedrole.value + "-row");
        ///new TD data
        var newTd = document.createElement("TD");
        newTd.innerHTML = selectedrole.value;
        newTd.setAttribute("id", selectedrole.value + "-cell");
        newTd.setAttribute("value", selectedrole.value + "-cell");
        newTr.appendChild(newTd);
        var addTr = document.getElementById("add-role-row");
        tableobj.insertBefore(newTr, addTr);
    });
    $("#buildingdd").change(function () {
        var buildingid = document.getElementById("buildingdd");
        var url = "/Room/RoomData?buildingid=" + buildingid.selectedOptions.item(0).value;
        QueryJson(url, "roomdd");
    });
    /*
    $.getJSON(
        "/TechnicalGroup/TechnicalGroupData",
        function (result) {
            DrawDropDown(result, "techgroupdd");
        });
        */
    $("#techgroupdd").change(function () {
        $.getJSON("/SubTechnicalGroup/SubTechnicalGroupData", function (result) {
            DrawDropDown(result, "subtechgroupdd");
        });
    });
});
function QueryJson(url, htmlId) {
    $.getJSON(url, function (result) {
        DrawDropDown(result, htmlId);
    });
}
function DrawDropDown(drawData, selectId) {
    var html = "";
    for (var key in drawData) {
        html += "<option value=" + drawData[key]["id"] + ">" + drawData[key]["name"] + "</option>";
    }
    document.getElementById(selectId).innerHTML = html;
}
//# sourceMappingURL=AccountPageBehavior.js.map