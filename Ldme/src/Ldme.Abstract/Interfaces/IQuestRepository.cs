using System.Collections.Generic;
using Ldme.Models.Dtos;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IQuestRepository
    {
        void SaveChanges();
        void DeleteQuest(int id);
        void CreateQuest(Quest quest);
        void CompleteQuest(int id, QuestCompletionDto completionData);

        IEnumerable<Quest> GetCreatedBy(int playerId);
        IEnumerable<Quest> GetOwnedBy(int playerId);
    }
}
