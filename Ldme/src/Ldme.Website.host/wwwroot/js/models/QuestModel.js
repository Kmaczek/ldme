function QuestModel() {
    var self = this;

    this.id = 0;
    this.fromPlayer = 0;
    this.toPlayer = 0;
    this.name = '';
    this.description = '';
    this.goldReward = 0;
    this.goldPenalty = 0;
    this.honorReward = 0;
    this.honorPenalty = 0;
    this.questType = '';
    this.questState = '';
    this.createdDate = null;
    this.deadlineDate = null;
    this.finishedDate = null;

    this.isFinished = function() {
        return self.finishedDate !== null && self.finishedDate !== undefined;
    }
}

QuestModel.FromResponse = function (response) {
    return QuestModel.FromData(response.id, response.questCreatorId, response.questOwnerId, response.name, response.description, 
        response.goldReward, response.goldReward, response.honorReward, response.honorPenalty, response.questType,
        response.questState, response.createdDate, response.deadlineDate, response.finishedDate);
}

QuestModel.FromData = function (id, fromPlayer, toPlayer, name, description, goldReward, goldPenalty,
    honorReward, honorPenalty, questType, questState, createdDate, deadlineDate, finishedDate) {
    
    var qModel = new QuestModel();

    qModel.id = id;
    qModel.fromPlayer = fromPlayer || 0;
    qModel.toPlayer = toPlayer || 0;
    qModel.name = name || 'Unknown';
    qModel.description = description || '';
    qModel.goldReward = goldReward || 0;
    qModel.goldPenalty = goldPenalty || 0;
    qModel.honorReward = honorReward || 0;
    qModel.honorPenalty = honorPenalty || 0;
    qModel.questType = questType || QuestType.Regular;
    qModel.questState = questState || 'None';
    qModel.createdDate = createdDate || null;
    qModel.deadlineDate = deadlineDate || null;
    qModel.finishedDate = finishedDate || null;

    return qModel;
}