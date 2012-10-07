using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Frame
    {
        private readonly List<int> rolls;
        private readonly Game game;

        public Frame(Game game)
        {
            this.game = game;
            rolls = new List<int>();
        }

        public bool HasEnded
        {
            get { return AllPinsHaveBeenHit || BothRollsHaveBeenThrown; }
        }

        private bool AllPinsHaveBeenHit
        {
            get { return Rolls.Sum() == 10; }
        }

        public void AddRoll(int pins)
        {
            Rolls.Add(pins);
        }

        public virtual int GetScore()
        {
            if(EndsInSpare)
            {
                return Rolls.Sum() + FirstRollFromNextFrame();
            }

            return Rolls.Sum();
        }

        private int FirstRollFromNextFrame()
        {
            return GetNextFrame().FirstRoll;
        }

        protected int FirstRoll
        {
            get { return Rolls.First(); }
        }

        protected Frame GetNextFrame()
        {
            return game.GetNextFrame(this);
        }

        protected bool EndsInSpare
        {
            get { return BothRollsHaveBeenThrown && AllPinsHaveBeenHit; }
        }

        private bool BothRollsHaveBeenThrown
        {
            get { return Rolls.Count == 2; }
        }

        protected List<int> Rolls
        {
            get { return rolls; }
        }
    }
}