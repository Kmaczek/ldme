using System;
using System.Collections.Generic;
using AutoMapper;
using Ldme.Abstract.Interfaces;
using Ldme.Logic.Validation;
using Ldme.Logic.Validation.ErrorModels;
using Ldme.Models;
using Ldme.Models.Dtos;
using Ldme.Models.Exceptions;
using Ldme.Models.Models;
using Microsoft.Extensions.Logging;

namespace Ldme.Logic.Domains
{
    public class RewardDomain
    {
        private readonly ILogger<RewardDomain> logger;
        private readonly IRewardRepository rewardRepository;
        private readonly IPlayerRepository playerRepository;

        public RewardDomain(ILogger<RewardDomain> logger, IRewardRepository rewardRepository,
            IPlayerRepository playerRepository)
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

        public DomainResult<Reward> CreateReward(CreateRewardDto createReward)
        {
            var result = new DomainResult<Reward>();
            var player = playerRepository.GetPlayer(createReward.RewardCreatorId);
            if (player == null)
            {
                result.Errors.Add(new MissingPlayerErrorModel(createReward.RewardCreatorId));
                return result;
            }

            var rewardModel = Mapper.Map<Reward>(createReward);

            result.Entity = rewardRepository.CreateReward(rewardModel);
            rewardRepository.SaveChanges();

            return result;
        }

        public void Deactivate(int id)
        {
            rewardRepository.Deactivate(id);
            rewardRepository.SaveChanges();
        }
    }
}
