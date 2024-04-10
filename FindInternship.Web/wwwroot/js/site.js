$(document).ready(function () {

    $('.counter').each(function () {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text()
        }, {
            duration: 4000,
            easing: 'swing',
            step: function (now) {
                $(this).text(Math.ceil(now));
            }
        });
    });

    document.getElementById('schedule-nav').addEventListener('click', function () {

        let subNav = document.getElementsByClassName('section-dropdown-2')[0];
        if (subNav.style.display == 'none') {
            subNav.style.display = 'block';

        } else {
            subNav.style.display = 'none';
        }
    });

});




