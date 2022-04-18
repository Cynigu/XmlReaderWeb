
async function postRequestJSON(requestClass, url) {
    let response = await fetch(url,
        {
            method: 'POST',
            headers: { "Accept": "application/json" , 'Content-Type': 'application/json' },
            body: JSON.stringify(requestClass)
        })
        .then(response => response.json())
        .catch(
            (e) => {
            console.log('Error: ' + e.message);
            console.log(e.response)}
        );
    return response.json();
}