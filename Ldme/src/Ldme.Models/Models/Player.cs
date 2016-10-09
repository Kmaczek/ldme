using System.Collections.Generic;

namespace Ldme.Models.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Gold { get; set; }
        public double Honor { get; set; }

        public ICollection<Quest> Quests { get; set; }
    }
}
