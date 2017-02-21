function FriendModel() {
    this.id = 0;
    this.name = '';
}

FriendModel.FromResponse = function (response) {
    return FriendModel.FromData(response.id, response.name);
}

FriendModel.FromData = function (id, name) {

    var friend = new FriendModel();

    friend.id = id || 0;
    friend.name = name || '';

    return friend;
}