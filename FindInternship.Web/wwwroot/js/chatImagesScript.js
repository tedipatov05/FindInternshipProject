
$('#imageButton i').click(function () {
    $('#uploadImage').trigger('click');
})

$('#uploadImage').on('change', function () {
    const imageExtensions = ['PNG', 'JPG', 'JPEG'];
    let files = document.getElementById('uploadImage').files;
    const dtImages = new DataTransfer();
    const dtFiles = new DataTransfer();

    for (let file in files) {
        let fileExtension = file.name.split('.').pop();
        if (imageExtensions.includes(fileExtension.toUppercase())) {
            let sizeInMB = (file.size / (1024 * 1024)).toFixed(2);
            if (sizeInMB > 15) {
                continue;
            }

            dtImages.items.add(file);
        }
        else {
            let sizeInMB = (file.size / (1024 * 1024)).toFixed(2);
            if (sizeInMB > 15) {
                continue;
            }

            dtFiles.items.add(file);
        }
    }

    document.getElementById('uploadImage').files = dtImages;

    if (dtFiles.items.length > 0) {
        transferFiles(dtFiles);
    }
});

function transferImages(dtImages) {
    const imageExtensions = ["JPG", "PNG", "JPEG"];
    let images = document.getElementById("uploadImage").files;
    const dt = new DataTransfer();

    for (let image of images) {
        let fileExtension = image.name.split('.').pop();
        if (imageExtensions.includes(fileExtension.toUpperCase())) {
            dt.items.add(image);
        }
    }

    for (let image of dtImages.files) {
        let fileExtension = image.name.split('.').pop();
        let isFileExist = [...images].some(x => x.name == image.name);
        if (imageExtensions.includes(fileExtension.toUpperCase()) && !isFileExist) {
            dt.items.add(image);
        }
    }

    document.getElementById("uploadImage").files = dt.files;
}