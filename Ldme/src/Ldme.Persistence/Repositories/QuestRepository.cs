using System;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Models;

namespace ldme.Persistence.Repositories
{
    public class QuestRepository : IQuestRepository
    {
        private readonly LdmeContext ldmeContext;
        public QuestRepository(LdmeContext context)
        {
            ldmeContext = context;
        }

        public void CreateQuest(Quest quest)
        {
            ldmeContext.Quests.Add(quest);
        }

        public void DeleteQuest(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            ldmeContext.SaveChanges();
        }
    }
}
