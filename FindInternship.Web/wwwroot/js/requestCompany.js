var connection = new signalR.HubConnectionBuilder()
    .withUrl("/requestHub")
    .build();

connection.on("ReceiveRequest", function (topic, message, status, date, id) {
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
                                    <h5 class="mb-1 font-size-17 team-title" id="topic">${topic}</h5>
                                    <p class="text-muted mb-0 team-description" id="message">
                                        ${message}
                                    </p>
                                </div>
                                <div class="d-flex">
                                    <div class="avatar-group float-start flex-grow-1 task-assigne">
                                    </div>
                                    <div class="align-self-end">
                                        <div class="dropdown">
                                            <a class="badge badge-soft-${colors[status]} p-2 team-status dropdown-toggle" id="status-${id}" style="text-decoration: none; font-size: 1rem" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                                ${status}
                                            </a>

                                            <ul class="dropdown-menu">
                                                <li><a class="dropdown-item" onclick="changeStatus('Accepted', '${id}')">Accept</a></li>
                                                <li><a class="dropdown-item" onclick="changeStatus('Rejected', '${id}')">Reject</a></li>
                                                <li><a class="dropdown-item" onclick="changeStatus('Waiting', '${id}')">Waiting</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>`

    document.getElementById('all-projects').appendChild(div);

});

connection.on("ReceiveNewStatus", function (newStatus, id) {

    let statusStyles = {
        "Waiting": "warning",
        "Rejected": "danger",
        "Accepted": "success"
    };

    

    let oldStatus = document.getElementById(`status-${id}`).textContent.trim();
    document.getElementById(`status-${id}`).textContent = newStatus;
    document.getElementById(`status-${id}`).classList.remove(`badge-soft-${statusStyles[oldStatus]}`);
    document.getElementById(`status-${id}`).classList.add(`badge-soft-${statusStyles[newStatus]}`);

    if (newStatus == "Accepted") {
        document.getElementById('btn-documents').style.display = 'block';
    }
    else {
        document.getElementById('btn-documents').style.display = 'none';
    }


})

connection.start().then(function () {
    
}).catch(function (err) {
    return console.error(err.toString());
});


function changeStatus(newStatus, id) {
    
    let statusStyles = {
        "Waiting": "warning",
        "Rejected": "danger",
        "Accepted": "success"
    };

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
            if (data.isEdited) {

                connection.invoke("ChangeRequestStatus", id, newStatus);

                let oldStatus = document.getElementById(`status-${id}`).textContent.trim();
                document.getElementById(`status-${id}`).textContent = newStatus;
                document.getElementById(`status-${id}`).classList.remove(`badge-soft-${statusStyles[oldStatus]}`);
                document.getElementById(`status-${id}`).classList.add(`badge-soft-${statusStyles[newStatus]}`);

                if (newStatus == "Accepted") {
                    document.getElementById('btn-documents').style.display = 'block';
                }
                else {
                    document.getElementById('btn-documents').style.display = 'none';
                }

                
            }
        },
        error: function (msg) {
            console.error(msg);
        }
    });
}
