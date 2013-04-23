namespace BowlingGameKata
{
    public class Game
    {
        private Frames frames = new Frames();

        public void Roll(int pins)
        {
            frames.Roll(pins);
        }

        public int Score()
        {
            return frames.Score();
        }
    }
}