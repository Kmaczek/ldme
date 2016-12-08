using System;

namespace Ldme.Models.Models
{
    public class RewardClaim
    {
        public int Id { get; set; }

        public int ClaimedById { get; set; }

        public Player ClaimedBy { get; set; }

        public DateTime ClaimDate { get; set; }
    }
}
