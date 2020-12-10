using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Properties;

namespace Test
{
    [TestClass]
    public class Tenth
    {
        [TestMethod]
        public void Second()
        {
            var stringInput = Resources.ResourceManager.GetObject("TenthTestInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var intList = listInput.Select(s => int.Parse(s));

            var result = AOC2020.Tenth.Logic.Second(intList.ToList());

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Second2()
        {
            var stringInput = Resources.ResourceManager.GetObject("TenthTestInput2") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var intList = listInput.Select(s => int.Parse(s));

            var result = AOC2020.Tenth.Logic.Second(intList.ToList());

            Assert.AreEqual(19208, result);
        }
    }
}
