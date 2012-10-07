using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Frame
    {
        private readonly Game game;

        public Frame(int number, Game game)
        {
            this.Number = number;
            this.game = game;
            Rolls = new List<int>();
        }

        public int Number { get; private set; }

        protected List<int> Rolls { get; set; }

        public virtual bool HasEnded
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

        public int SecondRoll
        {
            get { return Rolls[1]; }
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
                return SumOfRolls() + game.GetNextRoll(this);
            }
            
            if(EndsInStrike)
            {
                return SumOfRolls() + game.GetNextRoll(this) + game.GetSecondNextRoll(this);
            }

            return SumOfRolls();
        }

        public int RollsCount()
        {
            return Rolls.Count();
        }
    }
}