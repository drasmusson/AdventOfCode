using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Eleventh
{
    public static class InputParser
    {
        public static List<string> InputList = GetInput();

        private static List<string> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("EleventhInput") as string;
            var listInput = stringInput.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            return listInput;
        }
    }
}
