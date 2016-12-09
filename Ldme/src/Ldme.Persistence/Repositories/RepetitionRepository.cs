using System;
using System.Collections.Generic;
using System.Linq;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Models;
using Ldme.Common.Extensions;
using Ldme.Common.Helpers;

namespace Ldme.Persistence.Repositories
{
    public class RepetitionRepository : IRepetitionRepository
    {
        private readonly LdmeContext _context;

        public RepetitionRepository(LdmeContext context)
        {
            _context = context;
        }

        public Repetition CreateRepetition(Quest quest, int playerId)
        {
            var multiplier = this.GetBonusMultiplier(quest.Id, DateTime.UtcNow, quest.RequiredRepetitions,
                quest.RepetitionBonusType, quest.RepetitionsForMaxBonus);
            var rep = new Repetition
            {
                CompletionDate = DateTime.UtcNow,
                ReferencedQuestId = quest.Id,
                TagingPlayerId = playerId,
                GoldGain = quest.GoldReward + quest.GoldReward*(quest.RepetitionBonusMultiplier*multiplier),
                HonorGain = quest.HonorReward // not aplicable for honor
            };

            _context.Repetitions.Add(rep);
            return rep;
        }

        public IEnumerable<Repetition> GetRepetitions(int questId)
        {
            var tags = _context.Repetitions.Where(x => x.ReferencedQuestId == questId).ToList();

            return tags;

        }

        /// <summary>
        /// This should calculate Repetition bonus for any given date
        /// </summary>
        /// <param name="questId">obvious</param>
        /// <param name="date">Date for which calculate bonus</param>
        /// <param name="requiredRepetitions">Repetitions required so quest wont be failed</param>
        /// <param name="repetitionType">RepetitionType.Daily, Weekly ...</param>
        /// <param name="repetitionsToMaxBonus">Repetitions reuired for full bonus</param>
        /// <returns></returns>
        public float GetBonusMultiplier(int questId, DateTime date, int requiredRepetitions, string repetitionType, int repetitionsToMaxBonus)
        {
            if (string.IsNullOrEmpty(repetitionType))
            {
                return 0;
            }

            var funcToExecOnDate = GetFuncToExecOnDate(repetitionType);

            if (funcToExecOnDate == null)
            {
                return 0;
            }

            int streak = 0;

            for (int i = repetitionsToMaxBonus; i > 0; i--)
            {
                var dateRange = GetRepetitionDateRange(repetitionType, funcToExecOnDate(date, i));
                var count = _context.Repetitions.Count(x => x.ReferencedQuestId == questId &&
                    x.CompletionDate.Between(dateRange.StartDate, dateRange.EndDate));
                if (count >= requiredRepetitions)
                {
                    streak++;
                }
                else
                {
                    streak = 0;
                }
            }

            return (float) streak/repetitionsToMaxBonus;
        }

        public async void SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        private Func<DateTime, int, DateTime> GetFuncToExecOnDate(string repetitionType)
        {
            if (repetitionType == RepetitionType.Daily)
            {
                return (fDate, count) => fDate.AddDays(-count);
            }

            if (repetitionType == RepetitionType.Weekly)
            {
                return (fDate, count) => fDate.AddDays(-7*count);
            }

            if (repetitionType == RepetitionType.Monthly)
            {
                return (fDate, count) => fDate.AddMonths(-count);
            }

            return null;
        }

        private DateRange GetRepetitionDateRange(string repetitionType, DateTime dateInRange)
        {
            DateTime startDate, endDate;
            if (repetitionType == RepetitionType.Daily)
            {
                startDate = dateInRange.StartOfDay();
                endDate = dateInRange.EndOfDay();
            }
            else if (repetitionType == RepetitionType.Weekly)
            {
                startDate = dateInRange.StartOfWeek();
                endDate = dateInRange.EndOfWeek();
            }
            else if (repetitionType == RepetitionType.Monthly)
            {
                startDate = dateInRange.StartOfMonth();
                endDate = dateInRange.EndOfMonth();
            }
            else
            {
                startDate = new DateTime();
                endDate = new DateTime();
            }

            return new DateRange()
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }
    }
}
