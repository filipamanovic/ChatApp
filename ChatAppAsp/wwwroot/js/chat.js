﻿$(document).ready(function () {
	$('#action_menu_btn').click(function () {
		$('.action_menu').toggle();
	});
});

class Message {
	constructor(Username, Text, CreatedAt) {
		this.Username = Username;
		this.Text = Text;
		this.CreatedAt = CreatedAt;
	}
}

const username = document.getElementById('Username');
const textInput = document.getElementById('messageText');
const createdAt = document.getElementById('createdAt');
const messagesQueue = [];

let chat = document.getElementById('chat');
chat.scrollTop = chat.scrollHeight;

var x = document.getElementById('submitButton');

if (x != null) {
	x.addEventListener('click', () => {
		var currentDate = new Date();
		createdAt.innerHTML = (currentDate.getMonth() + 1) + "/"
			+ currentDate.getDate() + "/"
			+ currentDate.getFullYear() + " "
			+ currentDate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })
	});
}

function clearInputField() {
	messagesQueue.push(textInput.value);
	textInput.value = "";
};

function getDate() {
	var date = new Date(),
		year = date.getFullYear(),
		month = (date.getMonth() + 1).toString(),
		formatedMonth = (month.length === 1) ? ("0" + month) : month,
		day = date.getDate().toString(),
		formatedDay = (day.length === 1) ? ("0" + day) : day,
		hour = date.getHours().toString(),
		formatedHour = (hour.length === 1) ? ("0" + hour) : hour,
		minute = date.getMinutes().toString(),
		formatedMinute = (minute.length === 1) ? ("0" + minute) : minute,
		second = date.getSeconds().toString(),
		formatedSecond = (second.length === 1) ? ("0" + second) : second;
	return year + "-" + formatedMonth + "-" + formatedDay + " " + formatedHour + ':' + formatedMinute + ':' + formatedSecond;
};

function sendMessage() {
	let text = messagesQueue.shift() || "";
	if (text.trim() === "") return;
	let createdAt = getDate();

	let message = new Message(username.value, text, createdAt);
	sendMessageToHub(message);
};

function addMessageToChat(message) {
	let container = document.createElement('div');
	container.className = 'd-flex justify-content-start mb-4';

	let imgContainer = document.createElement('div');
	imgContainer.className = 'img_cont_msg';

	let img = document.createElement('img');
	img.className = 'rounded-circle user_img_msg';
	img.src = 'https://static.turbosquid.com/Preview/001292/481/WV/_D.jpg';

	let usernameContainer = document.createElement('div');
	usernameContainer.className = 'msg_cotainer_username'
	usernameContainer.innerHTML = message.username;

	let msgContainer = document.createElement('div');
	msgContainer.className = 'msg_cotainer';
	msgContainer.innerHTML = message.text;

	let timeContainer = document.createElement('span');
	timeContainer.className = 'msg_time';
	timeContainer.innerHTML = message.createdAt;

	imgContainer.appendChild(img);
	msgContainer.appendChild(timeContainer);
	container.appendChild(imgContainer);
	container.appendChild(usernameContainer);
	container.appendChild(msgContainer);
	document.getElementById('chat').appendChild(container);
	chat.scrollTop = chat.scrollHeight;
};


