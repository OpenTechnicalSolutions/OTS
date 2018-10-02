$(document).ready(function () {
    var serverData = $("#locationIndexData").data('locindex');
    if (serverData === 'Department')
        queryData('/Department');
    else if (serverData === 'Building')
        queryData('/Building');


    $('#departments').click(function () {
        console.log('Drawing Department List');
        queryData('/Department');
    });

    $('#buildings').click(function () {
        console.log('Drawing Building List');
        queryData('/Building');
    });
});

function queryData(urlData: string) {
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
