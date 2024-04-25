
const createForm = document.getElementById('post-form');
const addButtonElement = document.getElementById('addMeeting');




addButtonElement.addEventListener('click', async () => {
    let url = new URL(window.location);
    let token = $("input[name='__RequestVerificationToken']").val();

    const topic = document.getElementById('topic').value;
    const content = document.getElementById('content').value;
    const photos = document.getElementById('files').files;

    let data = new FormData();
    data.append('topic', topic);
    data.append('content', content);
    for (let i = 0; i < photos.length; i++) {
        data.append('photos', photos[i]);
    }



    $.ajax({
        method: 'POST', 
        url: "/Blog/CreatePost",
        data: data, 
        processData: false,
        contentType: false,
        headers: {
            "RequestVerificationToken": token
        },
        success: function () {
           window.location = url.origin + '/Blog/BlogHome'
        },
        error: function (error) {
            console.error(error);
        }
    })
});


