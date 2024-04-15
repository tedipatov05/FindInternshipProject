
async function createDailyRoom(name, meetingId) {
    name = name.slice(0, name.length - 4).trim();
    name = name.replaceAll(' ', '-');

    document.getElementById('createRoom-div').style.display = 'none';
    document.getElementById('join-div').style.display = 'block';


    const options = {
        name: name, 
        privacy: 'public',
        properties: {
            start_video_off: true, 
            start_audio_off: true, 
            //eject_at_room_exp: true, 
            //eject_after_elapsed: 3600, 
        }
    };

    const response = await fetch(`https://api.daily.co/v1/rooms/`, {
        method: 'POST',
        body: JSON.stringify(options),
        headers: {
            'Content-Type': 'application/json',
            Authorization: 'Bearer ' + '1a4818d57f595aed0d7ca55d5ac2a1c97f3526160dbcc0244f0bc7b634be74be',
        },
    });

    if (!response.ok) {
        console.error('Failed to create room');
        return;
    }

    const room = await response.json();

    let t = $("input[name='__RequestVerificationToken']").val();


    $.ajax({
        url: '/Room/Create',
        method: 'POST',
        headers: {
            'RequestVerificationToken': t
        },
        dataType: 'json',
        data: {
            'meetingId': meetingId,
            'roomId': room.id,
            'roomName': room.name,
            'roomUrl': room.url,
            'privacy': 'public'

        },
        success: function (data) {
            console.log(data.success);

        }, 
        error: function (err) {
            toastr.error('Неочаквана грешка възникна');
            console.error(err)
        }


    })

}
