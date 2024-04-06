

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/requestHub")
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



let dataIds = [];

Array.from(document.querySelectorAll('div.item1 div > a')).forEach(element => {
    element.addEventListener('click', function () {
        dataIds.push(element.id);
        element.parentNode.innerHTML = `<img src="/img/check-mark.png" width="20" height="20"/>
                                        <span style="margin-left: 0.4rem;">Избран</span>`
    });
    
});

let acceptBtn = document.getElementById('accept-btn');

let token = $("input[name='__RequestVerificationToken']").val();

let requestId = document.getElementById('request-id').value;
acceptBtn.addEventListener("click", function () {
    if (dataIds.length < 0 || dataIds == null) {
        toastr.error(`Трябва да избереш ученици, за да одобриш молбатра за практика`);
    }
    else {

        $.ajax({
            method: 'POST',
            url: '/Request/ChooseStudents',
            data: {
                'studentIds': dataIds,
                'requestId': requestId
            },
            headers: {
                "RequestVerificationToken": token
            },
            dataType: 'json',
            success: async function (data) {
                if (!data.isAllExists) {
                    toastr.error(`Някои от избраните ученици не съществува`)
                }
                else if (data.isAllExists && data.result && data.isEditedRequest) {

                    let newStatus = "Accepted";
                    try {
                        await connection.invoke("ChangeRequestStatus", requestId, newStatus);
                    }
                    catch (err) {
                        console.error(err)
                    }

                    let url = new URL(window.location);

                    window.location = `${url.origin}/Request/CompanyRequests`
                }

            },
            error: function (err) {
                console.error(err.message);
            }

        });

    }
});



