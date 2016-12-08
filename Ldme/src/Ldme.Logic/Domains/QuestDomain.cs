using System;
using System.Collections.Generic;
using System.Linq;
using Ldme.Abstract.Interfaces;
using Ldme.Common.Extensions;
using Ldme.Common.Helpers;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Ldme.Models.ViewModels;
using Microsoft.Extensions.Logging;

namespace Ldme.Logic.Domains
{
    public class QuestDomain
    {
        private readonly IQuestRepository questRepository;
        private readonly IRepetitionRepository repRepository;
        private readonly ILogger<QuestDomain> _logger;

        public QuestDomain(IQuestRepository questRepository, IRepetitionRepository repRepository, ILogger<QuestDomain> log)
        {
            this.questRepository = questRepository;
            this.repRepository = repRepository;
            this._logger = log;
        }

        public IEnumerable<QuestVM> GetQuestsForPlayer(int playerId)
        {
            var quests = questRepository.GetOwnedBy(playerId);
            var questsVM = new List<QuestVM>();
            foreach (var quest in quests)
            {
                var multiplier = repRepository.GetBonusMultiplier(quest.Id, DateTime.Now, quest.RequiredRepetitions,
                quest.RepetitionBonusType, quest.RepetitionsForMaxBonus);
                questsVM.Add(new QuestVM(quest, multiplier));
            }

            return questsVM;
        }

        public void CompleteQuest(int id, QuestCompletionDto completionData)
        {
            var quest = questRepository.GetQuest(id);

            if (quest.QuestOwnerId != completionData.CopletedBy
                || quest.QuestCreatorId != completionData.CopletedBy)
            {
                throw new Exception("Only owner or creator of this quest can complete it");
            }

            if (!quest.Accepted)
            {
                throw new Exception("Cannot complete not accepted quest");
            }

            if (quest.DeadlineDate.HasValue && (
                (completionData.CompletionDate.HasValue && quest.DeadlineDate.Value < completionData.CompletionDate)
                || quest.DeadlineDate.Value < DateTime.Now))
            {
                throw new Exception("Cannot complete quest after its deadline");
            }

            if (quest.FinishedDate.HasValue)
            {
                throw new Exception("Cannot complete already finished quest");
            }

            var questOwner = quest.QuestOwner;
            if (quest.QuestType == QuestType.Daily)
            {
                var rep = repRepository.CreateRepetition(quest, completionData.CopletedBy);

                questOwner.Gold += rep.GoldGain;
                questOwner.Honor += quest.HonorReward;
            }
            else
            {
                quest.QuestState = QuestState.Completed;
                quest.FinishedDate = completionData.CompletionDate ?? DateTime.Now;
                
                questOwner.Gold += quest.GoldReward;
                questOwner.Honor += quest.HonorReward;
            }
        }
    }
}
