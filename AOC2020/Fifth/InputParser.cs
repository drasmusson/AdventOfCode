using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Fifth
{
    public static class InputParser
    {
        public static List<string> InputList = GetInput();

        private static List<string> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("FifthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return listInput.ToList();
        }
    }
}