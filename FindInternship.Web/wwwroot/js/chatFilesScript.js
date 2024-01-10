$('#fileButton i').click(function () {
    $('#uploadFile').trigger('click');
});

$('#uploadFile').on('change', function () {

    document.getElementById('appendFiles').innerHTML = '';

    const fileExtensions = ["TXT", "TEXT", "DOCX", "DOC", "PDF", "PPT", "XLS", "XLSX", "ZIP", "RAR"];
    let files = Array.from(document.getElementById("uploadFile").files);
    const dtFiles = new DataTransfer();
    const dtImages = new DataTransfer();

    for (let i = 0; i < files.length; i++) {

        let file = files[i];
        let fileExtension = file.name.split('.').pop();
        if (fileExtensions.includes(fileExtension.toUpperCase())) {
            let sizeInMb = (file.size / (1024 * 1024)).toFixed(2);
            if (sizeInMb > 15) {
                continue;
            }

            dtFiles.items.add(file);
        }
        else {
            let sizeInMb = (file.size / (1024 * 1024)).toFixed(2);
            if (sizeInMb > 15) {
                continue;
            }

            dtImages.items.add(file);
        }
    }

    addFiles(files);

    document.getElementById('uploadFile').files = dtFiles.files;

    if (dtImages.items.length > 0) {
        transferImages(dtImages);
    }

});

function transferFiles(dtFiles) {
    const fileExtensions = ["TXT", "TEXT", "DOCX", "DOC", "PDF", "PPT", "XLS", "XLSX", "ZIP", "RAR"];
    let files = document.getElementById("uploadFile").files;
    const dt = new DataTransfer();

    for (let file in files) {
        let fileExtension = file.name.split('.').pop();
        if (fileExtensions.includes(fileExtension.toUpperCase())) {
            dt.items.add(file);
        }
    }

    for (let file in dtFiles.files) {
        let fileExtension = file.name.split('.').pop()
        let isFileExists = [...files].some(f => f.name == file.name);
        if (fileExtensions.includes(fileExtension.toUpperCase()) && !isFileExists) {
            dt.items.add(file);
        }
    }

    document.getElementById('uploadFile').files = dt.files;

}