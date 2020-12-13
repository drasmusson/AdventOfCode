using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Twelfth
{
    public static class InputParser
    {
        public static List<(char, int)> InputList = GetInput();

        private static List<(char, int)> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("TwelfthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var parsedInput = new List<(char, int)>();

            foreach (var row in listInput)
            {
                parsedInput.Add((char.Parse(row.Substring(0, 1)), int.Parse(row.Substring(1).Trim())));
            };

            return parsedInput;
        }
    }
}
