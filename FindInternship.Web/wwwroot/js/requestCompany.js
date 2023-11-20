var connection = new signalR.HubConnectionBuilder()
    .withUrl("/requestHub")
    .build();

connection.on("ReceiveRequest", function (topic, message, status, date) {
    let div = document.createElement('div');
    let colors = {
        "Waiting": "warning", 
        "Accepted": "success", 
        "Rejected": "danger"
    }

    div.classList.add("col-md-6");

    div.innerHTML = `<div class="card">
                            <div class="card-body">
                                <div class="d-flex mb-3">
                                    <div class="flex-grow-1 align-items-start">
                                        <div>
                                            <h6 class="mb-0 text-muted">
                                                <i class="mdi mdi-circle-medium text-danger fs-3 align-middle"></i>
                                                <span class="team-date">${date}</span>
                                            </h6>
                                        </div>
                                    </div>

                                </div>

                                <div class="mb-4">
                                    <h5 class="mb-1 font-size-17 team-title">${topic}</h5>
                                    <p class="text-muted mb-0 team-description">
                                        ${message}
                                    </p>
                                </div>
                                <div class="d-flex">
                                    <div class="avatar-group float-start flex-grow-1 task-assigne">
                                    </div>
                                    <div class="align-self-end">
                                   
                                        <span class="badge badge-soft-${colors[status]} p-2 team-status" style="font-size: 1rem">${status}</span>
                                    </div>
                                </div>
                            </div>
                        </div>`

    document.getElementById('all-projects').appendChild(div);

});

connection.start().then(function () {
    
}).catch(function (err) {
    return console.error(err.toString());
});

function changeStatus(newStatus, id) {
    let statusStyles = {
        "Waiting": "warning",
        "Rejected": "danger",
        "Accepted": "success"
    }



    $.ajax({
        type: "POST",
        url: `/Request/EditStatus`,
        data: {
            'newStatus': newStatus,
            'id': id
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (data) {
            if (data) {
                let oldStatus = document.getElementById(`status-${id}`).textContent;
                document.getElementById(`status-${id}`).textContent = newStatus;
                document.getElementById(`status-${id}`).classList.remove(`badge-soft-${statusStyles[oldStatus]}`);
                document.getElementById(`status-${id}`).classList.add(`badge-soft-${statusStyles[newStatus]}`);
            }
        },
        error: function (msg) {
            console.error(msg);
        }
    });
}
