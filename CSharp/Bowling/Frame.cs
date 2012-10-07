using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Frame
    {
        private readonly Game game;

        public Frame(Game game)
        {
            this.game = game;
            Rolls = new List<int>();
        }

        protected List<int> Rolls { get; set; }

        public bool HasEnded
        {
            get { return AllPinsHaveBeenHit || BothRollsHaveBeenThrown; }
        }

        private bool AllPinsHaveBeenHit
        {
            get { return SumOfRolls() == 10; }
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
            get { return RollsCount() == 2; }
        }

        public int SumOfRolls()
        {
            return Rolls.Sum();
        }

        public void AddRoll(int pins)
        {
            Rolls.Add(pins);
        }

        public virtual int GetScore()
        {
            if(EndsInSpare)
            {
                return SumOfRolls() + game.GetScoreOfNextRoll(this);
            }
            
            if(EndsInStrike)
            {
                return SumOfRolls() + game.GetSumOfNextTwoRolls(this);
            }

            return SumOfRolls();
        }

        public int RollsCount()
        {
            return Rolls.Count();
        }
    }
}