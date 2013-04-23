using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameKata
{
    [TestClass]
    public class BowlingGameTest
    {
        Game g;

        [TestInitialize]
        public void SetUp()
        {
            g = new Game();
        }

        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
                g.Roll(pins);
        }

        [TestMethod]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void TestOneSpareWithZeros()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);

            Assert.AreEqual(16, g.Score());
        }

        [TestMethod]
        public void TestOneSpareWithOnes()
        {
            RollSpare();
            RollMany(18, 1);

            Assert.AreEqual(29, g.Score());
        }

        [TestMethod]
        public void TestSpareInLastRow()
        {
            RollMany(18, 1);
            RollSpare();
            RollMany(1, 1);

            Assert.AreEqual(29, g.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);

            Assert.AreEqual(24, g.Score());
        }

        [TestMethod]
        public void TestOneStrikeWithOnes()
        {
            RollStrike();
            RollMany(18, 1);

            Assert.AreEqual(30, g.Score());
        }

        [TestMethod]
        public void TestStrikeInLastRow()
        {
            RollMany(18, 1);
            RollStrike();
            RollMany(2, 1);

            Assert.AreEqual(30, g.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);

            Assert.AreEqual(300, g.Score());
        }

        [TestMethod]
        public void TestAllNines()
        {
            RollMany(10, 9);

            Assert.AreEqual(90, g.Score());
        }

        [TestMethod]
        public void TestAllFives()
        {
            RollMany(21, 5);

            Assert.AreEqual(150, g.Score());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
