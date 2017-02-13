CREATE TABLE [dbo].[Quest]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    [DeadlineDate] DATETIME2 NULL, 
    [GoldReward] FLOAT NULL, 
    [GoldPenalty] FLOAT NULL, 
    [HonorReward] FLOAT NULL, 
    [HonorPenalty] FLOAT NULL, 
    [QuestType] VARCHAR(MAX) NULL, 
    [RequiredRepetitions] INT NULL, 
    [MaxRepetitions] INT NULL, 
    [RepetitionOccurence] VARCHAR(50) NULL,
	[RepetitionForMaxBonus] INT NULL,
    [RepetitionBonusMultiplier] FLOAT NULL, 
    [QuestCreator] INT NOT NULL,
	CONSTRAINT fk_PlayerQuests FOREIGN KEY (QuestCreator) REFERENCES Player(Id)
)
