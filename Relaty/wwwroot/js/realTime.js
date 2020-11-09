let connection = new signalR.HubConnectionBuilder().withUrl("/appHub").build();
connection.start();

let isClicked = false;
$(".submit").on("click", function () {
    isClicked = true;
    console.log(isClicked);
})

connection.on("Refresh", function () {
    if (isClicked == false) {
        window.location.reload();
    }
});
