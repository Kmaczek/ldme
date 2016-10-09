using System;
using Microsoft.AspNetCore.Mvc;
using Ldme.Abstract.Interfaces;
using Ldme.Models.Models;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/players")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository playerRepository;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IPlayerRepository playerRepository, ILogger<PlayerController> log)
        {
            this.playerRepository = playerRepository;
            this._logger = log;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var player = playerRepository.GetPlayer(id);
            return Json(player);
        }

        [HttpGet("{email}")]
        public JsonResult Get([FromQuery]string email)
        {
            var player = playerRepository.GetPlayerByEmail(email);
            return Json(player);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(playerRepository.GetPlayers());
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get players from database. {e.Message}");
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
