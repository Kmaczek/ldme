using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Models.Factories;
using Ldme.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Ldme.DB.Setup
{
    public class LdmeContextSeed
    {
        private LdmeContext _context;
        private UserManager<LdmeUser> userManager;
        private PlayerFactory playerFactory;

        public LdmeContextSeed(LdmeContext context, UserManager<LdmeUser> userManager, PlayerFactory playerFactory)
        {
            this._context = context;
            this.userManager = userManager;
            this.playerFactory = playerFactory;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Players.Any(x => x.Name == "dam"))
            {
                var email = "dam@kma.com";
                var pass = "qqq";
                var mainPlayer = playerFactory.GetInitialPlayer(email);

                _context.Players.Add(mainPlayer);
                _context.SaveChanges();

                await userManager.CreateAsync(new LdmeUser()
                {
                    UserName = email,
                    Email = email,
                    Player = mainPlayer
                }, pass);

                mainPlayer.QuestsOwned = new List<Quest>
                {
                    new Quest()
                    {
                        Name = "Przysiady",
                        GoldReward = 2,
                        GoldPenalty = 2,
                        QuestCreatorId = mainPlayer.Id,
                        QuestOwnerId = mainPlayer.Id,
                        Accepted = true,
                        Description = "Zrob 20 Przysiadow",
                        MaxRepetitions = 1,
                        QuestState = QuestState.InProgress,
                        QuestType = QuestType.Daily,
                        RepetitionBonusMultiplier = 2,
                        RepetitionBonusType = RepetitionType.Weekly,
                        RepetitionsForMaxBonus = 3,
                        RequiredRepetitions = 5,
                        CreatedDate = DateTime.Now
                    },
                    new Quest()
                    {
                        Name = "Przygotowac cos",
                        GoldReward = 10,
                        GoldPenalty = 20,
                        HonorReward = 1,
                        HonorPenalty = 1,
                        QuestCreatorId = mainPlayer.Id,
                        QuestOwnerId = mainPlayer.Id,
                        Accepted = true,
                        Description = "Przygotuj cos i to zaraz. Opis opis opis opis opis opis opis opis opis opis opis" +
                                      " opis opis opis opis opis opis opis opis opis opis opis opis opis opis opis opis opis opis" +
                                      " opis opis opis opis opis opis opis opis opis opis opis opis opis opis opis opis",
                        QuestState = QuestState.InProgress,
                        QuestType = QuestType.Regular,
                        CreatedDate = DateTime.Now.AddDays(-5),
                        DeadlineDate = DateTime.UtcNow.AddMonths(1)
                    }
                };

                var daily = new Quest()
                {
                    Name = "Pompki",
                    GoldReward = 1,
                    GoldPenalty = 1,
                    HonorReward = 1,
                    HonorPenalty = 1,
                    QuestCreatorId = mainPlayer.Id,
                    QuestOwnerId = mainPlayer.Id,
                    Accepted = true,
                    Description = "Zrob 10 pompek",
                    MaxRepetitions = 2,
                    QuestState = QuestState.InProgress,
                    QuestType = QuestType.Daily,
                    RepetitionBonusMultiplier = 2,
                    RepetitionBonusType = RepetitionType.Daily,
                    RepetitionsForMaxBonus = 5,
                    RequiredRepetitions = 1,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Quests.AddRange(mainPlayer.QuestsOwned);
                _context.Quests.Add(daily);

                //await _context.SaveChangesAsync();

                mainPlayer.RepetitionTags = new List<Repetition>
                {
                    new Repetition
                    {
                        CompletionDate = DateTime.UtcNow.AddDays(-3),
                        GoldGain = 2,
                        HonorGain = 0,
                        TagingPlayerId = mainPlayer.Id,
                        ReferencedQuestId = daily.Id
                    },
                    new Repetition
                    {
                        CompletionDate = DateTime.UtcNow.AddDays(-2),
                        GoldGain = 2,
                        HonorGain = 0,
                        TagingPlayerId = mainPlayer.Id,
                        ReferencedQuestId = daily.Id
                    },
                    new Repetition
                    {
                        CompletionDate = DateTime.UtcNow.AddDays(-1),
                        GoldGain = 2,
                        HonorGain = 0,
                        TagingPlayerId = mainPlayer.Id,
                        ReferencedQuestId = daily.Id
                    }
                };

                await _context.SaveChangesAsync();

                _context.Rewards.Add(new Reward
                {
                    Description = "Kupuje lody",
                    GoldPrice = 10,
                    HonorPrice = 0,
                    RewardCreatorId = 2
                });
            }
        }
    }
}
