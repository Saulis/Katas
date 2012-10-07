namespace Bowling
{
    public interface IGame
    {
        void Roll(int pins);
        int GetScore();
    }
}