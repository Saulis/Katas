﻿using NUnit.Framework;

namespace Bowling
{
    class GameTests
    {
        private Game sut;

        [SetUp]
        public void Setup()
        {
            sut = new Game();
        }

        [Test]
        public void GutterGame()
        {
            RollTimes(20, 0);

            Assert.That(sut.GetPoints(), Is.EqualTo(0));
        }

        private void RollTimes(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                sut.Roll(pins);
            }
        }

        [Test]
        public void OnesGame()
        {
            RollTimes(20, 1);

            Assert.That(sut.GetPoints(), Is.EqualTo(20));
        }

        [Test]
        public void SpareGame()
        {
            sut.Roll(5);
            sut.Roll(5);
            sut.Roll(3);
            RollTimes(17, 0);

            Assert.That(sut.GetPoints(), Is.EqualTo(16));
        }
    }
}
