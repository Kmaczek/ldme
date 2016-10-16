function QuestModel() {
    this.fromPlayer = 0;
    this.toPlayer = 0;
    this.name = '';
    this.description = '';
    this.goldReward = 0;
    this.goldPenalty = 0;
    this.honorReward = 0;
    this.honorPenalty = 0;
    this.daily = false;
    this.startTime = new Date();
    this.endTime = new Date();
}