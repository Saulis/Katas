using System.Linq;

namespace Bowling
{
    public class TenthFrame : Frame
    {
        public TenthFrame(int number, Game game) : base(number, game)
        {
        }

        public override int GetScore()
        {
            return Rolls.Sum();
        }

        public override bool HasEnded
        {
            get { return false; }
        }
    }
}