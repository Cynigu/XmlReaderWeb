
function computeObject(){
    var files = document.getElementById('files').files;
    var bet = document.getElementById('bet').value;

    var url = '/api/ComputeObject/GetCountObject';
    var data = new FormData();
    for(i=0; i< files.length; i++){
        data.append('files', files[i], files[i].name);
    }
    fetch(url,
        {
            method: 'POST',
            body: data
        })
        .then(
            response => response.json()
            .then(countObject => _displayAboutFolder(bet, countObject))
        )
        .catch(
            (e) => {
            console.log('Error: ' + e.message);
            console.log(e.response)}
        );
}

function _displayAboutFolder(bet, countObject){
    var tbodyAboutFolder = document.getElementById('table-about-folder-body');
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

/* function computeObject1() {
    var url = '/api/ComputeObject/GetFolderInfoXml';
    var file = document.getElementById('file');
    var bet = document.getElementById('bet');
    fetch(url,
        {
            method: 'POST',
            headers: { "Accept": "application/json" , 'Content-Type': 'application/json' },
            body: JSON.stringify({ folderPath: file.value, bet: bet.value, countObject: 0, salary:0, countXmlFile: 0})
        })
        .then(
            response => response.json()
            //.then(fileinfo => _displayAboutFolder(fileinfo))
        )
        .catch(
            (e) => {
            console.log('Error: ' + e.message);
            console.log(e.response)}
        );
} */