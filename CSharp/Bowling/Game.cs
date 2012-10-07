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
            if(frames.Count >= 9)
            {
                frames.Add(new TenthFrame(this));
            }
            else
            {
                frames.Add(new Frame(this));    
            }
        }

        protected bool CurrentFrameHasEnded
        {
            get { return frames.Any() && CurrentFrame.HasEnded; }
        }

        private Frame CurrentFrame
        {
            get { return frames.Last(); }
        }

        public int GetScore()
        {
            return frames.Sum(f => f.GetScore());
        }

        public Frame GetNextFrame(Frame frame)
        {
            int indexOf = frames.IndexOf(frame);

            return frames[indexOf + 1];
        }

        public int GetScoreFromNextTwoRolls(Frame frame)
        {
            Frame nextFrame = GetNextFrame(frame);

            List<int> rolls = nextFrame.Rolls.ToList();

            if(rolls.Count == 1)
            {
                Frame secondNextFrame = GetNextFrame(nextFrame);
                rolls.Add(secondNextFrame.FirstRoll);
            }

            return rolls.Sum();
        }
    }
}
