
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/meetingHub")
    .build();


document.getElementById('addMeeting').addEventListener('click', () => {
    Array.from(document.getElementsByClassName('text-danger')).forEach(e => e.style.display = 'none')
})

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

// Start the connection.
start()

function toUnicode(str) {
    let unicodeString = '';
    for (let i = 0; i < str.length; i++) {
        const unicodeChar = str.charCodeAt(i).toString(16).toUpperCase();
        unicodeString += `\\u${'0'.repeat(4 - unicodeChar.length)}${unicodeChar}`;
    }
    return unicodeString;
}


function create(e) {


    e.preventDefault();
    let formData = new FormData(e.target);
    let { classId, title, start, end, address } = Object.fromEntries(formData);

    let dataArr = [classId, title, start, end, address]

    let validationSpans = document.getElementsByClassName('text-danger');

    dataArr.forEach((element, index) => {
        if (element == '') {
            validationSpans[index].style.display = 'block';
        }
        else {
            validationSpans[index].style.display = 'none';
        }
    });


    if (Array.from(validationSpans).some(v => v.style.display == 'block') != true) {

        let startDate = new Date(start);
        let endDate = new Date(end);


        if (startDate < new Date()) {

            toastr.error('\u041d\u0430\u0447\u0430\u043b\u043e\u0442\u043e\u0020\u043d\u0430\u0020\u0441\u0440\u0435\u0449\u0430\u0442\u0430\u0020\u043d\u0435\u0020\u043c\u043e\u0436\u0435\u0020\u0434\u0430\u0020\u0435\u0020\u043f\u043e\u002d\u0440\u0430\u043d\u043e\u0020\u043e\u0442\u0020\u043c\u043e\u043c\u0435\u043d\u0442\u0430\u0020\u043d\u0430\u0020\u0441\u044a\u0437\u0434\u0430\u0432\u0430\u043d\u0435'.normalize());

        }
        else if (endDate < startDate) {
            toastr.error('\u041a\u0440\u0430\u044f\u0020\u043d\u0430\u0020\u0441\u0440\u0435\u0449\u0430\u0442\u0430\u0020\u043d\u0435\u0020\u043c\u043e\u0436\u0435\u0020\u0434\u0430\u0020\u0435\u0020\u043f\u0440\u0435\u0434\u0438\u0020\u043d\u0435\u0439\u043d\u043e\u0442\u043e\u0020\u043d\u0430\u0447\u0430\u043b\u043e'.normalize());
        }
        else if (new Date(end).getHours() - new Date(start).getHours() < 3) {
            toastr.error('\u041F\u0440\u043E\u0434\u044A\u043B\u0436\u0438\u0442\u0435\u043B\u043D\u043E\u0441\u0442\u0442\u0430 \u043D\u0430 \u0441\u0440\u0435\u0449\u0430\u0442\u0430 \u0442\u0440\u044F\u0431\u0432\u0430 \u0434\u0430 \u0435 \u043F\u043E\u043D\u0435 3 \u0447\u0430\u0441\u0430'.normalize());
        }
        else {

            let t = $("input[name='__RequestVerificationToken']").val();

            $.ajax({
                type: "POST",
                url: `/Meeting/Create`,
                data: {
                    'classId': classId,
                    'title': title,
                    'start': start,
                    'end': end,
                    'address': address
                },
                dataType: "json",
                headers: {
                    "RequestVerificationToken": t

                },
                success: async function (data) {
                    if (data) {

                        if (data.classIdNull) {
                            toastr.error('\u041d\u0435\u0020\u043c\u043e\u0436\u0435\u0020\u0434\u0430\u0020\u0434\u043e\u0431\u0430\u0432\u044f\u0442\u0435\u0020\u0441\u0440\u0435\u0449\u0430\u0020\u0431\u0435\u0437\u0020\u043a\u043b\u0430\u0441'.normalize())
                        }
                        else if (data.isExists) {
                            toastr.error('\u0421\u0440\u0435\u0449\u0430\u0020\u043f\u043e\u0020\u0442\u043e\u0432\u0430\u0020\u0432\u0440\u0435\u043c\u0435\u0020\u0432\u0435\u0447\u0435\u0020\u0441\u044a\u0449\u0435\u0441\u0442\u0432\u0443\u0432\u0430'.normalize());
                        }
                        else {
                            try {
                                await connection.invoke("SendMeeting", data.meetingId, data.receiversIds);
                            }
                            catch (err) {
                                console.error(err);
                            }
                            let url = window.location;
                            let params = (new URL(url)).searchParams;
                            let days = parseInt(params.get('days'))


                            window.location = `https://localhost:7256/Meeting/All?days=${days}`
                        }


                    }

                    console.log('Request added successfully');
                },
                error: function (error) {
                    toastr.error("\u041D\u0435\u043F\u0440\u0430\u0432\u0438\u043B\u0435\u043D \u043A\u0440\u0430\u0435\u043D \u0447\u0430\u0441".normalize());
                }
            });
        }
    }

}

connection.on("ReceiveDelete", function (meetingId) {

    var divMeeting = document.getElementById(`${meetingId}`);

    divMeeting.parentNode.removeChild(divMeeting);

});

connection.on("ReceiveEditedMeeting", async function (meetingId, receivers) {

    var divMeeting = document.getElementById(`${meetingId}`);

    divMeeting.parentNode.removeChild(divMeeting);

    try {
        await connection.invoke("SendMeeting", meetingId, receivers);
    }
    catch (err) {
        console.error(err);
    }

});


connection.on("ReceiveMeeting", function (meeting, id) {

    let hours = {
        "09": "9",
        "10": "10",
        "11": "11",
        "12": "12",
        "13": "1",
        "14": "2",
        "15": "3",
        "16": "4",
        "17": "5",
        "18": "6"
    }

    let divParent = document.querySelector(`div.day-${meeting.day} div.events`);

    let divChild = document.createElement('div');
    divChild.classList.add(`event`);
    divChild.classList.add(`start-${hours[meeting.startHour]}`);
    divChild.classList.add(`end-${hours[meeting.endHour]}`);
    divChild.classList.add(`corp-fi`);
    divChild.id = id;

    divChild.innerHTML = ` <p class="title">${meeting.title} \u002d ${meeting.class}</p>
                       <p class="title">${meeting.address}</p>
                       <p class="time">${meeting.startHour} \u0447. - ${meeting.endHour} \u0447.</p>
                       `.normalize();


    divParent.appendChild(divChild);



});

document.getElementById('addEvent').addEventListener('submit', create);



