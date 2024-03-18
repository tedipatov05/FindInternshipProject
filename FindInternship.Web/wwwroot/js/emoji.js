

$(document).ready(function () {
    // Map plaintext smilies to Unicode equivalents
    var emoji = {
        ':)': '🙂',
        ':(': '🙁',
    },

        // Function to escape regular expressions
        reEscape = function (s) {
            return s.replace(/[\-\[\]\/\{\}\(\)\*\+\?\.\\\^\$\|]/g, "\\$&");
        };

    $('#messageInput').keyup(function () {
        var text = $(this).val();

        // See if any of our emoji exist in the text and replace with Unicode
        $.each(emoji, function (plaintext, unicode) {
            text = text.replace(new RegExp(reEscape(plaintext), 'g'), unicode);
        });

        // Replace text with new values
        $(this).val(text);
    });
    
});

let emojis = Array.from(document.getElementById('emojis-container').children);

let emojiInput = document.getElementById('messageInput');

emojis.forEach((el) => {
    el.addEventListener('click', function () {
        let prevVale = $('#messageInput').val();
        $('#messageInput').val(prevVale + el.firstChild.textContent);
    })
})


let emojiToggler = document.getElementById('emoji');
let emojisDiv = document.getElementById('emojis-main');
emojiToggler.addEventListener('click', function () {

    if (emojisDiv.style.display == 'none') {
        emojisDiv.style.display = 'block';
    }
    else {
        emojisDiv.style.display = 'none';
    }

});

