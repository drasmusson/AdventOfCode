using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Fourth
{
    public static class Input
    {
        public static List<List<string>> InputList => GetInput();

        private static List<List<string>> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("FourthInput") as string;
            var passportDataGroups = stringInput.Split(new string[] { Environment.NewLine + Environment.NewLine },
                               StringSplitOptions.RemoveEmptyEntries).ToList();

            var listOfPassportData = new List<List<string>>();

            foreach (var line in passportDataGroups)
            {
                var passportData = new List<string>();
                var split = line.Split("\r");
                foreach (var p in split)
                {
                    var o = p.Split("\n", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var a in o)
                    {
                        var t = a.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        passportData.AddRange(t);
                    }
                }

                listOfPassportData.Add(passportData);
            }

            return listOfPassportData;
        }
    }
}
