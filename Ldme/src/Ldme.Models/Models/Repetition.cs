using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    // Daily quests can have repetitions, gold and honor gain, to at least have slight history
    public class Repetition
    {
        public int Id { get; set; }

        public int TagingPlayerId { get; set; }
        [ForeignKey("TagingPlayerId")]
        public Player TagingPlayer { get; set; }

        public int ReferencedQuestId { get; set; }
        [ForeignKey("ReferencedQuestId")]
        public Quest ReferencedQuest { get; set; }

        public float GoldGain { get; set; }

        public float HonorGain { get; set; }

        public DateTime CompletionDate { get; set; }
    }
}
