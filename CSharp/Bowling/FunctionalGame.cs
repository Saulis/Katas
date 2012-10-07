using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class FunctionalGame : IGame
    {
        protected List<int> Rolls { get; set; }

        public FunctionalGame()
        {
            Rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            Rolls.Add(pins);
        }

        public int GetScore()
        {
            return SumRolls(Rolls);
        }

        private int SumRolls(IEnumerable<int> rolls, int frame = 1)
        {
            if (rolls.Any())
            {
                if(TenthFrame(frame))
                {
                    return rolls.Sum();
                }

                if(FrameEndsInSpare(rolls))
                {
                    return NextThree(rolls).Sum() + SumRolls(rolls.Skip(2), frame + 1);
                }

                if(FrameEndsInStrike(rolls))
                {
                    return NextThree(rolls).Sum() + SumRolls(rolls.Skip(1), frame + 1);
                }

                return rolls.First() + SumRolls(rolls.Skip(1), frame + 1);
            }

            return 0;
        }

        private bool TenthFrame(int frame)
        {
            return frame == 10;
        }

        private IEnumerable<int> NextThree(IEnumerable<int> rolls)
        {
            return rolls.Take(3);
        }

        private IEnumerable<int> NextTwo(IEnumerable<int> rolls)
        {
            return rolls.Take(2);
        }

        private bool FrameEndsInStrike(IEnumerable<int> rolls)
        {
            return rolls.First() == 10;
        }

        private bool FrameEndsInSpare(IEnumerable<int> rolls)
        {
            return !FrameEndsInStrike(rolls) && NextTwo(rolls).Sum() == 10;
        }
    }
}