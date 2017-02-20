using System;
using System.Collections.Generic;
using System.Linq;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Exceptions;
using Ldme.Models.Models;

namespace Ldme.Persistence.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private LdmeContext _context;

        public RewardRepository(LdmeContext context)
        {
            this._context = context;
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var reward = GetReward(id);
            reward.Deactivated = DateTime.Now;
        }

        public Reward GetReward(int id)
        {
            var reward = _context.Rewards.Single(x => x.Id == id);
            if (reward == null)
            {
                throw new ResourceNotFoundException($"Cannot find Reward with id: {id}");
            }
            return reward;
        }

        public Reward CreateReward(Reward reward)
        {
            _context.Rewards.Add(reward);

            return reward;
        }

        public IEnumerable<Reward> GetRewards(int playerId)
        {
            return _context.Rewards.Where(x => x.RewardCreatorId == playerId && x.Deactivated == null).ToList();
        }
    }
}
