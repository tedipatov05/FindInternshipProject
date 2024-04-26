
const createForm = document.getElementById('post-form');
const addButtonElement = document.getElementById('addMeeting');

let filesContainer = document.getElementById('files-container');
document.getElementById('files').addEventListener('input', function () {
    let files = Array.from(this.files);
    if (files.length == 0) {
        filesContainer.innerHTML = '<div class="default text-light">Моля прикачете вашите файлове</div>';
    } else {
        for (let i = 0; i < files.length; i++) {
            let file = files[i];
            let div = document.createElement('div');
            div.classList.add('input-group-text');
            div.classList.add('pl-2');
            div.classList.add('pr-2');
            div.style = 'margin-left: 10px; margin-top: 0.5rem;height: fit-content';

            let imageSrc = URL.createObjectURL(file);

            div.innerHTML = `<div style="display: flex; flex-direction: row;"><img src="${imageSrc}" style="height: 120px; width: 120px"></img>
                                    
                             </div>`

            filesContainer.appendChild(div);

            filesContainer.style.height = 'fit-content';

        }


    }

});

addButtonElement.addEventListener('click', (e) => {
    e.preventDefault();

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
        success: function (data) {
            if (!data.isCompany) {
                toastr.error(`Трябва да си фирма, за да добавяш постове`);
            }
            else {
                
            }

            window.location = url.origin + '/Blog/BlogHome'
            


        },
        error: function (error) {
            console.error(error);
        }
    })
});




