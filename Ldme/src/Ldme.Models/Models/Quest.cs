using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    // only owner of the quest can update it
    public class Quest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartedDate { get; set; } // when user started quest, when Duration is specified StartedDate is CreatedDate
        public DateTime? FinishedDate { get; set; } // when user finished quest
        public DateTime? DeadlineDate { get; set; } // when quest is ending, null if duration is present, can calculate this on DB, or c#
        public int GoldReward { get; set; } // main currency
        public int GoldPenalty { get; set; }
        public int HonorReward { get; set; }
        public int HonorPenalty { get; set; }
        public string QuestType { get; set; } // Daily, OneTime, Repetitive
        public bool Accepted { get; set; }
        public int RequiredRepetitions { get; set; }
        public int MaxRepetitions { get; set; }

        public int QuestCreatorId { get; set; }
        public Player QuestCreator { get; set; }

        public int QuestOwnerId { get; set; }
        public Player QuestOwner { get; set; }
    }

    public static class QuestType
    {
        public static string Regular = "regular";
        public static string Daily = "daily";
        public static string Complex = "complex";
    }
}
