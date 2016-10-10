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
                        RewardedHonor = 100,
                        QuestGiverId = mainPlayer.Id,
                        QuestRevceiverId = mainPlayer.Id
                    },
                    new Quest()
                    {
                        Name = "Do things 2",
                        RewardedHonor = 20,
                        QuestGiverId = mainPlayer.Id,
                        QuestRevceiverId = mainPlayer.Id
                    },
                    new Quest()
                    {
                        Name = "Do things 3",
                        RewardedHonor = 30,
                        QuestGiverId = mainPlayer.Id,
                        QuestRevceiverId = mainPlayer.Id
                    },
                    new Quest()
                    {
                        Name = "Do things 4",
                        RewardedHonor = 44,
                        QuestGiverId = mainPlayer.Id,
                        QuestRevceiverId = mainPlayer.Id
                    }
                };

                _context.Quests.AddRange(mainPlayer.QuestsOwned);

                await _context.SaveChangesAsync();
            }
        }
    }
}
