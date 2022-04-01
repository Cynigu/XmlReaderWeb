function computeObject(){
    var files = document.getElementsById('files');
    var lable = document.getElementById('count-object');
    for (i = 0; i < files.lenght; i++){
        var request = new XMLHttpRequest();
        request.open('GET', url);
        request.responseType = 'text';
        files[i];
    }
}