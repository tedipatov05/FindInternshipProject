
document.getElementById('addMeeting').addEventListener('click', () => {
    Array.from(document.getElementsByClassName('text-danger')).forEach(e => e.style.display = 'none')
})


function create(e) {
    e.preventDefault();
    let formData = new FormData(e.target);
    let { className, title, start, end, address } = Object.fromEntries(formData);

    let dataArr = [className, title, start, end, address]

    let validationSpans = document.getElementsByClassName('text-danger');

    dataArr.forEach((element, index) => {
        if (element == '') {
            validationSpans[index].style.display = 'block';
        }
        else {
            validationSpans[index].style.display = 'none';
        }
    })

    if (start >= end) {

    }
   
    console.log(className);
   
}

document.getElementById('addEvent').addEventListener('submit', create);


