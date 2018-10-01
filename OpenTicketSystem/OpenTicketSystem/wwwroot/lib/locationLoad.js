"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $ = require("jquery");
$(document).ready(function () {
    $("#departments").click(function () {
        CallData("Department/Index");
    });
    $("#buildings").click(function () {
        CallData("Building/Index");
    });
});
function CallData(urlString) {
    $.ajax({
        url: urlString,
        type: "GET"
    }).done(function (result) {
        $("#partialView").empty();
        $("#partialView").add(result);
    });
}
//# sourceMappingURL=locationLoad.js.map