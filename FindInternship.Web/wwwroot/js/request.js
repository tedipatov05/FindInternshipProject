"use strict"

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


start()

document.getElementById('send').addEventListener('click', function (event) {

    let messageText = String(document.getElementById('message').value);
    let topicText = String(document.getElementById('topic').value);
    let companyText = String(document.getElementById('company').innerHTML);

    let data = new FormData();
   
    if (messageText == "") {
        document.getElementsByClassName('text-danger')[1].style.display = 'block';
       
    }
    
    if (topicText == "") {
        document.getElementsByClassName('text-danger')[0].style.display = 'block';
       
    }
    else {

        document.getElementsByClassName('text-danger')[1].style.display = 'none';
        document.getElementsByClassName('text-danger')[0].style.display = 'none';

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
            success: async function (data) {
                if (data) {
                    try {
                        await connection.invoke("SendRequest", topicText, messageText, data.requestId, data.companyUserId);

                    }
                    catch (err) {
                        console.error(err)
                    }

                    let url = new URL(window.location);
                    let params = url.searchParams;

                    window.location = `${url.origin}/Company/All`
                   
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
