import * as $ from "jquery"

$(document).ready(function () {
    $("#departments").click(function () {
        CallData("Department/Index");
    });

    $("#buildings").click(function () {
        CallData("Building/Index");
    })

})

function CallData(urlString: string) {
    $.ajax({
        url: urlString,
        type: "GET"
    }).done(function (result) {
        $("#partialView").empty();
        $("#partialView").add(result);
    });
}