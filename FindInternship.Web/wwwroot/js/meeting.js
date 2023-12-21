
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
    })


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

                try {
                    await connection.invoke("SendMeeting", data.meetingId, data.receiversIds);
                }
                catch (err) {
                    console.error(err);
                }
                

                window.location = `https://localhost:7256/Meeting/All`

            }

            console.log('Request added successfully');
        },
        error: function (error) {
            toastr.error("\u041D\u0435\u043F\u0440\u0430\u0432\u0438\u043B\u0435\u043D \u043A\u0440\u0430\u0435\u043D \u0447\u0430\u0441".normalize());
        }
    });




}


connection.on("ReceiveMeeting", function (meeting) {

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

    divChild.innerHTML = ` <p class="title">${meeting.title}</p>
                       <p class="title">${meeting.address}</p>
                       <p class="time">${meeting.startHour} \u0447. - ${meeting.endHour} \u0447.</p>
                       `.normalize();


    divParent.appendChild(divChild);



    console.log("hello")
    
});

document.getElementById('addEvent').addEventListener('submit', create);


