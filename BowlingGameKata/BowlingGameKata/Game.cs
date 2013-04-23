namespace BowlingGameKata
{
    public class Game
    {
        public int Score { get; private set; }

        public void Roll(int pins)
        {
            Score += pins;
        }
    }
}