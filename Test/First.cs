using AOC2020;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class First
    {
        [TestMethod]
        public void First1_Correct()
        {
            var input = new List<int> { 1721, 979, 366, 299, 675, 1456 };

            Assert.AreEqual(514579, Logic.First1(input));
        }

        [TestMethod]
        public void First2_Correct()
        {
            var input = new List<int> { 1721, 979, 366, 299, 675, 1456 };

            Assert.AreEqual(241861950, Logic.First2(input));
        }

        [TestMethod]
        public void First2_Performance()
        {
            var input = Input.InputList;
            var sw = new Stopwatch();
            sw.Start();
            Logic.First2(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Stop();
        }

        [TestMethod]
        public void First2Faster_Correct()
        {
            var input = new List<int> { 1721, 979, 366, 299, 675, 1456 };

            Assert.AreEqual(241861950, Logic.First2Faster(input));
        }

        [TestMethod]
        public void First2Faster_Performance()
        {
            var input = Input.InputList;
            var sw = new Stopwatch();
            sw.Start();
            Logic.First2Faster(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2Faster(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2Faster(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2Faster(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();
            Logic.First2Faster(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Stop();
        }
    }
}
