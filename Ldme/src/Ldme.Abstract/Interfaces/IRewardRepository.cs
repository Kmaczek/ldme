using System.Collections.Generic;
using Ldme.Models.Dtos;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IRewardRepository
    {
        void SaveChangesAsync();

        void SaveChanges();

        void Deactivate(int id);

        Reward GetReward(int id);

        Reward CreateReward(Reward reward);

        IEnumerable<Reward> GetRewards(int playerId);
    }
}
