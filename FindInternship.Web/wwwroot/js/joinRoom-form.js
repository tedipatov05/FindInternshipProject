$(document).ready(function ($) {

    document.getElementById('start-date').addEventListener('focus', function () {
        this.type = 'datetime-local'
        document.getElementById('label-start').style = 'transform: translateY(-50%) scale(0.8);background-color: #212121; padding: 0 0.2em; color: #2196f3;'
    })

    document.getElementById('end-date').addEventListener('focus', function () {
        this.type = 'datetime-local'
        document.getElementById('label-end').style = 'transform: translateY(-50%) scale(0.8);background-color: #212121; padding: 0 0.2em; color: #2196f3;'
    })

    document.getElementById('select-class').value = '';
    document.getElementById('select-class').addEventListener('input', function () {
        document.getElementById('label-class').style = 'transform: translateY(-50%) scale(0.8);background-color: #212121; padding: 0 0.2em; color: #2196f3;'
    });

    document.getElementById('select-lector').value = '';
    document.getElementById('select-lector').addEventListener('input', function () {
        document.getElementById('label-lector').style = 'transform: translateY(-50%) scale(0.8);background-color: #212121; padding: 0 0.2em; color: #2196f3;'

    });



});