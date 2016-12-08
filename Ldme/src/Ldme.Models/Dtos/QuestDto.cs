using System;
using System.ComponentModel.DataAnnotations;

namespace Ldme.Models.Dtos
{
    public class QuestDto
    {
        [Required]
        public int FromPlayer { get; set; }

        [Required]
        public int ToPlayer { get; set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 100)]
        public int HonorReward { get; set; }

        [Range(0, 100)]
        public int HonorPenalty { get; set; }

        [Range(0, 100)]
        [Required]
        public int GoldReward { get; set; }

        [Range(0, 100)]
        public int GoldPenalty { get; set; }

        public string QuestType { get; set; }

        public string QuestState { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

    }
}
