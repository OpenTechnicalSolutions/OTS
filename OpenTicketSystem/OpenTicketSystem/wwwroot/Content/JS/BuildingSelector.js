$('#buildingList').change(function () {
    var bId = $('#buildingList').val();
    $.ajax({
        url: "Room/BuildingRooms?id=" + bId,
        success: function () {
            $("#roomIdList").empty();
            foreach(d in Response)
            {
                $("#roomIdList").add(d);
            }
        }
    });
});