using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    /// <summary>
    /// Rewards that can be claimed for spending anough amount of gold/honor
    /// </summary>
    public class Reward
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Description { get; set; }

        public int GoldPrice { get; set; }

        public int HonorPrice { get; set; }

        public int RewardCreatorId { get; set; }

        public Player RewardCreator { get; set; }
    }
}
