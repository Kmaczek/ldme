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

        [MinLength(4)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 100)]
        public decimal HonorReward { get; set; }

        [Range(0, 100)]
        public decimal HonorPenalty { get; set; }

        [Range(0, 100)]
        [Required]
        public decimal GoldReward { get; set; }

        [Range(0, 100)]
        public decimal GoldPenalty { get; set; }

        public bool Daily { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

    }
}
