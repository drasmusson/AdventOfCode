using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AOC2020
{
    public static class InputParser
    {
        public static List<int> InputList = GetInput();

        private static List<int> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("Data") as string;
            var listInput = stringInput.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            return listInput.Select(x => int.Parse(x)).ToList();
        }
    }
}
