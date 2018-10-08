$(document).ready(function () {
    var techStatus = $("#techStatus").data("techStat");
    $.ajax({
        url: "/Department/DepartmentData",
        type: "GET"
    }).done(
        function (result) {
            console.log("querying depts");
            DrawDropDown(result, "deptdd");
            console.log("depts done queried.");
        });

    $.ajax({
        url: "/Building/BuildingData",
        type: "GET"
    }).done(
        function (result) {

        });
});

function DrawDropDown(drawData, selectName) {
    drawData.forEach(function (dd) {
        var opt = document.createElement("option");
        opt.text = dd.Name;
        opt.value = dd.id;
        $(selectName).add(opt);
    });
}