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
        public DateTime? StartedDate { get; set; } // when user started quest, when Duration is specified StartedDate is CreatedDate
        public DateTime? FinishedDate { get; set; } // when user finished quest
        public DateTime? DeadlineDate { get; set; } // when quest is ending, null if duration is, can calculate this on DB, or c#
        public double GoldReward { get; set; } // main currency
        public double GoldPenalty { get; set; }
        public double HonorReward { get; set; }
        public double HonorPenalty { get; set; }
        public string QuestType { get; set; } // Daily, OneTime
        public bool Accepted { get; set; }

        public int QuestCreatorId { get; set; }
        public Player QuestCreator { get; set; }

        public int QuestOwnerId { get; set; }
        public Player QuestOwner { get; set; }
    }
}
