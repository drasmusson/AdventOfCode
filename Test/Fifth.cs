using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    public class Fifth
    {
        [TestMethod]
        public void FifthCorrect1()
        {
            var input = "BFFFBBFRRR";

            var result = AOC2020.Fifth.Logic.GetMeMySeat(input);
            Assert.AreEqual(70, result.Item1);
            Assert.AreEqual(7, result.Item2);
        }

        [TestMethod]
        public void FifthCorrect2()
        {
            var input = "FFFBBBFRRR";

            var result = AOC2020.Fifth.Logic.GetMeMySeat(input);
            Assert.AreEqual(14, result.Item1);
            Assert.AreEqual(7, result.Item2);
        }

        [TestMethod]
        public void FifthCorrect3()
        {
            var input = "BBFFBBFRLL";

            var result = AOC2020.Fifth.Logic.GetMeMySeat(input);
            Assert.AreEqual(102, result.Item1);
            Assert.AreEqual(4, result.Item2);
        }
    }
}
