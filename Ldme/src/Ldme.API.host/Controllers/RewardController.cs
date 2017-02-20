using System;
using Ldme.Abstract.Interfaces;
using Ldme.API.host.RequestHandling;
using Ldme.Logic.Domains;
using Ldme.Models;
using Ldme.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class RewardController: Controller
    {
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
                    _logger.LogExceptions(e, this);
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
        }

        [HttpPost]
        public IActionResult AddReward([FromBody]CreateRewardDto createReward)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogDebug($"Creating reward");
                    var result = rewardDomain.CreateReward(createReward);
                    if (result.Invalid)
                    {
                        return BadRequest(new ErrorDto(result));
                    }

                    return Created(this.Request.Path, result.Entity);
                }
                catch (Exception e)
                {
                    _logger.LogExceptions(e, this);
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
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
                    _logger.LogExceptions(e, this);
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
        }

        [HttpPost("{id}/deactivate")]
        public IActionResult DeactivateReward(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogDebug($"Deactivating reward: {id}");
                    rewardDomain.Deactivate(id);
                    return Ok();
                }
                catch (Exception e)
                {
                    _logger.LogExceptions(e, this);
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
        }
    }
}
