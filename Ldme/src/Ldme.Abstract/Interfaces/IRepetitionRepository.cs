using System;
using System.Collections.Generic;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IRepetitionRepository
    {
        Repetition CreateRepetition(Quest quest, int playerId);

        IEnumerable<Repetition> GetRepetitions(int questId);

        float GetBonusMultiplier(int questId, DateTime date, int requiredRepetitions, string repetitionType, int repetitionsToMaxBonus);

        void SaveChanges();
    }
}
