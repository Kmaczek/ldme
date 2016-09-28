using System;

namespace Ldme.Models.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public Quest ReferencedQuest { get; set; }
        public DateTime ActivityDate { get; set; }
    }
}
