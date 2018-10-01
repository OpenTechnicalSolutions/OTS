"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $ = require("jquery");
$(document).ready(function () {
    $.ajax({
        url: "Department/index",
        type: "GET"
    }).done(function (result) {
        $("#partialView").empty();
        $("#partialView").add(result);
    });
});
//# sourceMappingURL=app.js.map