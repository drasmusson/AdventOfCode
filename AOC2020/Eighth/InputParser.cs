using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Eighth
{
    public static class InputParser
    {
        public static List<string> InputList = GetInput();

        private static List<string> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("EighthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return listInput;
        }
    }
}
