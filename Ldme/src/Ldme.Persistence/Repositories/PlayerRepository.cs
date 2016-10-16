﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Models;
using Microsoft.EntityFrameworkCore;

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
            return ldmeContext.Players
                .Include(q => q.QuestsCreated)
                .Include(q => q.QuestsOwned)
                .First(x => x.Id == id);
        }

        public Player GetPlayerByEmail(string email)
        {
            return ldmeContext.Players.First(p => ldmeContext.Users.First(u => u.Email == email).Player == p);
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
