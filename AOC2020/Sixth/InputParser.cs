using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Sixth
{
    public static class InputParser
    {
        public static List<string> InputList1 => GetInput1();
        public static List<Tuple<int, string>> InputList2 => GetInput2();

        private static List<string> GetInput1()
        {
            var stringInput = Resources.ResourceManager.GetObject("SixthInput") as string;
            var dataGroups = stringInput.Split(new string[] { Environment.NewLine + Environment.NewLine },
                               StringSplitOptions.RemoveEmptyEntries).ToList();
            

            return dataGroups.Select(x => x.Replace(Environment.NewLine, "")).ToList();
        }

        private static List<Tuple<int, string>> GetInput2()
        {
            var stringInput = Resources.ResourceManager.GetObject("SixthInput") as string;
            var dataGroups = stringInput.Split(new string[] { Environment.NewLine + Environment.NewLine },
                               StringSplitOptions.RemoveEmptyEntries).ToList();
            var input = new List<Tuple<int, string>>();

            dataGroups.ForEach(x => input.Add(new Tuple<int, string>(x.Split(Environment.NewLine).Count(), x.Replace(Environment.NewLine, ""))));

            return input;
        }
    }
}
