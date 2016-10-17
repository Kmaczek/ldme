using Ldme.Models.Dtos;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IQuestRepository
    {
        void CreateQuest(Quest quest);
        void CompleteQuest(int id, QuestCompletionDto completionData);
        void DeleteQuest(int id);
        void SaveChanges();
    }
}
