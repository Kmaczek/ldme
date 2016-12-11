function RewardModel() {
    var self = this;

    this.id = 0;
    this.description = '';
    this.goldPrice = 0;
    this.honorPrice = 0;
    this.playerId = 0;
}

RewardModel.FromResponse = function(response) {
    return RewardModel.FromData(response.id, response.description, response.goldPrice, response.honorPrice, response.playerId);
}

RewardModel.FromData = function (id, description, goldPrice, honorPrice, playerId) {

    var reward = new RewardModel();

    reward.id = id || 0;
    reward.description = description || '';
    reward.goldPrice = goldPrice || 0;
    reward.honorPrice = honorPrice || 0;
    reward.playerId = playerId || 0;

    return reward;
}