
document.getElementById('addMeeting').addEventListener('click', () => {
    Array.from(document.getElementsByClassName('text-danger')).forEach(e => e.style.display = 'none')
})


function create(e) {

    e.preventDefault();
    let formData = new FormData(e.target);
    let { classId, title, start, end, address } = Object.fromEntries(formData);

    let dataArr = [classId, title, start, end, address]

    let validationSpans = document.getElementsByClassName('text-danger');

    dataArr.forEach((element, index) => {
        if (element == '') {
            validationSpans[index].style.display = 'block';
        }
        else {
            validationSpans[index].style.display = 'none';
        }
    })


    let t = $("input[name='__RequestVerificationToken']").val();

    $.ajax({
        type: "POST",
        url: `/Meeting/Create`,
        data: {
            'classId': classId, 
            'title': title,
            'start': start, 
            'end': end, 
            'address': address
        },
        dataType: "json",
        headers: {
            "RequestVerificationToken": t

        },
        success: function (data) {
            if (data) {

                console.log(data.receiverId);
                window.location = `https://localhost:7256/Meeting/All`

            }

            console.log('Request added successfully');
        },
        error: function (error) {
            toastr.error("\u041D\u0435\u043F\u0440\u0430\u0432\u0438\u043B\u0435\u043D \u043A\u0440\u0430\u0435\u043D \u0447\u0430\u0441".normalize());
        }
    });




}

document.getElementById('addEvent').addEventListener('submit', create);


