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
                    Quests = new List<Quest>
                    {
                        new Quest() { Name = "Do things 1", RewardedHonor = 100 },
                        new Quest() { Name = "Do things 2", RewardedHonor = 20 },
                        new Quest() { Name = "Do things 3", RewardedHonor = 30 },
                        new Quest() { Name = "Do things 4", RewardedHonor = 44 }
                    }
                };

                _context.Players.Add(mainPlayer);
                _context.Quests.AddRange(mainPlayer.Quests);

                await _context.SaveChangesAsync();
            }
        }
    }
}
