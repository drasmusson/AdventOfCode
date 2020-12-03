using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Test
{
    [TestClass]
    public class Second
    {
        [TestMethod]
        public void Second1_Correct()
        {
            var input = new List<string> { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            var count = AOC2020.Second.Logic.Run1(input);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Second1_Performance()
        {
            var sw = new Stopwatch();
            sw.Start();
            AOC2020.Second.Logic.Run1();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run1();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run1();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run1();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run1();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Stop();
        }


        [TestMethod]
        public void Second2_Correct()
        {
            var input = new List<string> { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" };

            var count = AOC2020.Second.Logic.Run2(input);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Second2_Performance()
        {
            var sw = new Stopwatch();
            sw.Start();
            AOC2020.Second.Logic.Run2();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run2();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run2();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run2();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            AOC2020.Second.Logic.Run2();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            sw.Stop();
        }
    }
}
