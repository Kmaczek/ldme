using System.Collections.Generic;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IRewardRepository
    {
        void SaveChangesAsync();

        Reward GetReward(int id);

        IEnumerable<Reward> GetRewards(int playerId);
    }
}
