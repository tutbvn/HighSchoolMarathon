const connection = new signalR.HubConnectionBuilder()
    .withUrl("/marathonEventHub")
    .build();

connection.on("ReceiveNotification", function (message) {
    $("#agentUpdate").text("Updating: " + message);

});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
