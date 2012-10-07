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

        public int GetPoints()
        {
            return frames.Sum(f => f.GetScore());
        }

        public Frame GetNextFrame(Frame frame)
        {
            int indexOf = frames.IndexOf(frame);

            return frames[indexOf + 1];
        }
    }
}
