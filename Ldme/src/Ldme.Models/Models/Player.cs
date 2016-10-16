using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Gold { get; set; }
        public double Honor { get; set; }

        [InverseProperty("QuestCreator")]
        public virtual ICollection<Quest> QuestsCreated { get; set; } = new List<Quest>();
        [InverseProperty("QuestOwner")]
        public virtual ICollection<Quest> QuestsOwned { get; set; } = new List<Quest>();
    }
}
