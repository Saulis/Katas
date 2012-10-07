using System;
using NUnit.Framework;

namespace Bowling
{
    class GameTests : IGameTests<Game>
    {
        
    }

    class FunctionalGameTests : IGameTests<FunctionalGame>
    {
         
    }

    abstract class IGameTests<TGame> where TGame: IGame
    {
        private TGame sut;

        [SetUp]
        public void Setup()
        {
            sut = Activator.CreateInstance<TGame>();
        }

        private void RollTimes(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                sut.Roll(pins);
            }
        }

        [Test]
        public void GutterGame()
        {
            RollTimes(20, 0);

            Assert.That(sut.GetScore(), Is.EqualTo(0));
        }

        [Test]
        public void OnesGame()
        {
            RollTimes(20, 1);

            Assert.That(sut.GetScore(), Is.EqualTo(20));
        }

        [Test]
        public void SpareGame()
        {
            sut.Roll(5);
            sut.Roll(5);
            sut.Roll(3);
            RollTimes(17, 0);

            Assert.That(sut.GetScore(), Is.EqualTo(16));
        }

        [Test]
        public void StrikeGame()
        {
            sut.Roll(10);
            sut.Roll(3);
            sut.Roll(4);
            RollTimes(16, 0);

            Assert.That(sut.GetScore(), Is.EqualTo(24));
        }

        [Test]
        public void PerfectGame()
        {
            RollTimes(12, 10);

            Assert.That(sut.GetScore(), Is.EqualTo(300));
        }

        [Test]
        public void AlmostPerfectGame()
        {
            RollTimes(9, 10);
            sut.Roll(5);
            sut.Roll(5);

            Assert.That(sut.GetScore(), Is.EqualTo(265));
        }

        [Test]
        public void LastMomentFailGame()
        {
            RollTimes(10, 10);
            sut.Roll(5);
            sut.Roll(5);

            Assert.That(sut.GetScore(), Is.EqualTo(285));
        }
    }
}
