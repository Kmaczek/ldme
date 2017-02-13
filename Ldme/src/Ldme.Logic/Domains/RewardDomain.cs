using System;
using System.Collections.Generic;
using Ldme.Abstract.Interfaces;
using Ldme.Models.Models;
using Microsoft.Extensions.Logging;

namespace Ldme.Logic.Domains
{
    public class RewardDomain
    {
        private readonly ILogger<RewardDomain> logger;
        private readonly IRewardRepository rewardRepository;
        private readonly IPlayerRepository playerRepository;

        public RewardDomain(ILogger<RewardDomain> logger, IRewardRepository rewardRepository, IPlayerRepository playerRepository)
        {
            this.logger = logger;
            this.rewardRepository = rewardRepository;
            this.playerRepository = playerRepository;
        }

        public IEnumerable<Reward> GetRewards(int id)
        {
            return rewardRepository.GetRewards(id);
        }

        public void ClaimReward(int id)
        {
            var reward = rewardRepository.GetReward(id);

            if (reward.GoldPrice > 0)
            {
                playerRepository.ChangeGold(reward.RewardCreatorId, -reward.GoldPrice);
            }

            if (reward.HonorPrice > 0)
            {
                playerRepository.ChangeHonor(reward.RewardCreatorId, -reward.HonorPrice);
            }

            playerRepository.SaveChanges();
        }

        public void Deactivate(int id)
        {
            rewardRepository.Deactivate(id);
            rewardRepository.SaveChanges();
        }
    }
}
