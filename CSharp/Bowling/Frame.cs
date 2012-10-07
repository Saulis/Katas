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
            rolls.Add(pins);
        }

        public virtual int GetScore()
        {
            if(EndsInSpare)
            {
                return Rolls.Sum() + game.GetScoreOfNextRoll(this);
            }
            
            if(EndsInStrike)
            {
                return Rolls.Sum() + game.GetSumOfNextTwoRolls(this);
            }

            return Rolls.Sum();
        }

        protected bool EndsInStrike
        {
            get { return AllPinsHaveBeenHit && !BothRollsHaveBeenThrown; }
        }

        public int FirstRoll
        {
            get { return Rolls.First(); }
        }

        protected bool EndsInSpare
        {
            get { return BothRollsHaveBeenThrown && AllPinsHaveBeenHit; }
        }

        private bool BothRollsHaveBeenThrown
        {
            get { return Rolls.Count() == 2; }
        }

        public IEnumerable<int> Rolls
        {
            get { return rolls; }
        }
    }
}