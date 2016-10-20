using System;
using Microsoft.AspNetCore.Mvc;
using Ldme.Abstract.Interfaces;
using Ldme.Models.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IPlayerRepository playerRepository, ILogger<PlayerController> log)
        {
            this.playerRepository = playerRepository;
            this._logger = log;
        }

        // api/player/[id]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var player = playerRepository.GetPlayer(id);
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
                return new JsonResult(playerRepository.SearchPlayers(query));
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
                playerRepository.AddPlayer(playerModel);
                playerRepository.SaveChanges();

                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
