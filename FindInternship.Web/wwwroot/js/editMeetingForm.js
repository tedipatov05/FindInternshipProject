$(document).ready(function ($) {

    //document.getElementById('start-date').addEventListener('focus', function () {
    //    this.type = 'datetime-local'
    //    document.getElementById('label-start').style = 'transform: translateY(-50%) scale(0.8);background-color: #212121; padding: 0 0.2em; color: #2196f3;'
    //});

    //document.getElementById('end-date').addEventListener('focus', function () {
    //    this.type = 'datetime-local'
    //    document.getElementById('label-end').style = 'transform: translateY(-50%) scale(0.8);background-color: #212121; padding: 0 0.2em; color: #2196f3;'
    //});


    let filesContainer = document.getElementById('files-container');

    document.getElementById('files').addEventListener('input', function () {
        document.getElementById('files-container').innerHTML = '';
        let files = Array.from(this.files);
        if (files.length == 0) {
            filesContainer.innerHTML = '<div class="default">Моля прикачете вашите файлове</div>';
        } else {
            for (let i = 0; i < files.length; i++) {
                let file = files[i];
                let div = document.createElement('div');
                div.classList.add('input-group-text');
                div.classList.add('pl-2');
                div.classList.add('pr-2');
                div.style = 'margin-left: 10px; margin-top: 0.5rem;';

                div.innerHTML = `<div style="display: flex; flex-direction: row;"><img src="/img/google-docs.png" style="height: 26px; width: 26px"></img>
                                    <div class="pl-1 pt-1 text-dark" style="font-size: medium; padding-top:2px; margin-left: 0.5rem">${file.name}</div>
                                 </div>`

                filesContainer.appendChild(div);

            }


        }

    });

});