function firstPage(action) {
    var url = window.location.href;
    var urlSplit = url.split("/");
    var page = urlSplit[urlSplit.length - 1];

    window.location.href = "/Playtime/" + action + "/0";
}

function prevPage(action) {
    var url = window.location.href;
    var urlSplit = url.split("/");
    var page = urlSplit[urlSplit.length - 1];

    window.location.href = "/Playtime/" + action + "/" + (page - 1);
}

function nextPage(action) {
    var url = window.location.href;
    var urlSplit = url.split("/");
    var page = parseInt(urlSplit[urlSplit.length - 1]);

    window.location.href = "/Playtime/" + action + "/" + (page + 1);
}

function lastPage(action, lastPage) {
    var url = window.location.href;
    var urlSplit = url.split("/");
    var page = urlSplit[urlSplit.length - 1];

    window.location.href = "/Playtime/" + action + "/" + (lastPage - 1);
}