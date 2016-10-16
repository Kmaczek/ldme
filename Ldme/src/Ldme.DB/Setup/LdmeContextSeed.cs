using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Models.Models;

namespace Ldme.DB.Setup
{
    public class LdmeContextSeed
    {
        private LdmeContext _context;

        public LdmeContextSeed(LdmeContext context)
        {
            this._context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Players.Any())
            {
                var mainPlayer = new Player
                {
                    Gold = 1000,
                    Name = "Test1",
                };

                _context.Players.Add(mainPlayer);
                _context.SaveChanges();

                mainPlayer.QuestsOwned = new List<Quest>
                {
                    new Quest()
                    {
                        Name = "Do things 1",
                        HonorReward = 100,
                        QuestCreatorId = mainPlayer.Id,
                        QuestOwnerId = mainPlayer.Id
                    },
                    new Quest()
                    {
                        Name = "Do things 2",
                        HonorReward = 20,
                        QuestCreatorId = mainPlayer.Id,
                        QuestOwnerId = mainPlayer.Id
                    },
                    new Quest()
                    {
                        Name = "Do things 3",
                        HonorReward = 30,
                        QuestCreatorId = mainPlayer.Id,
                        QuestOwnerId = mainPlayer.Id
                    },
                    new Quest()
                    {
                        Name = "Do things 4",
                        HonorReward = 44,
                        QuestCreatorId = mainPlayer.Id,
                        QuestOwnerId = mainPlayer.Id
                    }
                };

                _context.Quests.AddRange(mainPlayer.QuestsOwned);

                await _context.SaveChangesAsync();
            }
        }
    }
}
