

$(".chosen-select").chosen({
    no_results_text: "Oops, nothing found!"
});

document.getElementsByClassName('chosen-choices')[0].style = "height:38px;"
let collection = Array.from(document.getElementsByClassName('search-field'))
collection.forEach(function (f) {
    f.style = "margin: 6px 0px 0px 4px;"
})

Array.from(document.getElementsByClassName('search-choice')).forEach(function (f) { f.style = "margin-top: 7px" })

document.getElementsByClassName('chosen-container').style = "width: 544px;"

document.getElementById('upload_file').addEventListener('input', function () {
    var input = document.getElementById('upload_file')
    var file = input.files[0];
    var type = file.type;

    var output = document.getElementById('preview_img');


    output.src = URL.createObjectURL(event.target.files[0]);
    output.onload = function () {
        URL.revokeObjectURL(output.src) // free memory
    }
});



