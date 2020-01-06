function updateProfile(profile) {
    if ($('#' + profile.userID).length > 0) {
        $('#' + profile.userID).remove();
    }

    let li = document.createElement('li');
    li.id = profile.userID;

    let div = document.createElement('div');
    div.className = 'd-flex bd-highlight';

    let divImg = document.createElement('div');
    divImg.className = 'img_cont';

    let img = document.createElement('img');
    img.className = 'rounded-circle user_img';

    if (profile.imagePath != null) {
        img.src = '/uploads/' + profile.imagePath;
    } else {
        img.src = 'https://static.turbosquid.com/Preview/001292/481/WV/_D.jpg';
    }

    let span = document.createElement('span');

    if (profile.isLogged) {
        span.className = 'online_icon';
    } else {
        span.className = 'online_icon offline';
    }

    let divUser = document.createElement('div');
    divUser.className = 'user_info';

    let spanUser = document.createElement('span');
    spanUser.innerHTML = profile.username;

    divImg.appendChild(img);
    divImg.appendChild(span);
    divUser.appendChild(spanUser);
    div.appendChild(divImg);
    div.appendChild(divUser);
    li.appendChild(div);
    if (profile.isLogged) {
        document.getElementById('contacts').prepend(li);
    } else {
        document.getElementById('contacts').append(li);
    }
    
}

function addMessageToChat() {

}