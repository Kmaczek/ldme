﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Dtos;
using Ldme.Models.Exceptions;
using Ldme.Models.Models;
using Microsoft.EntityFrameworkCore;

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
            if (quest.QuestCreatorId == quest.QuestOwnerId)
            {
                quest.Accepted = true;
                quest.QuestState = QuestState.InProgress;
            }

            ldmeContext.Quests.Add(quest);
        }

        public void CompleteQuest(int id, QuestCompletionDto completionData)
        {
            var quest = ldmeContext.Quests.Include(q => q.QuestOwner).Single(x => x.Id == id);

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
                || quest.DeadlineDate.Value < DateTime.UtcNow))
            {
                throw new Exception("Cannot complete quest after its deadline");
            }

            if (quest.FinishedDate.HasValue)
            {
                throw new Exception("Cannot complete already finished quest");
            }

            if (quest.QuestType == QuestType.Daily)
            {
                ldmeContext.Repetitions.Add(new Repetition
                {
                    CompletionDate = completionData.CompletionDate ?? DateTime.UtcNow,
                    GoldGain = quest.GoldReward,
                    HonorGain = quest.HonorReward,
                    ReferencedQuest = quest,
                    TagingPlayerId = completionData.CopletedBy
                });
            }
            else
            {
                quest.QuestState = QuestState.Completed;
                quest.FinishedDate = completionData.CompletionDate ?? DateTime.UtcNow;
            }

            var questOwner = quest.QuestOwner;
            questOwner.Gold += quest.GoldReward;
            questOwner.Honor += quest.HonorReward;
        }

        public Quest GetQuest(int id)
        {
            var quest = ldmeContext.Quests
                .Include(q => q.QuestOwner)
                .Include(q => q.QuestCreator)
                .Single(x => x.Id == id);

            if (quest == null)
            {
                throw new ResourceNotFoundException($"Could not found Quest with id: {id}");
            }

            return quest;
        }

        public IEnumerable<Quest> GetCreatedBy(int playerId)
        {
            return ldmeContext.Quests.Where(x => x.QuestCreatorId == playerId).ToList();
        }

        public IEnumerable<Quest> GetOwnedBy(int playerId)
        {
            return ldmeContext.Quests.Where(x => x.QuestOwnerId == playerId).ToList();
        }

        public void DeleteQuest(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            ldmeContext.SaveChanges();
        }

        private float CalculateBonusForRepetition()
        {

            return 1;
        }
    }
}
