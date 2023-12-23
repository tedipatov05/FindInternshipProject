


function edit(e) {
    e.preventDefault();

    var data = new FormData(e.target);

    let { title, start, end, address } = Object.fromEntries(data);

    let dataArr = [title, start, end, address]

    let validationSpans = document.getElementsByClassName('text-danger');

    dataArr.forEach((element, index) => {
        if (element == '') {
            validationSpans[index].style.display = 'block';
        }
        else {
            validationSpans[index].style.display = 'none';
        }
    });

    if (!Array.from(validationSpans).some(v => v.style.display == 'block')) {

        let url = new URL(window.location);
        let path = url.pathname;


        let t = $("input[name='__RequestVerificationToken']").val();
        $.ajax({
            type: "POST", 
            url: path,
            data: {
                'title': title, 
                'start': start, 
                'end': end, 
                'address': address
            },
            dataType: 'json', 
            headers: {
                "RequestVerificationToken": t
            },
            success: async function (data) {

                console.log(data.id)


            },
            error: function (err) {
                console.error(error)
            }

        })

    }
}

document.getElementById('editEvent').addEventListener("submit", edit);