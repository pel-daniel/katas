using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameKata
{
    [TestClass]
    public class BowlingGameTest
    {
        [TestMethod]
        public void TestGutterGame()
        {
            var g = new Game();
            for (var i = 0; i < 20; i++)
                g.Roll(0);
            Assert.AreEqual(0, g.Score());
        }
            
    }
}
