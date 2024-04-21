
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/roomHub")
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
})

start();

document.getElementById('send-btn').addEventListener('click', function () {

    let url = new URL(window.location);
    let params = url.searchParams;
    let meetingId = params.get('meetingId');

    let message = document.getElementById('chat-input').value;
    let senderName = document.getElementById('sender-username').value;

    connection.invoke('SendMessage', message, senderName, meetingId); 

});

connection.on('ReceiveMessage', function (picture, message, senderName) {
    let name = document.getElementById('sender-username').value;
    let messagesContainer = document.getElementById('message-holder');

    let messageWrapper = document.createElement('div');
    messageWrapper.classList.add('message-wrapper');
    let divImage = document.createElement('div');
    divImage.classList.add('profile-picture');
    let img = document.createElement('img');
    img.src = picture;
    divImage.appendChild(img);
    messageWrapper.appendChild(divImage);

    let messageContent = document.createElement('div');
    messageContent.classList.add('message-content');
    let namePara = document.createElement('p');
    namePara.classList.add('name');
    namePara.textContent = senderName;
    messageContent.appendChild(namePara);

    let divContent = document.createElement('div');
    divContent.classList.add('message');
    divContent.textContent = message;
    messageContent.appendChild(divContent);
    messageWrapper.appendChild(messageContent);

    if (name == senderName) {
        
        messageWrapper.classList.add('reverse');
    }

    messagesContainer.appendChild(messageWrapper);
    document.getElementById('chat-input').value = '';

});

