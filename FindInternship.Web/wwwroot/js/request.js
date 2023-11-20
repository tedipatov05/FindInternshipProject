"use strict"

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/requestHub")
    .build();

document.getElementById('send').disabled = true;

connection.start().then(function () {
    document.getElementById("send").disabled = false;
}).catch(function (err) {

    return console.error(err.toString());
});

document.getElementById('send').addEventListener('click', function (event) {

    let messageText = String(document.getElementById('message').value);
    let topicText = String(document.getElementById('topic').value);
    let companyText = String(document.getElementById('company').innerHTML);

    let data = new FormData();
   
    if (message == null) {
        document.getElementsByClassName('text-danger')[1].textContent = 'Това поле е задължително';
       
    }
    if (topic == null) {
        document.getElementsByClassName('text-danger')[0].textContent = 'Това поле е задължително';
       
    }
    else {
        document.getElementsByClassName('text-danger')[1].textContent = '';
        document.getElementsByClassName('text-danger')[0].textContent = '';

        data.append('company', companyText)
        data.append('topic', topicText)
        data.append('message', messageText)

        let t = $("input[name='__RequestVerificationToken']").val();

        $.ajax({
            type: "POST",
            url: `/Request/Create`,
            data: {
                'company': companyText,
                'topic': topicText,
                'message': messageText
            },
            dataType: "json",
            headers: {
                "RequestVerificationToken": t

            },
            success: function (data) {
                if (data) {

                    connection.invoke("SendRequest", topicText, messageText, data.requestId, data.companyUserId);
                    window.location = `https://localhost:7256/Company/All`

                    
                }

                console.log('Request added successfully');
            },
            error: function (error) {
                console.error(error.statusCode);
                console.error('Error occurred while removing object');
            }
        });
       
    }

    event.preventDefault();


});
