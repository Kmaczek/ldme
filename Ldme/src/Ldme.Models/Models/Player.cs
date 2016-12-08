using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Gold { get; set; }

        public float Honor { get; set; }

        [InverseProperty("QuestCreator")]
        public virtual ICollection<Quest> QuestsCreated { get; set; } = new List<Quest>();

        [InverseProperty("QuestOwner")]
        public virtual ICollection<Quest> QuestsOwned { get; set; } = new List<Quest>();

        [InverseProperty("RewardCreator")]
        public virtual ICollection<Reward> RewardsCreated { get; set; } = new List<Reward>();

        [InverseProperty("ClaimedBy")]
        public virtual ICollection<RewardClaim> RewardsClaimed { get; set; } = new List<RewardClaim>();

        [InverseProperty("TagingPlayer")]
        public virtual ICollection<Repetition> RepetitionTags { get; set; } = new List<Repetition>();
    }
}
