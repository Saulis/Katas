using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game
    {
        private readonly List<int> rolls;

        public Game()
        {
            rolls = new List<int>();
        }

        public void Roll(int pins)
        {
            rolls.Add(pins);
        }

        public int GetPoints()
        {
            return rolls.Sum();
        }
    }
}
