using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Tenth
{
    public static class InputParser
    {
        public static List<int> InputList = GetInput();

        private static List<int> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("TenthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var intList = listInput.Select(s => int.Parse(s));
            return intList.ToList();
        }
    }
}
