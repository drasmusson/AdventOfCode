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

        private static Dictionary<string, List<string>> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("SeventhInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var inputDictionary = new Dictionary<string, List<string>>();

            foreach (var row in listInput)
            {
                var parensplit = row.Split("contain", StringSplitOptions.RemoveEmptyEntries);

                var childSplit = parensplit.Last().Split(',');

                var children = new List<string>();
                foreach (var c in childSplit)
                {
                    //var pFrom = c.IndexOf(" ") + " ".Length;
                    var pTo = c.LastIndexOf("bag");

                    children.Add(c.Substring(3, pTo - 3).Trim());
                }

                inputDictionary.Add(parensplit.First().Split("bag").First().Trim(), children);
            };

            return inputDictionary;
        }
    }
}
