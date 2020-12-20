using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Nineteenth
{
    public static class InputParser
    {
        public static List<Rule> InputList => GetInput();
        public static List<string> MessageList => GetMessages();

        private static List<string> GetMessages()
        {
            var stringInput = Resources.ResourceManager.GetObject("NineteenthInput") as string;
            return stringInput.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private static List<Rule> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("NineteenthInput") as string;
            var listInput = stringInput.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).First()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var ruleList = new List<Rule>();

            foreach (var row in listInput)
            {
                var id = row.Split(":").First();

                ruleList.Add(new Rule(int.Parse(id)));
            }

            foreach (var row in listInput)
            {
                var idSplit = row.Split(":");
                var id = int.Parse(idSplit.First());
                var pipeSplit = idSplit.Last().Split("|");

                var whitSpaceSplit = pipeSplit.First().Trim().Split(" ");

                foreach (var childId in whitSpaceSplit)
                {
                    var rule = ruleList.First(r => r.Id == id);
                    if (childId == "\"a\"" || childId == "\"b\"")
                    {
                        rule.Value = childId[1].ToString();
                        continue;
                    }
                    rule.ChildRules.Add(ruleList.First(r => r.Id == int.Parse(childId)));
                }
                if (pipeSplit.Length > 1)
                {
                    var whitSpaceSplit2 = pipeSplit.Last().Trim().Split(" ");

                    foreach (var childId in whitSpaceSplit2)
                    {
                        var rule = ruleList.First(r => r.Id == id);

                        rule.AlternativeChildRules.Add(ruleList.First(r => r.Id == int.Parse(childId)));
                    }
                }
            }

            return ruleList;
        }
    }
}
