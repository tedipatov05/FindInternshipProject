var connection = new signalR.HubConnectionBuilder()
    .withUrl("/meetingHub")
    .build();

$(document).ready(function () {

    let divs = Array.from( document.getElementsByClassName('input-group'));
    for (let div of divs) {
        div.children[0].disabled = true
        div.children[1].style = 'transform: translateY(-50%) scale(0.8);background-color: #212121;padding: 0 .2em;color: #2196f3;'

    }

});

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();

function deleteMeeting(e) {

    e.preventDefault();
    
    let data = new FormData(e.target);

    let { title, start, end, address } = Object.fromEntries(data);


    let url = new URL(window.location);
    let path = url.pathname;
    let t = $("input[name='__RequestVerificationToken']").val();

    $.ajax({
        type: "POST",
        url: path,
        data: {
            'title': title, 
            'end': end, 
            'start': start, 
            'address': address
        },
        dataType: "json",

        headers: {
            "RequestVerificationToken": t
        },

        success: async function (data) {
            if (data) {

                try {

                    await connection.invoke("DeleteMeeting", data.meetingId, data.receiversIds)

                } catch (err) {
                    console.error(err);
                }

                let url = new URL(window.location);
                let params = url.searchParams;
                let days = parseInt(params.get('days'))

                if (isNaN(days)) {
                    days = 0;
                }

                window.location = `${url.origin}/Meeting/All?days=${days}`
                
            }
        },
        error: function (err) {
            console.error(err);
        }
        

    })
}

document.getElementById('deleteEvent').addEventListener('submit', deleteMeeting);