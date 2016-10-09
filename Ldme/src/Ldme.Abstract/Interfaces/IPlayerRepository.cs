using System.Collections.Generic;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetPlayer(int id);
        Player GetPlayerByEmail(string email);

        void AddPlayer(Player player);

        IEnumerable<Quest> GetQuests(int id);

        void SaveChanges();
        IEnumerable<Player> GetPlayers();
    }
}
