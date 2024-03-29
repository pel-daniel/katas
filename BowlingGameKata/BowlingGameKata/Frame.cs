﻿using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    internal class Frame
    {
        private readonly List<Roll> rolls;

        public Frame()
        {
            rolls = new List<Roll>();
        }

        private bool IsSpare()
        {
            return Score() == 10;
        }

        public bool IsStrike()
        {
            return rolls.Count == 1 && Score() == 10;
        }

        public bool HasTwoRolls()
        {
            return rolls.Count == 2;
        }

        public int Score()
        {
            return rolls.Sum(r => r.Pins);
        }

        public int NumberOfBonusRolls()
        {
            var bonusRolls = 0;

            if (IsStrike())
                bonusRolls = 2;
            else if (IsSpare())
                bonusRolls = 1;

            return bonusRolls;
        }

        public void AddRoll(Roll roll)
        {
            rolls.Add(roll);
        }

        public FrameSummary FrameSummary()
        {
            var bonusStatus = rolls.Last().RollSummary(NumberOfBonusRolls());

            return new FrameSummary
            {
                Bonus = bonusStatus.BonusScore,
                HasBonusRolls = bonusStatus.HasBonusRolls,
                Score = Score()
            };
        }
    }
}