using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Thirteenth
{
    public static class InputParser
    {
        public static (int, List<int>) InputList = GetInput();
        public static List<string> InputList2 = GetInput2();

        private static (int, List<int>) GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("ThirteenthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var input = (int.Parse(listInput.First()), new List<int>());

            foreach (var i in listInput.Last().Split(','))
            {
                if (int.TryParse(i, out int outInt))
                    input.Item2.Add(outInt);
            }

            return input;
        }


        private static List<string> GetInput2()
        {
            var stringInput = Resources.ResourceManager.GetObject("ThirteenthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return listInput.Last().Split(',').ToList();
        }
    }
}
