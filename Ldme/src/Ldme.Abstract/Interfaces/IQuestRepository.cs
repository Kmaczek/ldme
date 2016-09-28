using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IQuestRepository
    {
        void CreateQuest(Quest quest);

        void DeleteQuest(int id);
    }
}
