$(document).ready(function () {
    $('#departments').click(function () {
        console.log('Drawing Department List');
        queryData('/Department');
    });
    $('#buildings').click(function () {
        console.log('Drawing Building List');
        queryData('/Building');
    });
});
function queryData(urlData) {
    $.ajax({
        url: urlData,
        type: 'GET',
        cache: false,
    }).done(function (result) {
        console.log('Query Complete');
        $('#locationOutput').empty();
        $('#locationOutput').append(result);
        console.log('Drawing Complete');
    });
}
//# sourceMappingURL=LocationLoader.js.map