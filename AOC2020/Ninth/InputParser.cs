using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Ninth
{
    public static class InputParser
    {
        public static List<long> InputList = GetInput();

        private static List<long> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("NinthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var intList = listInput.Select(s => long.Parse(s));
            return intList.ToList();
        }
    }
}
