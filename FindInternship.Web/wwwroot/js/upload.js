
Array.from(document.getElementsByClassName('btn badge-soft-secondary doc')).forEach(e =>
    e.addEventListener('click', (ev) => {

        let id = ev.target.id.slice(14);
        requestId = id;
        let button = document.getElementById('update');

        button.setAttribute('name', id);

    })
)

function handleFileSelect(evt) {

    const files = evt.target.files;

    let template = `${Object.keys(files)
        .map(file => `<div class="file file--${file}">
     <div class="name"><span class="text-dark">${files[file].name}</span></div>
     <div class="progress active"></div>
     <div class="done">
	<a href="" target="_blank">
      <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" x="0px" y="0px" viewBox="0 0 1000 1000">
		<g><path id="path" d="M500,10C229.4,10,10,229.4,10,500c0,270.6,219.4,490,490,490c270.6,0,490-219.4,490-490C990,229.4,770.6,10,500,10z M500,967.7C241.7,967.7,32.3,758.3,32.3,500C32.3,241.7,241.7,32.3,500,32.3c258.3,0,467.7,209.4,467.7,467.7C967.7,758.3,758.3,967.7,500,967.7z M748.4,325L448,623.1L301.6,477.9c-4.4-4.3-11.4-4.3-15.8,0c-4.4,4.3-4.4,11.3,0,15.6l151.2,150c0.5,1.3,1.4,2.6,2.5,3.7c4.4,4.3,11.4,4.3,15.8,0l308.9-306.5c4.4-4.3,4.4-11.3,0-15.6C759.8,320.7,752.7,320.7,748.4,325z"</g>
		</svg>
						</a>
     </div>
    </div>`)
        .join("")}`;

    document.querySelector("#drop").classList.add("hidden");
    document.querySelector("footer").classList.add("hasFiles");
    document.querySelector(".importar").classList.add("active");
    setTimeout(() => {
        document.querySelector(".list-files").innerHTML = template;
    }, 1000);

    Object.keys(files).forEach(file => {
        let load = 2000 + (file * 2000);
        setTimeout(() => {
            document.querySelector(`.file--${file}`).querySelector(".progress").classList.remove("active");
            document.querySelector(`.file--${file}`).querySelector(".done").classList.add("anim");
        }, load);
    });
}

document.getElementById("triggerFile").addEventListener("click", evt => {
    evt.preventDefault();
    document.querySelector("input[type=file]").click();
});

document.querySelector("#drop").ondragleave = evt => {
    document.querySelector("#drop").classList.remove("active");
    evt.preventDefault();
};

document.querySelector("#drop").ondragover = $("#drop").ondragenter = evt => {
    document.querySelector("#drop").classList.add("active");
    evt.preventDefault();
};

document.querySelector("#drop").ondrop = evt => {
    document.querySelector("input[type=file]").files = evt.dataTransfer.files;
    document.querySelector("footer").classList.add("hasFiles");
    document.querySelector("#drop").classList.remove("active");
    evt.preventDefault();
};


document.getElementById("update").addEventListener("click", function (ev) {

    let files = document.querySelector("input[type=file]").files;
    let requestId = String(document.getElementById('update').name);

    let token = document.querySelector("input[name='__RequestVerificationToken']").value;

    let data = new FormData();

    for (var i = 0; i < files.length; i++) {
        data.append('files', files[i]);
    }


    data.append('requestId', requestId);



    $.ajax({
        type: "POST",
        url: `/Document/Upload`,
        data: data,
        headers: {
            "RequestVerificationToken": token

        },
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.fancybox-close-small')[0].click()

        },
        success: async function (data) {

            if (data.isRequestExists == false) {
                toastr.error('\u0422\u0430\u0437\u0438\u0020\u043c\u043e\u043b\u0431\u0430\u0020\u043d\u0435\u0020\u0441\u044a\u0449\u0435\u0441\u0442\u0432\u0443\u0432\u0430'.normalize())
            }
            else {
                try {
                    await connection.invoke("SendDocuments", data.documents, data.receiver, data.requestId);

                } catch (err) {
                    console.error(err)
                }

                let url = new URL(window.location);
                let params = url.searchParams;


                window.location = `${url.origin}/Request/CompanyRequests`
            }

            
            
        },
        error: function (error) {
            console.error(error.statusCode);
            console.error('Error occurred while uploading object');
        }
    });



    document.querySelector(".list-files").innerHTML = "";
    document.querySelector("footer").classList.remove("hasFiles");
    document.querySelector(".importar").classList.remove("active");
    setTimeout(() => {
        document.querySelector("#drop").classList.remove("hidden");
    }, 500);

    ev.preventDefault();
});

document.querySelector("input[type=file]").addEventListener("change", handleFileSelect);

