using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Third
{
    public static class Input
    {
        public static List<string> InputList = GetInput();

        private static List<string> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("ThirdInput") as string;
            var listInput = stringInput.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            return listInput;
        }
    }
}
