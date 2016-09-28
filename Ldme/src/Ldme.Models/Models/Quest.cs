using System;

namespace Ldme.Models.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public double RewardedGold { get; set; }
        public double PenaltyGold { get; set; }
        public double RewardedHonor { get; set; } // main currency
        public double PenaltyHonor { get; set; }
        public string QuestType { get; set; }

        public Player QuestGiver { get; set; }
    }
}
