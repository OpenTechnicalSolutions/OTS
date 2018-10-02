$(document).ready(function () {
    /*if (LocationIndex === 0) {
        queryData("Department/Index");
    } else if (LocationIndex === 1) {
        queryData("Building/Index");
    }*/

    $("#departments").click(function () {
        console.log("Drawing Departments");
        queryData("Department");
    });

    $("#buildings").click(function () {
        console.log("Drawing Buildings");
        queryData('Building');
    });
});

function queryData(urlData) {
    $.ajax({
        url: urlData,
        type: "GET",
        cache: false
    }).done(function (result) {
        console.log("Query Complete");
        $("#locationView").empty();
        $("#locationView").append(result);
        console.log("Draw Complete!");
    });
}