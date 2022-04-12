function openAuthForm(evt, arg) {

    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("auth-area");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(arg).style.display = "flex";
}

function input(loginId, passId){
    var login = document.getElementById(loginId).value;
    var pass = document.getElementById(passId).value;
    if(login == "user" && pass == "user"){
        window.alert("Вход пользователя");
    }
}

function Register(nameId, numberPhoneId, vkId, emailId, passId, passTwoId, loginId){
    var login = document.getElementById(loginId).value;
    var pass = document.getElementById(passId).value;
    var passTwo = document.getElementById(passTwoId).value;
    var name = document.getElementById(nameId).value;
    var phone = document.getElementById(numberPhoneId).value;
    var vk = document.getElementById(vkId).value;
    var email = document.getElementById(emailId).value;

    var url = '/api/Account/Register';
    fetch(url,
        {
            method: 'POST',
            headers: {'Content-Type': 'application/json' },
            body: JSON.stringify({ login: login, password: pass, confirmPassword: passTwo, 
                rememberMe: false, name: name, vk: vk, numberPhone: phone, email: email})
        })
        .then(response => response.text())
        .then(data => {
            if (data == "user") {
                document.location.href = "html/user.html";
            }
            else if (data == "admin") {
                document.location.href = "html/admin.html";
            }
            else {
                window.alert(data);
            }
        })
        .catch(
            (e) => {
            window.alert('Error: ' + e.message);
            }
        );
}

function login(loginId, passId){
    var login = document.getElementById(loginId).value;
    var pass = document.getElementById(passId).value;

    var url = '/api/Account/Login';
    fetch(url,
        {
            method: 'POST',
            headers: {'Content-Type': 'application/json' },
            body: JSON.stringify({ login: login, password: pass, rememberMe: false})
        })
        .then(response => response.text())
        .then(data => {
            if (data == "user") {
                document.location.href = "html/user.html";
            }
            else if (data == "admin") {
                document.location.href = "html/admin.html";
            }
            else {
                window.alert(data);
            }
        })
        .catch(
            (e) => {
            window.alert('Error: ' + e.message);
            }
        );
}