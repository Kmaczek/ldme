using System;
using Microsoft.AspNetCore.Mvc;
using Ldme.Logic.Domains;
using Ldme.Models.Models;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly PlayerDomain playerDomain;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(PlayerDomain playerDomain, ILogger<PlayerController> log)
        {
            this.playerDomain = playerDomain;
            this._logger = log;
        }

        // api/player/[id]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var player = playerDomain.GetPlayer(id);
                return Json(player);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return Json(new {Message = "Server error, couldnt find player.", Error = e.Message});
            }
        }

        [HttpGet("search/{query}")]
        public IActionResult Get(string query)
        {
            try
            {
                var players = playerDomain.SearchPlayers(query);
                return new JsonResult(players);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot find players with specified query. {e.Message}, {e.StackTrace}");
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Player playerModel)
        {
            if (ModelState.IsValid)
            {
                playerDomain.AddPlayer(playerModel);

                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
