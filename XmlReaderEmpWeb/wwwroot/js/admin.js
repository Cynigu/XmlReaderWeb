async function onloadFunction() {
    let menuItemUsers = document.getElementById('menu__item-users');
    let menuItemHome = document.getElementById('menu__item-home');
    let menuItemLogout = document.getElementById('menu__item-logout');
    let searchStr = document.getElementById('login');
    let buttonFindUsers = document.getElementById('button__find-user');
    let buttonResreshTable = document.getElementById('button__refresh-table');

    menuItemHome.addEventListener('click', event => openTab(event, "home"));
    menuItemUsers.addEventListener('click', event => openTab(event, "users"));
    menuItemUsers.addEventListener('click', async () => findUsersAsync(searchStr.value));
    menuItemLogout.addEventListener('click', () => _logout());

    buttonFindUsers.addEventListener('click', async () => findUsersAsync(searchStr.value));
    buttonResreshTable.addEventListener('click', async () => findUsersAsync(searchStr.value));
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

async function findUsersAsync(searchStr) {
    var url = '/api/UserProfile/GetUsersInfosByFilter';
    var searchStr = searchStr;
    fetch(url,
        {
            method: 'POST',
            headers: { "Accept": "application/json", 'Content-Type': 'application/json' },
            body: JSON.stringify({ searchStr: searchStr })
        })
        .then(response => response.json()
            .then(data => _displayUsersInfo(data))
        )
        .catch(ex =>
            window.alert(ex.message)
        );
}

function _displayUsersInfo(data) {
    var thead =  document.getElementById('table-users-head');
    while (thead.rows.length > 0) thead.rows[0].remove();

    // Создаем основную строку
    let mainRow = document.createElement('tr');
    thead.appendChild(mainRow);

    // Заполняем заголовки
    let th1 = document.createElement('th');
    let th2 = document.createElement('th');
    let th3 = document.createElement('th');
    let th4 = document.createElement('th');
    let th5 = document.createElement('th');
    let th6 = document.createElement('th');
    let th7 = document.createElement('th');
    let th8 = document.createElement('th');
    th1.innerHTML = "Логин";
    th2.innerHTML = "Пароль";
    th3.innerHTML = "Имя";
    th4.innerHTML = "Мейл";
    th5.innerHTML = "Вк";
    th6.innerHTML = "Номер телефона";
    th7.innerHTML = "Роль";
    th8.innerHTML = ""; // Добавить кнопку "удалить"
    mainRow.appendChild(th1);
    mainRow.appendChild(th2);
    mainRow.appendChild(th3);
    mainRow.appendChild(th4);
    mainRow.appendChild(th5);
    mainRow.appendChild(th6);
    mainRow.appendChild(th7);
    mainRow.appendChild(th8);

    var tbody = document.getElementById('table-users-body');
    while (tbody.rows.length > 0) tbody.rows[0].remove();

    data.forEach(element => {
        // Создаем основную строку
        let row = document.createElement('tr');
        tbody.appendChild(row);

        // кнопка 
        let buttonDelete = document.createElement('button');
        buttonDelete.addEventListener('click', async () => deleteAccountByLogin(element.login));
        buttonDelete.innerHTML = "Удалить";
        
        let td1 = document.createElement('td');
        let td2 = document.createElement('td');
        let td3 = document.createElement('td');
        let td4 = document.createElement('td');
        let td5 = document.createElement('td');
        let td6 = document.createElement('td');
        let td7 = document.createElement('td');
        let td8 = document.createElement('td');
        td1.innerHTML = element.login;
        td2.innerHTML = element.password;
        td3.innerHTML = element.name;
        td4.innerHTML = element.email;
        td5.innerHTML = element.vk;
        td6.innerHTML = element.numberPhone;
        td7.innerHTML = element.role;
        td8.appendChild(buttonDelete);

        row.appendChild(td1);
        row.appendChild(td2);
        row.appendChild(td3);
        row.appendChild(td4);
        row.appendChild(td5);
        row.appendChild(td6);
        row.appendChild(td7);
        row.appendChild(td8);
    });
}

async function deleteAccountByLogin(login){
    var url = '/api/UserProfile/DeleteUserInfosByLogin';
    fetch(url,
        {
            method: 'POST',
            headers: { "Accept": "application/json", 'Content-Type': 'application/json' },
            body: JSON.stringify({ login: login })
        })
        .then(response => {if(!response.ok) throw new Error("Не удалось удалить")})
        .catch( 
            (ex) =>{
                window.alert(ex.message)
            }
        );
    await findUsersAsync("");
}

function _logout() {
    var url = '/api/Account/Logout';
    fetch(url,
        {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },
        })
        .then(response => response.text())
        .then(data => {
            if (data == "logout") {
                document.location.href = "../index.html";
            }
        })
        .catch(
            (e) => {
                window.alert('Error: ' + e.message);
            }
        );
}