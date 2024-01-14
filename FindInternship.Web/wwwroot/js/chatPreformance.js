(function ($) {
    "use strict";

    $('.scrollable-chat-panel').perfectScrollbar();
    var position = $(".chat-search").last().position().top;
    $('.scrollable-chat-panel').scrollTop(position);
    $('.scrollable-chat-panel').perfectScrollbar('update');
    $('.pagination-scrool').perfectScrollbar();

    $('.chat-upload-trigger').on('click', function (e) {
        $(this).parent().find('.chat-upload').toggleClass("active");
    });
    $('.user-detail-trigger').on('click', function (e) {
        $(this).closest('.chat').find('.chat-user-detail').toggleClass("active");
    });
    $('.user-undetail-trigger').on('click', function (e) {
        $(this).closest('.chat').find('.chat-user-detail').toggleClass("active");
    });
})(jQuery); 

$(document).ready(function () {
    $('#chat-body').scroll(function () {
        let scrollHeight = document.getElementById('chat-body').scrollHeight;
        let scrollDistanceToTop = document.getElementById('chat-body').scrollTop;
        let chatBodyHeight = document.getElementById('chat-body').offsetHeight;
        let distanceToBottom = scrollHeight - scrollDistanceToTop - chatBodyHeight;


        if ($('#chat-body').scrollTop() == 0)
        {
            let messagesSkipCount = document.getElementById('messagesSkipCount').value;
            let username = document.getElementById('toUser').textContent;
            let group = document.getElementById('groupName').textContent;

            if (messagesSkipCount && username && group) {

                let token = $("input[name='__RequestVerificationToken']").val();
                document.getElementById('loader').style.display = 'block';

                $.ajax({
                    type: "Get",
                    url: "/PrivateChat/LoadMoreMessages",
                    data: {
                        'username': username,
                        'group': group,
                        'messagesSkipCount': messagesSkipCount,
                    },
                    headers: {
                        "RequestVerificationToken": token
                    },
                    success: function (data) {
                        let oldCount = parseInt(document.getElementById('messagesSkipCount').value);
                        document.getElementById('messagesSkipCount').value = oldCount + data.length;
                        let oldScrollHeight = document.getElementById('chat-body').scrollHeight;

                        for (var message of data) {

                            var msgDiv = document.createElement('div');
                            if (message.fromUsername == message.currentUsername) {
                                

                                msgDiv.classList.add('d-flex');
                                msgDiv.classList.add('flex-row-reverse');
                                msgDiv.classList.add('mb-2');

                                msgDiv.innerHTML = `<div class="media-left">
                                                        <img src="${message.fromImageUrl}" class="rounded-circle shadow avatar-sm mr-3" alt="Profile Picture">
                                                    </div>
                                                    <div class="right-chat-message fs-13 mb-2">
                                                        <div class="mb-3 mr-3 pr-4">
                                                            <div class="d-flex flex-row">
                                                                <div class="pr-2">${message.content}</div>
                                                                <div class="pr-4"></div>
                                                            </div>
                                                        </div>
                                                        <div class="message-options dark">
                                                            <div class="message-time">
                                                                <div class="d-flex flex-row">
                                                                    <div class="mr-2">${message.sendedOn}</div>
                                                                   
                                                                </div>
                                                            </div>
                                                            <div class="message-arrow"><i class="text-muted la la-angle-down fs-17"></i></div>
                                                        </div>
                                                    </div>`;
                            }
                            else {

                               
                                msgDiv.classList.add('d-flex');

                                msgDiv.innerHTML = `<div style="margin-right: 15px">
                                                   <img src="${message.fromImageUrl}" class="rounded-circle shadow avatar-sm mr-3" alt="Profile Picture">
                                                </div>
                                                <div class="left-chat-message fs-13 mb-2">
                                                    <p class="mb-3 mr-3 pr-4">${message.content}</p>
                                                    <div class="message-options">
                                                        <div class="message-time">${message.sendedOn}</div>
                                                        <div class="message-arrow"><i class="text-muted la la-angle-down fs-17"></i></div>
                                                    </div>
                                                </div>`;



                            }

                            let firstMessage = document.getElementById('chatHolder').firstChild;
                            document.getElementById('chatHolder').insertBefore(msgDiv, firstMessage);
                        }

                        let scroll = document.getElementById("chat-body");
                        let newScrollTop = scroll.scrollHeight - oldScrollHeight;
                        scroll.scrollTop = newScrollTop;

                        document.getElementById('loader').style.display = 'none';

                    }, 
                    error: function (err) {
                        console.error(err);
                    }
                })

            }
        }


    })
})

