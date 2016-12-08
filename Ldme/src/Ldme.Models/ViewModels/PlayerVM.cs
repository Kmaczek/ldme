using System.Collections.Generic;
using Ldme.Models.Models;

namespace Ldme.Models.ViewModels
{
    public class PlayerVM
    {
        public PlayerVM(Player player, IEnumerable<QuestVM> questsOwned)
        {
            this.Id = player.Id;
            this.Name = player.Name;
            this.Gold = player.Gold;
            this.Honor = player.Honor;
            this.QuestsOwned = questsOwned;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public float Gold { get; set; }

        public float Honor { get; set; }

        public IEnumerable<QuestVM> QuestsOwned { get; set; }

        public IEnumerable<Reward> RewardsCreated { get; set; } = new List<Reward>();

    }
}
