using System.Collections.Generic;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IPlayerRepository
    {
        void SaveChanges();

        void AddPlayer(Player player);

        Player GetPlayer(int id);

        Player GetPlayerByEmail(string email);

        IEnumerable<Quest> GetQuests(int id);

        IEnumerable<Player> SearchPlayers(string query);
    }
}
