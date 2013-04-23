using System.Linq;

namespace BowlingGameKata
{
    internal class Frames
    {
        private const int FramesPerGame = 10;

        private Frame[] frames;
        private int currentFrameIndex;
        private Frame currentFrame;

        public Frames()
        {
            frames = new Frame[FramesPerGame];
            currentFrameIndex = 0;
            currentFrame = frames[currentFrameIndex];
        }

        private void SetNextFrame()
        {
            currentFrame = frames[currentFrameIndex++];
        }

        public void Roll(int pins)
        {
            currentFrame.Roll(pins);

            if (currentFrame.IsStrike() || currentFrame.HasTwoRolls())
                SetNextFrame();
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        public int Score()
        {
            var score = 0;
            var frameIndex = 0;

            for (var i = 0; i < frames.Length; i++)
            {
                var frame = frames[i];

                score += frame.Score() + Bonus(i, frame.NumberOfBonusRolls());
            }

            //return frames.Select(f => f.Score() + f.NumberOfBonusRolls()).Sum();
            return score;

            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        private int Bonus(int index, int numberOfBonusRolls)
        {
            return frames[]
        }
    }
}