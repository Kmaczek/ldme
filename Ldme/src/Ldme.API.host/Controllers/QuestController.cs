using System;
using AutoMapper;
using Ldme.Abstract.Interfaces;
using Ldme.Logic.Domains;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class QuestController : Controller
    {
        private readonly IQuestRepository questRepository;
        private readonly IRepetitionRepository repRepository;
        private readonly QuestDomain questDomain;
        private readonly ILogger<QuestController> _logger;

        public QuestController(IQuestRepository questRepository, IRepetitionRepository repRepository, ILogger<QuestController> log, QuestDomain questDomain)
        {
            this.questRepository = questRepository;
            this.repRepository = repRepository;
            this.questDomain = questDomain;
            this._logger = log;
        }

        [HttpPost]
        public IActionResult Post([FromBody]QuestDto questData)
        {
            if (ModelState.IsValid)
            {
                _logger.LogDebug("Trying to create quest");
                var questModel = Mapper.Map<Quest>(questData);
                questRepository.CreateQuest(questModel);
                questRepository.SaveChanges();

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPost("{id}/complete")]
        public IActionResult Post(int id, [FromBody]QuestCompletionDto completionData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogDebug("Trying to complete quest");
                    questDomain.CompleteQuest(id, completionData);
                    return Ok();
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    return BadRequest();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("createdby/{id}")]
        public IActionResult CreatedBy(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogDebug($"Trying to get quests created by player: {id}");
                    var questsCreatedBy = questRepository.GetCreatedBy(id);
                    return Json(questsCreatedBy);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    return BadRequest();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("ownedby/{id}")]
        public IActionResult OwnedBy(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogDebug($"Trying to get quests owned by player: {id}");
                    var questsCreatedBy = questDomain.GetQuestsForPlayer(id);
                    return Json(questsCreatedBy);
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    return BadRequest();
                }
            }

            return BadRequest(ModelState);
        }
    }
}
