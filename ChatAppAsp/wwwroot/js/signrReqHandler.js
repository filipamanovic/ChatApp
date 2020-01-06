var connection = new signalR.HubConnectionBuilder()
    .withUrl('/Home/Index')
    .build();

connection.on('receiveMessage', addMessageToChat);

connection.start()
    .catch(error => {
        console.log(error.message);
    });

function sendMessageToHub(message) {
    connection.invoke('SendMessage', message);
};


connection.on('receiveProfile', updateProfile);


