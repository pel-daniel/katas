using System.Linq;

namespace BowlingGameKata
{
    internal class Frame
    {
        private const int Strike = 10;
        private int[] rolls = new int[2];
        private int rollIndex = 0;

        private bool IsSpare()
        {
            return Score() == 10;
        }

        public bool IsStrike()
        {
            return rolls.First() == Strike;
        }

        public bool HasTwoRolls()
        {
            return rollIndex == 2;
        }

        public void Roll(int pins)
        {
            rolls[rollIndex++] = pins;
        }

        public int Score()
        {
            return rolls.Sum();
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
    }
}