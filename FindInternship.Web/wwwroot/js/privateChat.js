"use strict"

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/privateChatHub")
    .build();

$(document).ready(function () {
    document.getElementById("loader-div").style.display = 'none';
    document.getElementById("loader-div").style.marginTop = '0px';
    document.getElementById('loader-main').style.display = 'none';
    document.getElementById('chat-body').style.visibility = 'visible';

    $('#chat-body')[0].scroll(0, $('#chat-body')[0].scrollHeight);
})

async function start() {
    try {
        await connection.start().then(function () {

            let toUser = document.getElementById('toUser').textContent;
            let fromUser = document.getElementById('fromUser').textContent;
            let groupName = document.getElementById('groupName').textContent

            connection.invoke("AddToGroup", `${groupName}`, toUser, fromUser).catch(function (err) {
                console.error(err);
            });

            console.log(`successfully added to group ${groupName}`);

            console.log('successfully connected')
            console.log("SignalR Connected.");

        }).catch(function (err) {
            console.error(err.toString());
        });


    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();

$('#send').click(function () {
    $('#sendButton').trigger('click');
});



document.getElementById('sendButton').addEventListener('click', function (event) {

    event.preventDefault();
    let toUser = document.getElementById('toUser').textContent;
    let fromUser = document.getElementById('fromUser').textContent;
    let groupName = document.getElementById('groupName').textContent;
    let message = document.getElementById('messageInput').value;
    let images = document.getElementById('uploadImage').files;
    let files = document.getElementById('uploadFile').files;
    let data = new FormData();

    for (var i = 0; i < images.length; i++) {
        data.append('files', images[i]);
    }

    for (var i = 0; i < files.length; i++) {
        data.append('files', files[i]);
    }

    if (message && images.length == 0 && files.length == 0) {

        document.getElementById('preloader').style.display = 'block';

        connection.invoke("SendMessage", fromUser, toUser, message, groupName).catch(function (err) {
            console.error(err);
        });

        connection.invoke("ReceiveMessage", fromUser, message, groupName).catch(function (err) {
            console.error(err);
        });
        document.getElementById('preloader').style.display = 'none';

        document.getElementById('messageInput').value = '';
    }
    else {
        data.append('group', groupName);
        data.append('toUsername', toUser);
        data.append('fromUsername', fromUser);
        data.append('message', message);

        if (images.length > 0 || files.length > 0) {

            let token = $("input[name='__RequestVerificationToken']").val();

            $.ajax({
                type: 'POST',
                url: `/PrivateChat/SendMessageWithFiles`,
                data: data,
                headers: {
                    "RequestVerificationToken": token
                },
                processData: false,
                contentType: false,
                beforeSend: function () {
                    document.getElementById('preloader').style.display = 'block';
                },
                success: function (haveFiles) {
                    document.getElementById('preloader').style.display = 'none';
                    document.getElementById('appendFiles').innerHTML = '';
                },
                error: function (err) {
                    document.getElementById('preloader').style.display = 'none';
                    console.error(err);
                    console.log(err.statusText)
                }
            });

            document.getElementById("uploadImage").value = "";
            document.getElementById("uploadFile").value = "";


        }
    }




})

connection.on("SendMessage", function (userId, fromUsername, fromUserImage, message) {

    let msg = message;
    let dateTime = new Date()
    let formattedDate =
        `${dateTime.getDate()}-${(dateTime.getMonth() + 1)}-${dateTime.getFullYear()} ${dateTime.getHours()}:${dateTime.getMinutes()}`;

    var chatHolder = document.getElementById('chatHolder');

    // message right 
    var msgDiv = document.createElement('div');

    msgDiv.classList.add('d-flex');
    msgDiv.classList.add('flex-row-reverse');
    msgDiv.classList.add('mb-2');

    if (fromUserImage == '' || fromUserImage == null) {
        fromUserImage = '/img/blank-profile-picture.png';
    }

    msgDiv.innerHTML = `<div class="media-left">
                            <img src="${fromUserImage}" class="rounded-circle shadow avatar-sm mr-3" alt="Profile Picture">

                        </div>
                        <div class="right-chat-message fs-13 mb-2">
                            <div class="mb-3 mr-3 pr-4">
                                <div class="d-flex flex-row">
                                    <div class="pr-2">${msg}</div>
                                    <div class="pr-4"></div>
                                </div>
                            </div>
                            <div class="message-options dark">
                                <div class="message-time">
                                    <div class="d-flex flex-row">
                                        <div class="mr-2">${formattedDate}</div>
                                       
                                    </div>
                                </div>
                                <div class="message-arrow"><i class="text-muted la la-angle-down fs-17"></i></div>
                            </div>
                        </div>`;

    chatHolder.appendChild(msgDiv);


});

connection.on("ReceiveMessage", function (fromUserName, fromUserImage, message) {


    let msg = message;
    let dateTime = new Date()
    let formattedDate =
        `${dateTime.getDate()}-${(dateTime.getMonth() + 1)}-${dateTime.getFullYear()} ${dateTime.getHours()}:${dateTime.getMinutes()}`;


    let chatHolder = document.getElementById('chatHolder');


    //message Left
    let div = document.createElement('div');
    div.classList.add('d-flex');

    if (fromUserImage == '' || fromUserImage == null) {
        fromUserImage = '/img/blank-profile-picture.png';
    }

    div.innerHTML = `<div style="margin-right: 15px">
                        <img src="${fromUserImage}" class="rounded-circle shadow avatar-sm mr-3" alt="Profile Picture">
                     </div>
                     <div class="left-chat-message fs-13 mb-2">
                         <p class="mb-3 mr-3 pr-4">${msg}</p>
                         <div class="message-options">
                             <div class="message-time">${formattedDate}</div>
                             <div class="message-arrow"><i class="text-muted la la-angle-down fs-17"></i></div>
                         </div>
                     </div>`;

    chatHolder.appendChild(div);



});


function addFiles(files) {

    let icons = {
        "PDF": "bi bi-file-pdf-fill",
        "PNG": "bi bi-file-earmark-image",
        "JPG": "bi bi-file-earmark-image",
        "JPEG": "bi bi-file-earmark-image",
        "ZIP": "bi bi-file-zip",
        "RAR": "bi bi-file-zip",
        "DOCX": "bi bi-file-earmark-fill",
        "DOC": "bi bi-file-earmark-fill",
        "PPT": "bi bi-filetype-ppt",
        "TXT": "bi bi-file-text",
        "TEXT": "bi bi-file-text",
        "XLS": "bi bi-filetype-xls",
        "XLSX": "bi bi-filetype-xlsx",

    }

    var appendFiles = document.getElementById('appendFiles');


    for (let i = 0; i < files.length; i++) {
        let file = files[i];

        let span = document.createElement('span');
        span.classList.add('input-group-text')
        span.classList.add('pl-2')
        span.classList.add('pr-2');
        span.style = "margin-left: 10px;"

        let fileExtension = file.name.split('.').pop();

        span.innerHTML = ` <div style="display: flex; flex-direction: row;">
                            <i class="${icons[fileExtension.toUpperCase()]}"></i>
                            <div class="pl-1 pt-1 text-dark" style="font-size: small;">${file.name}</div>
                           </div>`

        appendFiles.appendChild(span);

        
    }


}