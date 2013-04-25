using System.Collections.Generic;
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
            var numberOfBonusRolls = NumberOfBonusRolls();
            var lastRoll = rolls.Last();

            return new FrameSummary
            {
                Bonus = Bonus(numberOfBonusRolls, lastRoll),
                HasBonusRolls = HasBonusRolls(numberOfBonusRolls, lastRoll),
                Score = Score()
            };
        }

        private int Bonus(int numberOfBonusRolls, Roll lastRoll)
        {
            if (numberOfBonusRolls == 0 || lastRoll.NextRoll == null)
                return 0;

            return lastRoll.NextRoll.Pins + Bonus(numberOfBonusRolls - 1, lastRoll.NextRoll);
        }

        private bool HasBonusRolls(int numberOfBonusRolls, Roll lastRoll)
        {
            if (numberOfBonusRolls == 0)
                return true;

            return lastRoll.NextRoll != null && HasBonusRolls(numberOfBonusRolls - 1, lastRoll.NextRoll);
        }
    }
}