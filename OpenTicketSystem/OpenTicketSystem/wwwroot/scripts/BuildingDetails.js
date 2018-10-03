$(document).ready(function () {
    var buildingId = $("#buildingId").data('id');
    console.log(buildingId);
    $.ajax({
        url: '/Room/BuildingRooms?id=' + buildingId,
        type: 'GET',
        cache: false,
    }).done(function (result) {
        console.log('Query Complete');
        $('#roomList').empty();
        $('#roomList').append(result);
        console.log('Drawing Complete');
    });
});
//# sourceMappingURL=BuildingDetails.js.map