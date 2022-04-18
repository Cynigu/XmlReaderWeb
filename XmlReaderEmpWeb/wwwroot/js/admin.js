async function onloadFunction(){
    let menuItemUsers =  document.getElementById('menu__item-users');
    let menuItemHome =  document.getElementById('menu__item-home');
    let menuItemLogout =  document.getElementById('menu__item-logout');

    menuItemHome.addEventListener('click', event => openTab(event, "home") );
    menuItemUsers.addEventListener('click', event => openTab(event, "users") );
    menuItemLogout.addEventListener('click', () => logout() );

    menuItemUsers.addEventListener('click', await findUsersAsync());
}


function openTab(evt, tabName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("section");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("menu__item");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(tabName).style.display = "flex";
    evt.currentTarget.className += " active";
}

async function findUsersAsync(){
    var url = '/api/UserProfile/GetUsersInfosByFilter';
    var searchStr = document.getElementById('login').value;
    let searchClass = {
        searchStr: searchStr
    }

    let response = postRequestJsonAsync(searchClass, url);

    // Вывести в таблицу
}

function _displayUsersInfo(bet, countObject){
    var tbodyAboutFolder = document.getElementById('table-users-body');
    while( tbodyAboutFolder.rows.length > 0) tbodyAboutFolder.rows[0].remove();

    let tr2 = document.createElement('tr');
    tbodyAboutFolder.appendChild(tr2);
    let tr3 = document.createElement('tr');
    tbodyAboutFolder.appendChild(tr3);
    let tr4 = document.createElement('tr');
    tbodyAboutFolder.appendChild(tr4);
    let tr5 = document.createElement('tr');
    tbodyAboutFolder.appendChild(tr5);

    let th2 = document.createElement('th');
    th2.innerHTML = "Ставка";
    tr2.appendChild(th2);
    let th3 = document.createElement('th');
    th3.innerHTML = "Кол-во объектов";
    tr3.appendChild(th3);
    let th4 = document.createElement('th');
    th4.innerHTML = "Зарплата";
    tr4.appendChild(th4);

    let td2 = document.createElement('td');
    td2.innerHTML = bet;
    tr2.appendChild(td2);
    let td3 = document.createElement('td');
    td3.innerHTML = countObject;
    tr3.appendChild(td3);
    let td4 = document.createElement('td');
    td4.innerHTML = countObject * bet;
    tr4.appendChild(td4);
}
