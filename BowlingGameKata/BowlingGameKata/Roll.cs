namespace BowlingGameKata
{
    public class Roll
    {
        public int Pins { get; set; }
        public Roll NextRoll { get; set; }

        public Roll(int pins)
        {
            Pins = pins;
        }

        internal RollSummary RollSummary(int numberOfBonusRolls)
        {
            if (numberOfBonusRolls == 0)
                return new RollSummary { BonusScore = 0, HasBonusRolls = true };
            if (NextRoll == null)
                return new RollSummary { BonusScore = 0, HasBonusRolls = false };

            var nextRollSummary = NextRoll.RollSummary(numberOfBonusRolls - 1);
            return new RollSummary
            {
                BonusScore = NextRoll.Pins + nextRollSummary.BonusScore,
                HasBonusRolls = nextRollSummary.HasBonusRolls
            };
        }
    }
}