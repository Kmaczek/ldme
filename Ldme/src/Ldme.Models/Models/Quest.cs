using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    public class Quest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public double RewardedGold { get; set; } // main currency
        public double PenaltyGold { get; set; }
        public double RewardedHonor { get; set; }
        public double PenaltyHonor { get; set; }
        public string QuestType { get; set; } // Daily, OneTime
        public bool Accepted { get; set; }

        public int QuestGiverId { get; set; }
        public Player QuestGiver { get; set; }

        public int QuestRevceiverId { get; set; }
        public Player QuestRevceiver { get; set; }
    }
}
