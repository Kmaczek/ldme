using System;
using System.Collections.Generic;
using System.Linq;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
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

        public Reward GetReward(int id)
        {
            return _context.Rewards.Single(x => x.Id == id);
        }

        public IEnumerable<Reward> GetRewards(int playerId)
        {
            return _context.Rewards.Where(x => x.RewardCreatorId == playerId).ToList();
        }
    }
}
