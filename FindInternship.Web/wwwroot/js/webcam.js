const webcamElement = document.getElementById('webcam');

const canvasElement = document.getElementById('canvas');

const snapSoundElement = document.getElementById('snapSound');

const webcam = new Webcam(webcamElement, 'user', canvasElement, snapSoundElement);

let hideElement = true;


$("#photo-take").click(function () {

    $('.md-modal').addClass('md-show');
    webcam.start()
        .then(result => {
            cameraStarted();
            //console.log("webcam started");
        })
        .catch(err => {
            displayError();
        });

});

function b64toFile(b64Data, contentType, sliceSize) {
    contentType = contentType || '';
    sliceSize = sliceSize || 512;

    var byteCharacters = atob(b64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);

        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        var byteArray = new Uint8Array(byteNumbers);

        byteArrays.push(byteArray);
    }

    var file = new File(byteArrays, "selfie", { type: contentType });
    return file;
}


$('#cameraFlip').click(function () {
    webcam.flip();
    webcam.start();
});

$('#closeError').click(function () {
    $("#webcam-switch").prop('checked', false).change();
});

let file = null;

$("#take-photo").click(function () {
    beforeTakePhoto();
    let picture = webcam.snap();
    document.querySelector('#download-photo').href = picture;

    let ImageURL = picture;
    let block = ImageURL.split(";");

    let contentType = block[0].split(":")[1];

    let realData = block[1].split(",")[1];


    file = b64toFile(realData, contentType);


    afterTakePhoto();
});

$('#send-photo').click(function () {
    if (file != null) {
        let data = new FormData();

        let toUser = document.getElementById('toUser').textContent;
        let fromUser = document.getElementById('fromUser').textContent;
        let groupName = document.getElementById('groupName').textContent;
        let message = document.getElementById('messageInput').value;
        data.append('group', groupName);
        data.append('toUsername', toUser);
        data.append('fromUsername', fromUser);
        data.append('message', message);
        data.append('files', file);

        let token = $("input[name='__RequestVerificationToken']").val();

        removeCapture();
        cameraStopped();

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




    }
})

$("#resume-camera").click(function () {
    webcam.stream()
        .then(facingMode => {
            removeCapture();
        });
});

$("#exit-app").click(function () {
    removeCapture();
    $("#webcam-switch").prop("checked", false).change();
    cameraStopped()
});

function displayError(err = '') {
    if (err != '') {
        $("#errorMsg").html(err);
    }
    $("#errorMsg").removeClass("d-none");
}

function cameraStarted() {
    $("#errorMsg").addClass("d-none");
    $('.flash').hide();
    $("#webcam-caption").html("on");
    $("#webcam-control").removeClass("webcam-off");
    $("#webcam-control").addClass("webcam-on");
    $(".webcam-container").removeClass("d-none");
    if (webcam.webcamList.length > 1) {
        $("#cameraFlip").removeClass('d-none');
    }
    if (hideElement) {
        $("#wpfront-scroll-top-container").addClass("d-none");
        $(".sd-sharing-enabled").addClass("d-none d-lg-block");
        $(".floatingchat-container-wrap-mobi").addClass("d-none");
    }
    window.scrollTo(0, 0);
    $('body').css('overflow-y', 'hidden');
}

function cameraStopped() {
    webcam.stop();
    $("#errorMsg").addClass("d-none");
    $("#webcam-control").removeClass("webcam-on");
    $("#webcam-control").addClass("webcam-off");
    $("#cameraFlip").addClass('d-none');
    $(".webcam-container").addClass("d-none");
    $("#webcam-caption").html("Click to Start Camera");
    $('.md-modal').removeClass('md-show');
}


function beforeTakePhoto() {
    $('.flash')
        .show()
        .animate({ opacity: 0.3 }, 500)
        .fadeOut(500)
        .css({ 'opacity': 0.7 });
    window.scrollTo(0, 0);
    $('#webcam-control').addClass('d-none');
    $('#cameraControls').addClass('d-none');
}

function afterTakePhoto() {
    webcam.stop();
    $('#canvas').removeClass('d-none');
    $('#take-photo').addClass('d-none');
    $('#exit-app').removeClass('d-none');
    $('#send-photo').removeClass('d-none');
    $('#download-photo').removeClass('d-none');
    $('#resume-camera').removeClass('d-none');
    $('#cameraControls').removeClass('d-none');
}

function removeCapture() {
    $('#canvas').addClass('d-none');
    $('#webcam-control').removeClass('d-none');
    $('#cameraControls').removeClass('d-none');
    $('#take-photo').removeClass('d-none');
    $('#send-photo').addClass('d-none');
    $('#download-photo').addClass('d-none');
    $('#resume-camera').addClass('d-none');
}