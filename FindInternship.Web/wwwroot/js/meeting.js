
let meetCreator = document.getElementsByClassName("js-event__creator")[0];
let body = document.getElementsByTagName('body')[0];

document.getElementById('addMeeting').addEventListener('click', function () {

    meetCreator.classList.add("isVisible");
    body.classList.add('overlay');
    /*body.classList.add('fancybox-active');*/

});

document.getElementsByClassName('js-event__close')[0].addEventListener('click', function () {
    meetCreator.classList.remove("isVisible");
    body.classList.remove('overlay');



})
