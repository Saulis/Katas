using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game
    {
        private readonly List<Frame> frames;

        public Game()
        {
            frames = new List<Frame> {new Frame(this)};
        }

        public void Roll(int pins)
        {
            if(CurrentFrameHasEnded)
            {
                StartANewFrame();
            }

            CurrentFrame.AddRoll(pins);
        }

        private void StartANewFrame()
        {
            frames.Add(frames.Count >= 9 ? new TenthFrame(this) : new Frame(this));
        }

        protected bool CurrentFrameHasEnded
        {
            get { return !frames.Any() || CurrentFrame.HasEnded; }
        }

        private Frame CurrentFrame
        {
            get { return frames.Last(); }
        }

        public int GetScore()
        {
            return frames.Sum(f => f.GetScore());
        }

        private Frame GetNextFrame(Frame frame)
        {
            int indexOfFrame = frames.IndexOf(frame);

            return frames[indexOfFrame + 1];
        }

        public int GetSumOfNextTwoRolls(Frame frame)
        {
            if(NextFrameHasTwoRolls(frame))
            {
                return GetNextFrame(frame).SumOfRolls();
            }

            return GetScoreOfNextRoll(frame) + GetScoreOfFirstRollFromSecondFrame(frame);
        }

        private int GetScoreOfFirstRollFromSecondFrame(Frame frame)
        {
            Frame secondFrame = GetNextFrame(GetNextFrame(frame));

            return secondFrame.FirstRoll;
        }

        public int GetScoreOfNextRoll(Frame frame)
        {
            Frame nextFrame = GetNextFrame(frame);

            return nextFrame.FirstRoll;
        }

        private bool NextFrameHasTwoRolls(Frame frame)
        {
            Frame nextFrame = GetNextFrame(frame);

            return nextFrame.RollsCount() == 2;
        }
    }
}
