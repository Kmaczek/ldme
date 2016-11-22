using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    // Daily quests can have repetitions, gold and honor gain, to at least have slight history
    public class RepTag
    {
        public int Id { get; set; }

        public int TagingPlayerId { get; set; }
        [ForeignKey("TagingPlayerId")]
        public Player TagingPlayer { get; set; }

        public int ReferencedQuestId { get; set; }
        [ForeignKey("ReferencedQuestId")]
        public Quest ReferencedQuest { get; set; }

        public int GoldGain { get; set; }

        public int HonorGain { get; set; }

        public DateTime CompletionDate { get; set; }
    }
}
