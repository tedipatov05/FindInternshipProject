var connection = new signalR.HubConnectionBuilder()
    .withUrl("/meetingHub")
    .build();

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
                toastr.success(`Успешно изтрита среща`);
                
                window.location = `https://localhost:7256/Meeting/All`;
            }
        },
        error: function (err) {
            console.error(err);
        }
        

    })
}

document.getElementById('deleteEvent').addEventListener('submit', deleteMeeting);