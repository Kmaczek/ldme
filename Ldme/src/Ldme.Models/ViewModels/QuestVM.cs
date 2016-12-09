using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Models.Models;
using Ldme.Common.Extensions;

namespace Ldme.Models.ViewModels
{
    public class QuestVM
    {
        public QuestVM(Quest quest, float repetitionBonus)
        {
            this.Id = quest.Id;
            this.Name = quest.Name;
            this.Description = quest.Description;
            this.CreatedDate = quest.CreatedDate.ToDateTimeString();
            this.FinishedDate = quest.FinishedDate?.ToString("s", CultureInfo.InvariantCulture);
            this.DeadlineDate = quest.DeadlineDate?.ToString("s", CultureInfo.InvariantCulture);
            this.GoldReward = quest.GoldReward;
            this.GoldPenalty = quest.GoldPenalty;
            this.HonorReward = quest.HonorReward;
            this.HonorPenalty = quest.HonorPenalty;
            this.QuestState = quest.QuestState;
            this.QuestType = quest.QuestType;
            this.Accepted = quest.Accepted;
            this.RequiredRepetitions = quest.RequiredRepetitions;
            this.MaxRepetitions = quest.MaxRepetitions;
            this.RepetitionBonusType = quest.RepetitionBonusType;
            this.RepetitionsForMaxBonus = quest.RepetitionsForMaxBonus;
            this.RepetitionBonusMultiplier = quest.RepetitionBonusMultiplier;
            this.QuestCreatorId = quest.QuestCreatorId;
            this.QuestOwnerId = quest.QuestOwnerId;
            this.RepetitionBonus = quest.RepetitionBonusMultiplier * repetitionBonus;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string FinishedDate { get; set; } 
        public string DeadlineDate { get; set; } 
        public float GoldReward { get; set; } 
        public float GoldPenalty { get; set; }
        public float HonorReward { get; set; }
        public float HonorPenalty { get; set; }
        public string QuestState { get; set; }
        public string QuestType { get; set; }
        public bool Accepted { get; set; }
        public int RequiredRepetitions { get; set; }
        public int MaxRepetitions { get; set; }
        public string RepetitionBonusType { get; set; }
        public int RepetitionsForMaxBonus { get; set; }
        public float RepetitionBonusMultiplier { get; set; }
        public int QuestCreatorId { get; set; }
        public int QuestOwnerId { get; set; }
        public float RepetitionBonus { get; set; }
    }
}
