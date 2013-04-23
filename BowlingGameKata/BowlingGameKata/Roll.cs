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
    }
}