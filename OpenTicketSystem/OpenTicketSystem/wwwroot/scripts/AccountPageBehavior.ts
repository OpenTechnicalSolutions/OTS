$(document).ready(function () {
    ///Adds roles
    var rolesused = new Array();
    $("#add-role-button").click(function () {
        var selectedrole = (document.getElementById("roleSelector") as HTMLSelectElement).selectedOptions[0] as HTMLOptionElement;
        if (selectedrole.value === "")
            return;

        var listobj = document.getElementById("added-roles") as HTMLUListElement;
        ///new TR data
        var newli = document.createElement("LI") as HTMLDataListElement;
        newli.textContent = selectedrole.value;
        ///new TD data
        listobj.appendChild(newli);
        rolesused[rolesused.length] = selectedrole.value;
        var input = document.getElementById("user-role-data") as HTMLInputElement
        input.value = JSON.stringify(rolesused);
    });

    $("#buildingdd").change(function () {
        var buildingid = document.getElementById("buildingdd") as HTMLSelectElement;
        var url = "/Room/RoomData?buildingid=" + (buildingid.selectedOptions.item(0) as HTMLOptionElement).value;
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