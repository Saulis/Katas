using System.Linq;

namespace Bowling
{
    public class TenthFrame : Frame
    {
        public TenthFrame(Game game) : base(game)
        {
        }

        public override int GetScore()
        {
            return Rolls.Sum();
        }
    }
}