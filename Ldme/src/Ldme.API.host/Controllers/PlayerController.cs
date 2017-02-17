using System;
using Ldme.API.host.RequestHandling;
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
                _logger.LogExceptions(e, this);
                return this.HandleErrors(e);
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
                _logger.LogExceptions(e, this);
                return this.HandleErrors(e);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Player playerModel)
        {
            //TODO: Change this to PlayerDto and apply anotations on properties
            if (ModelState.IsValid)
            {
                try
                {
                    var player = playerDomain.AddPlayer(playerModel);
                    return Created(this.Request.Path, player);
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
