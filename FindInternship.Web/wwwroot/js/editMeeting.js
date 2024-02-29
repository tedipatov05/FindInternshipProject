
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

    let companyId = document.getElementById('companyId').value;

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

        let startArr = start.split(' ')[0].split('.');
        let startMonthIndex = parseInt(startArr[1]) - 1;
        let startDay = parseInt(startArr[0]);
        let startYear = parseInt(startArr[2]);

        let endArr = end.split(' ')[0].split('.');
        let endMonthIndex = parseInt(endArr[1]) - 1;
        let endDay = parseInt(endArr[0]);
        let endYear = parseInt(endArr[2]);



        let startHour = parseInt(start.split(' ')[2].split(':')[0]);
        let endHour = parseInt(end.split(' ')[2].split(':')[0]);



        let startDate = new Date(startYear, startMonthIndex, startDay, startHour);
        let endDate = new Date(endYear, endMonthIndex, endDay, endHour);
        

        if (startHour < 9 || endHour > 18) {
            toastr.error('\u0421\u0440\u0435\u0449\u0430\u0442\u0430\u0020\u0442\u0440\u044f\u0431\u0432\u0430\u0020\u0434\u0430\u0020\u0435\u0020\u043c\u0435\u0436\u0434\u0443\u0020\u0039\u003a\u0030\u0030\u0020\u0438\u0020\u0031\u0038\u003a\u0030\u0030\u0020\u0447\u0430\u0441\u0430'.normalize())
        }
        else if (startDate < new Date()) {

            toastr.error('\u041d\u0430\u0447\u0430\u043b\u043e\u0442\u043e\u0020\u043d\u0430\u0020\u0441\u0440\u0435\u0449\u0430\u0442\u0430\u0020\u043d\u0435\u0020\u043c\u043e\u0436\u0435\u0020\u0434\u0430\u0020\u0435\u0020\u043f\u043e\u002d\u0440\u0430\u043d\u043e\u0020\u043e\u0442\u0020\u043c\u043e\u043c\u0435\u043d\u0442\u0430\u0020\u043d\u0430\u0020\u0441\u044a\u0437\u0434\u0430\u0432\u0430\u043d\u0435'.normalize());

        }
        else if (endDate < startDate) {
            toastr.error('\u041a\u0440\u0430\u044f\u0020\u043d\u0430\u0020\u0441\u0440\u0435\u0449\u0430\u0442\u0430\u0020\u043d\u0435\u0020\u043c\u043e\u0436\u0435\u0020\u0434\u0430\u0020\u0435\u0020\u043f\u0440\u0435\u0434\u0438\u0020\u043d\u0435\u0439\u043d\u043e\u0442\u043e\u0020\u043d\u0430\u0447\u0430\u043b\u043e'.normalize());
        }
        else if (parseInt(end.split(' ')[2].split(':')[0]) - parseInt(start.split(' ')[2].split(':')[0]) < 3) {
            toastr.error('\u041F\u0440\u043E\u0434\u044A\u043B\u0436\u0438\u0442\u0435\u043B\u043D\u043E\u0441\u0442\u0442\u0430 \u043D\u0430 \u0441\u0440\u0435\u0449\u0430\u0442\u0430 \u0442\u0440\u044F\u0431\u0432\u0430 \u0434\u0430 \u0435 \u043F\u043E\u043D\u0435 3 \u0447\u0430\u0441\u0430'.normalize());
        }
        else {
            let t = $("input[name='__RequestVerificationToken']").val();
            $.ajax({
                type: "POST",
                url: path,
                data: {
                    'title': title,
                    'start': start,
                    'end': end,
                    'address': address,
                    'companyId': companyId
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
}

document.getElementById('editEvent').addEventListener("submit", edit);