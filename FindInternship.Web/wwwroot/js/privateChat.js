"use strict"

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/privateChatHub")
    .build();


async function start() {
    try {
        await connection.start().then(function () {

            //let toUser = document.getElementById('toUser').textContent;
            //let fromUser = document.getElementById('fromUser').textContent;
            


        }).catch(function (err) {
            console.error(err.toString());
        });

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