function computeObject() {
    var url = '../api/ComputeObjectController/GetFolderInfoXml';
    var file = document.getElementById('file');
    var bet = document.getElementById('bet');
    var label = document.getElementById('count-object');
    fetch(url,
        {
            method: 'POST',
            headers: { "Accept": "application/json" , 'Content-Type': 'application/json' },
            body: JSON.stringify({ folderPath: file.value, bet: bet.value, countObject: 0, salary:0, countXmlFile: 0})
        })
        .then(
            response => response.json()
            .then(fileinfo => console.log("path: ", fileinfo.folderPath, "\nbet: ", fileinfo.bet))
        )
        .catch(
            (e) => {
            console.log('Error: ' + e.message);
            console.log(e.response)}
        );
}
