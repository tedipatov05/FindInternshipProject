document.getElementById('add-ability').addEventListener("click", function () {
    changeVisibility();
});

document.getElementById('btn-add').addEventListener('click', function () {

    const lanIcons = {
        "c++": "devicon-cplusplus-plain colored",
        "docker": "devicon-docker-plain colored",
        "apache": "devicon-apache-plain colored",
        "angular": "devicon-angularjs-plain colored",
        "vue": "devicon-vuejs-plain colored",
        "react": "devicon-react-original colored",
        "azure": "devicon-azure-plain colored",
        "arduino": "devicon-arduino-plain colored",
        "babel": "devicon-babel-plain colored",
        "cakephp": "devicon-cakephp-plain colored",
        "cofeescript": "devicon-coffeescript-original colored",
        "css": "devicon-css3-plain colored",
        "html": "devicon-html5-plain colored",
        "dart": "devicon-dart-plain colored",
        "debian": "devicon-debian-plain colored",
        "express": "devicon-express-original colored",
        "flask": "devicon-flask-original colored",
        "github": "devicon-github-original colored",
        "go": "devicon-go-original-wordmark colored",
        "haskell": "devicon-haskell-plain colored",
        "handlebars": "devicon-handlebars-plain colored",
        "java": "devicon-java-plain colored",
        "jquery": "devicon-jquery-plain colored",
        "mongodb": "devicon-mongodb-plain colored",
        "mysql": "devicon-mysql-plain colored",
        "nextjs": "devicon-nextjs-original colored",
        "oracle": "devicon-oracle-original colored",
        "rust": "devicon-rust-plain colored",
        "typescript": "devicon-typescript-plain colored",
        "unreal engine": "devicon-unrealengine-original colored"
    }

    let ability = document.getElementById('ability-text').value;
    let abilityConcated = ability.split().join('').toLowerCase();

    if (ability == '') {
        toastr.error(`Новото умение не може да е празно`)
    }
    else if (lanIcons[abilityConcated] == null) {
        toastr.error(`Новото умение не съществува`)
    }
    else {

        let t = $("input[name='__RequestVerificationToken']").val();

        $.ajax({
            type: 'POST',
            url: '/Ability/Add',
            data: {
                'ability': ability
            },
            dataType: 'json',
            headers: {
                "RequestVerificationToken": t
            },
            success: function (data) {
                if (data.ability != null || data.ability != undefined) {
                    let div = document.createElement('div');
                    div.classList.add('row');
                    div.innerHTML = `
                                    <p class="mb-10" style="margin-top:10px;">
                                        <i class="${lanIcons[abilityConcated]}"></i>
                                        <span class="heading" style="text-shadow: none">${ability}</span>
                                    </p>`;

                    document.getElementById('abilities-container').appendChild(div);
                }

            },
            error: function (err) {
                console.error(err);
            }

        })


        changeVisibilityNormal();

    }



});

function changeVisibility() {
    document.getElementById('form-add').style.display = 'flex';
    document.getElementById('add-ability').style.display = 'none';
}

function changeVisibilityNormal() {
    document.getElementById('form-add').style.display = 'none';
    document.getElementById('add-ability').style.display = 'flex';
}


