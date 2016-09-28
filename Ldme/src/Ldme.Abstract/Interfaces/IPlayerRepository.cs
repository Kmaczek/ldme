using System.Collections.Generic;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetPlayer(int id);

        void AddPlayer(Player player);

        IEnumerable<Quest> GetQuests(int id);

        void SaveChanges();
        IEnumerable<Player> GetPlayers();
    }
}
