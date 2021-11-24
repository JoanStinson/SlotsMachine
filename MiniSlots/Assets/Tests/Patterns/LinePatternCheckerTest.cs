using JGM.Game.Patterns;
using JGM.Game.Rollers;
using NUnit.Framework;
using System.Collections.Generic;

namespace JGM.GameTests.Patterns
{
    public class LinePatternCheckerTest
    {
        private LinePatternChecker _linePatternChecker;

        [OneTimeSetUp]
        public void SetUp()
        {
            _linePatternChecker = new LinePatternChecker();
        }

        [Test]
        public void GetResult_ThreeConsecutiveLemons_Returns3ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Lemon, (int)RollerItemType.Lemon, (int)RollerItemType.Lemon, (int)RollerItemType.Bell, (int)RollerItemType.Watermelon };
            var lemonsResult = _linePatternChecker.GetResultFromLine(list);
            Assert.AreEqual(3, lemonsResult.ItemCount);
        }

        [Test]
        public void GetResult_FourConsecutiveLemons_Returns4ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Bell, (int)RollerItemType.Bell, (int)RollerItemType.Bell, (int)RollerItemType.Bell, (int)RollerItemType.Cherries };
            var bellsResult = _linePatternChecker.GetResultFromLine(list);
            Assert.AreEqual(4, bellsResult.ItemCount);
        }

        [Test]
        public void GetResult_TwoConsecutiveCherries_Returns2ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Cherries, (int)RollerItemType.Cherries, (int)RollerItemType.Bell, (int)RollerItemType.Bell, (int)RollerItemType.Bell };
            var cherriesResult = _linePatternChecker.GetResultFromLine(list);
            Assert.AreEqual(2, cherriesResult.ItemCount);
        }

        [Test]
        public void GetResult_FiveConsecutivePlums_Returns5ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Plums, (int)RollerItemType.Plums, (int)RollerItemType.Plums, (int)RollerItemType.Plums, (int)RollerItemType.Plums };
            var grapesResult = _linePatternChecker.GetResultFromLine(list);
            Assert.AreEqual(5, grapesResult.ItemCount);
        }

        [Test]
        public void GetResult_2Lemons1Bell2Lemons_Returns2ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Lemon, (int)RollerItemType.Lemon, (int)RollerItemType.Bell, (int)RollerItemType.Lemon, (int)RollerItemType.Lemon };
            var plumsResult = _linePatternChecker.GetResultFromLine(list);
            Assert.AreEqual(2, plumsResult.ItemCount);
        }

        [Test]
        public void GetResult_ZeroConsecutiveItems_Returns1ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Lemon, (int)RollerItemType.Watermelon, (int)RollerItemType.Bell, (int)RollerItemType.Plums, (int)RollerItemType.Orange };
            var plumsResult = _linePatternChecker.GetResultFromLine(list);
            Assert.AreEqual(1, plumsResult.ItemCount);
        }
    }
}