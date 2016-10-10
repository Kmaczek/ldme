using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    public class Activity
    { // kind of subquests, one quest can have many activities, and quest is completed when all activities are done
        public int Id { get; set; }

        public int ActivityCreatorId { get; set; }
        [ForeignKey("ActivityCreatorId")]
        public Player ActivityCreator { get; set; }

        public int ReferencedQuestId { get; set; }
        [ForeignKey("ReferencedQuestId")]
        public Quest ReferencedQuest { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}
