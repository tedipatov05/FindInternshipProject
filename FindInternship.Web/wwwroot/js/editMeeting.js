
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

start()

function edit(e) {
    e.preventDefault();

    let data = new FormData(e.target);

    let { title, start, end, address } = Object.fromEntries(data);

    let dataArr = [title, start, end, address]

    let validationSpans = document.getElementsByClassName('text-danger');

    dataArr.forEach((element, index) => {
        if (element == '') {
            validationSpans[index].style.display = 'block';
        }
        else {
            validationSpans[index].style.display = 'none';
        }
    });

    if (!Array.from(validationSpans).some(v => v.style.display == 'block')) {

        let url = new URL(window.location);
        let path = url.pathname;


        let t = $("input[name='__RequestVerificationToken']").val();
        $.ajax({
            type: "POST", 
            url: path,
            data: {
                'title': title, 
                'start': start, 
                'end': end, 
                'address': address
            },
            dataType: 'json', 
            headers: {
                "RequestVerificationToken": t
            },
            success: async function (data) {

                if (data) {

                    try {

                        await connection.invoke("EditMeeting", data.meetingId, data.model, data.receiversIds)

                    } catch (err) {
                        console.error(err);
                    }
                    
                    let url = window.location;
                    let params = (new URL(url)).searchParams;
                    let days = parseInt(params.get('days'))


                    window.location = `https://localhost:7256/Meeting/All?days=${days}`
                }
            },
            error: function (err) {
                console.error(error)
            }

        })

    }
}

document.getElementById('editEvent').addEventListener("submit", edit);