using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Seventh
{
    public static class InputParser
    {
        public static Dictionary<string, List<string>> InputList = GetInput();
        public static Dictionary<string, List<(int, string)>> InputList2 = GetInput2();

        private static Dictionary<string, List<string>> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("SeventhInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var inputDictionary = new Dictionary<string, List<string>>();

            foreach (var row in listInput)
            {
                var parentSplit = row.Split("contain", StringSplitOptions.RemoveEmptyEntries);

                var childSplit = parentSplit.Last().Split(',');

                var children = new List<string>();
                foreach (var c in childSplit)
                {
                    //var pFrom = c.IndexOf(" ") + " ".Length;
                    var pTo = c.LastIndexOf("bag");

                    children.Add(c.Substring(3, pTo - 3).Trim());
                }

                inputDictionary.Add(parentSplit.First().Split("bag").First().Trim(), children);
            };

            return inputDictionary;
        }

        private static Dictionary<string, List<(int, string)>> GetInput2()
        {
            var stringInput = Resources.ResourceManager.GetObject("SeventhInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var inputDictionary = new Dictionary<string, List<(int, string)>>();

            foreach (var row in listInput)
            {
                var parentSplit = row.Split("contain", StringSplitOptions.RemoveEmptyEntries);

                var childSplit = parentSplit.Last().Split(',');

                var children = new List<(int, string)>();
                foreach (var c in childSplit)
                {
                    if (c.Contains("no other bags"))
                        continue;

                    var pTo = c.LastIndexOf("bag");

                    children.Add((int.Parse(c.Substring(0, 3).Trim()), c.Substring(3, pTo - 3).Trim()));
                }

                inputDictionary.Add(parentSplit.First().Split("bag").First().Trim(), children);
            };

            return inputDictionary;
        }
    }
}
