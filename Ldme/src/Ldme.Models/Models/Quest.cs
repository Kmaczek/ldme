using System;
using System.Collections.Generic;
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
        public DateTime? FinishedDate { get; set; } // when user finished quest
        public DateTime? DeadlineDate { get; set; } // when quest is ending, null if duration is present, can calculate this on DB, or c#
        public float GoldReward { get; set; } // main currency
        public float GoldPenalty { get; set; }
        public float HonorReward { get; set; }
        public float HonorPenalty { get; set; }

        /// <summary>
        /// InProgress - 
        /// Completed - 
        /// Abandoned - player accepted then resigned from quest, 
        /// Closed - quest owner closed quest,
        /// OnHold - no Penalties are calculated,
        /// </summary>
        public string QuestState { get; set; }

        /// <summary>
        /// Daily, OneTime, Repetitive
        /// </summary>
        public string QuestType { get; set; }

        /// <summary>
        /// Quests created by one player, and adigned to himself are automatically accepted
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// Minimal repetitions to get reward
        /// </summary>
        public int RequiredRepetitions { get; set; }

        /// <summary>
        /// Maximum repetitions for which quest will yield reward
        /// </summary>
        public int MaxRepetitions { get; set; }

        /// <summary>
        /// When repetition bonus will be calculated
        /// Never
        /// Daily
        /// Weekly
        /// Monthly
        /// </summary>
        public string RepetitionBonusType { get; set; }

        /// <summary>
        /// How many times Quest need to be done for full bonus to persist
        /// Ex. 5 times: 1st - 20% of bonus, 2nd - 40%, 3rd - 60% etc.
        /// </summary>
        public int RepetitionsForMaxBonus { get; set; }

        /// <summary>
        /// Reward will be multiplied by BonusMultiplied
        /// Default 0
        /// Reward + Reward * (Bomus * (timesExecuted/timesNeededForFullBonus)) 
        /// </summary>
        public float RepetitionBonusMultiplier { get; set; }

        public int QuestCreatorId { get; set; }
        public Player QuestCreator { get; set; }

        public int QuestOwnerId { get; set; }
        public Player QuestOwner { get; set; }

        [InverseProperty("ReferencedQuest")]
        public virtual ICollection<Repetition> RepetitionTags { get; set; } = new List<Repetition>();
    }

    public static class QuestType
    {
        public static string Regular = "regular";
        public static string Daily = "daily";
        public static string Complex = "complex";
    }

    public static class QuestState
    {
        public static string InProgress = "In Progress";
        public static string Completed = "Completed";
        public static string Abandoned = "Abandoned";
        public static string Closed = "Closed";
        public static string OnHold = "On Hold";
    }

    public static class RepetitionType
    {
        public static string Never = "Never";
        public static string Daily = "Daily";
        public static string Weekly = "Weekly";
        public static string Monthly = "Monthly";
    }
}
