$('#fileButton i').click(function () {
    $('#uploadFile').trigger('click');
});

$('#uploadFile').on('change', function () {
    const fileExtensions = ["TXT", "TEXT", "DOCX", "DOC", "PDF", "PPT", "XLS", "XLSX", "ZIP", "RAR"];
    let files = document.getElementById("upploadFile").files;
    const dtFiles = new DataTransfer();
    const dtImages = new DataTransfer();

    for (let file in files) {
        let fileExtension = file.name.split('.').pop();
        if (fileExtensions.includes(fileExtension.toUpper())) {
            // continue logic
        }
    }
});