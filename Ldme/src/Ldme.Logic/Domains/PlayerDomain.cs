using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ldme.Abstract.Interfaces;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Ldme.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace Ldme.Logic.Domains
{
    public class PlayerDomain
    {
        private readonly IPlayerRepository playerRepository;
        private readonly QuestDomain questDomain;
        private readonly ILogger<PlayerDomain> _logger;

        public PlayerDomain(IPlayerRepository playerRepository, QuestDomain questDomain, ILogger<PlayerDomain> log)
        {
            this.playerRepository = playerRepository;
            this.questDomain = questDomain;
            this._logger = log;
        }

        public PlayerVM GetPlayer(int id)
        {
            return new PlayerVM(playerRepository.GetPlayer(id), questDomain.GetQuestsForPlayer(id));
        }

        public IEnumerable<PlayerSearchDto> SearchPlayers(string query)
        {
            var searchedPlayers = playerRepository.SearchPlayers(query);
            var playersVM = Mapper.Map<IEnumerable<Player>, IEnumerable<PlayerSearchDto>>(searchedPlayers);
            return playersVM;
        }

        public Player AddPlayer(Player playerModel)
        {
            playerRepository.AddPlayer(playerModel);
            playerRepository.SaveChanges();

            return playerModel;
        }
    }
}
