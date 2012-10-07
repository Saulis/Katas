using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game : IGame
    {
        private readonly List<Frame> frames;

        public Game()
        {
            frames = CreateFrames();
        }

        private List<Frame> CreateFrames()
        {
            List<Frame> newFrames = new List<Frame>();

            for (int i = 0; i < 9; i++)
            {
                newFrames.Add(new Frame(i+1, this));
            }

            newFrames.Add(new TenthFrame(10, this));

            return newFrames;
        }

        public void Roll(int pins)
        {
            CurrentFrame.AddRoll(pins);
        }

        private Frame CurrentFrame
        {
            get { return frames.First(f => !f.HasEnded); }
        }

        public int GetScore()
        {
            return frames.Sum(f => f.GetScore());
        }

        private Frame GetNextFrame(Frame frame)
        {
            return frames.Single(f => f.Number == frame.Number + 1);
        }

        private int GetFirstRollFromSecondFrame(Frame frame)
        {
            Frame secondFrame = GetNextFrame(GetNextFrame(frame));

            return secondFrame.FirstRoll;
        }

        public int GetNextRoll(Frame frame)
        {
            Frame nextFrame = GetNextFrame(frame);

            return nextFrame.FirstRoll;
        }

        public int GetSecondNextRoll(Frame frame)
        {
            if(NextFrameHasTwoRolls(frame))
            {
                Frame nextFrame = GetNextFrame(frame);

                return nextFrame.SecondRoll;
            }

            return GetFirstRollFromSecondFrame(frame);
        }

        private bool NextFrameHasTwoRolls(Frame frame)
        {
            Frame nextFrame = GetNextFrame(frame);

            return nextFrame.RollsCount() >= 2;
        }
    }
}
