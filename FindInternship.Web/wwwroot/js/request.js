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

    let message = String(document.getElementById('message').value);
    let topic = String(document.getElementById('topic').value);
    let company = String(document.getElementById('company').innerHTML);

    let data = new FormData();
   
  
    if (message == null) {
        document.getElementsByClassName('text-danger')[1].textContent = 'Това поле е задължително';
       
    }
    if (topic == null) {
        document.getElementsByClassName('text-danger')[0].textContent = 'Това поле е задължително';
       
    }
    else {

        data.append('company', company.toString())
        data.append('topic', topic.toString())
        data.append('message', message.toString())

        postRequest(data);
       
        document.getElementsByClassName('text-danger')[1].textContent = '';
        document.getElementsByClassName('text-danger')[0].textContent = '';

    }

    event.preventDefault();


});


function postRequest(data) {
    $.ajax({
        url: '/Request/Create',
        processData: false,
        contentType: false,
        type: 'POST',
        data: data,
        success: function () {

            console.log('Request added successfully');
            connection.invoke("SendRequest", topic, message);
        },
        error: function () {
            console.error('Error occurred while removing object');
        }
    });
}
