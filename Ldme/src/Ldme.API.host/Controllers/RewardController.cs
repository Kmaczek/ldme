using System;
using Ldme.Abstract.Interfaces;
using Ldme.Logic.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class RewardController: Controller
    {
        //private readonly IFriendRepository friendRepository;
        private readonly ILogger<FriendController> _logger;
        private readonly RewardDomain rewardDomain;

        public RewardController(RewardDomain rewardRepository, ILogger<FriendController> log)
        {
            _logger = log;
            this.rewardDomain = rewardRepository;
        }

        [HttpGet("forPlayer/{id}")]
        public IActionResult ForPlayer(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogDebug($"Trying to get quests created by player: {id}");
                    var playerRewards = rewardDomain.GetRewards(id);
                    return Json(playerRewards);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    return BadRequest();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("{id}/claim")]
        public IActionResult ClaimReward(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogDebug($"Claiming reward: {id}");
                    rewardDomain.ClaimReward(id);
                    return Ok();
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
