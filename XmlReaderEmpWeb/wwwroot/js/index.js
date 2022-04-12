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