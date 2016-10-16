﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ldme.Abstract.Interfaces;
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
        private readonly ILogger<QuestController> _logger;

        public QuestController(IQuestRepository questRepository, ILogger<QuestController> log)
        {
            this.questRepository = questRepository;
            this._logger = log;
        }

        [HttpPost]
        public IActionResult Post([FromBody]QuestDto questData)
        {
            if (ModelState.IsValid)
            {
                var questModel = Mapper.Map<Quest>(questData);
                questRepository.CreateQuest(questModel);
                questRepository.SaveChanges();

                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}