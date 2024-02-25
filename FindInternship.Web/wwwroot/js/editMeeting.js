
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

    let classId = document.getElementById('classId').value;

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
                'address': address, 
                'classId': classId
            },
            dataType: 'json',
            headers: {
                "RequestVerificationToken": t
            },
            success: async function (data) {

                if (!data.isExists) {

                    try {

                        await connection.invoke("EditMeeting", data.meetingId, data.model, data.receiversIds)

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
                else {
                    toastr.error('\u0421\u0440\u0435\u0449\u0430\u0020\u043f\u043e\u0020\u0442\u043e\u0432\u0430\u0020\u0432\u0440\u0435\u043c\u0435\u0020\u0432\u0435\u0447\u0435\u0020\u0441\u044a\u0449\u0435\u0441\u0442\u0432\u0443\u0432\u0430'.normalize())
                }
            },
            error: function (err) {
                console.error(error)
            }

        })

    }
}

document.getElementById('editEvent').addEventListener("submit", edit);