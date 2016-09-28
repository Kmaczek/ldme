using System;
using System.Collections.Generic;
using System.Linq;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Models;

namespace Ldme.Persistence.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly LdmeContext ldmeContext;
        public PlayerRepository(LdmeContext context)
        {
            ldmeContext = context;
        }

        public Player GetPlayer(int id)
        {
            return ldmeContext.Players.First(x => x.Id == id);
        }

        public void AddPlayer(Player player)
        {
            ldmeContext.Players.Add(player);
        }

        public IEnumerable<Quest> GetQuests(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            ldmeContext.SaveChanges();
        }

        public IEnumerable<Player> GetPlayers()
        {
            return ldmeContext.Players;
        }
    }
}
