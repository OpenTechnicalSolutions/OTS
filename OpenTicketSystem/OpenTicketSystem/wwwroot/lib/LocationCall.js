$(document).ready(function () {
    $("#departments").click(function () {
        console.log("Drawing Departments")
        queryData('Department');
    })

    $("#buildings").click(function () {
        console.log("Drawing Buildings")
        queryData('Building');
    });
});

function queryData(urlData) {
    $.ajax({
        url: urlData,
        type: "GET",
        cache: false,
    }).done(function (result) {
        console.log("Query Complete")
        $("#partialView").empty();
        $("#partialView").append(result);
    });
}