function QuestModel() {
    var self = this;

    this.id = 0;
    this.name = '';
    this.description = '';
    this.createdDate = null;
    this.finishedDate = null;
    this.deadlineDate = null;
    this.goldReward = 0;
    this.goldPenalty = 0;
    this.honorReward = 0;
    this.honorPenalty = 0;
    this.questState = '';
    this.questType = '';
    this.fromPlayer = 0;
    this.toPlayer = 0;
    this.requiredRepetitions = 0;
    this.maxRepetitions = 0;
    this.repetitionsForMaxBonus = 0;
    this.repetitionBonusMultiplier = 0;
    this.repetitionBonus = 0;

    this.isFinished = function() {
        return self.finishedDate !== null && self.finishedDate !== undefined;
    }

    this.elapsedDays = function () {
        var difference = moment().diff(moment(self.createdDate));
        
        return Math.ceil(moment.duration(difference).asDays());
    }

    this.totalDays = function() {
        var difference = moment(self.deadlineDate).diff(moment(self.createdDate));

        return Math.ceil(moment.duration(difference).asDays());
    }
}

QuestModel.FromResponse = function (response) {
    return QuestModel.FromData(response.id, response.questCreatorId, response.questOwnerId, response.name, response.description, 
        response.goldReward, response.goldReward, response.honorReward, response.honorPenalty, response.questType,
        response.questState, response.createdDate, response.deadlineDate, response.finishedDate, response.requiredRepetitions,
        response.maxRepetitions, response.repetitionsForMaxBonus, response.repetitionBonusMultiplier, response.repetitionBonus);
}

QuestModel.FromData = function (id, fromPlayer, toPlayer, name, description, goldReward, goldPenalty,
    honorReward, honorPenalty, questType, questState, createdDate, deadlineDate, finishedDate, requiredRepetitions,
    maxRepetitions, repetitionsForMaxBonus, repetitionBonusMultiplier, repetitionBonus) {
    
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
    qModel.requiredRepetitions = requiredRepetitions || 0;
    qModel.maxRepetitions = maxRepetitions || 0;
    qModel.repetitionsForMaxBonus = repetitionsForMaxBonus || 0;
    qModel.repetitionBonusMultiplier = repetitionBonusMultiplier || 0;
    qModel.repetitionBonus = repetitionBonus || 0;

    return qModel;
}