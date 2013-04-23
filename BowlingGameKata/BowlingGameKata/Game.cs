using System.Collections.Generic;
using System.Linq;

namespace BowlingGameKata
{
    public class Game
    {
        private const int FramesPerGame = 10;

        private readonly List<Frame> frames;
        private Frame currentFrame;
        private Roll currentRoll;

        public Game()
        {
            currentFrame = new Frame();
            frames = new List<Frame> { currentFrame };
        }

        public void Roll(int pins)
        {
            Roll(new Roll(pins));
        }

        private void Roll(Roll roll)
        {
            GetCurrentFrame().AddRoll(roll);

            if (!FirstRoll())
                currentRoll.NextRoll = roll;

            currentRoll = roll;
        }

        public int Score()
        {
            return frames.Take(FramesPerGame).Select(f => f.Score() + f.Bonus()).Sum();
        }

        private Frame GetCurrentFrame()
        {
            if (frames.Count != FramesPerGame && (currentFrame.IsStrike() || currentFrame.HasTwoRolls()))
            {
                currentFrame = new Frame();
                frames.Add(currentFrame);
            }

            return currentFrame;
        }

        private bool FirstRoll()
        {
            return currentRoll == null;
        }
    }
}