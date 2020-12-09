using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Properties;

namespace Test
{
    [TestClass]
    public class Ninth
    {
        [TestMethod]
        public void First()
        {
            var stringInput = Resources.ResourceManager.GetObject("NinthTestInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var testData = listInput.Select(s => long.Parse(s)).ToList();

            Assert.AreEqual(127, AOC2020.Ninth.Logic.First(testData, 5));
        }

        [TestMethod]
        public void Second()
        {
            var stringInput = Resources.ResourceManager.GetObject("NinthTestInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var testData = listInput.Select(s => long.Parse(s)).ToList();

            Assert.AreEqual(62, AOC2020.Ninth.Logic.Second(testData, 5));
        }
    }
}
