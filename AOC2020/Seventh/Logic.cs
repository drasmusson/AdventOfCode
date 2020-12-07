using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AOC2020.Seventh
{
    public static class Logic
    {
        public static int Run()
        {
            var input2 = InputParser.InputList2;
            var result1 = First(input2);
            //var result2 = Second(input2);
            return result1;
        }

        private static int Second(Dictionary<string, List<(int, string)>> input)
        {
            List<Bag> bags = GetBagsFromInput(input);

            var goldenBag = bags.First(b => b.Color == "shiny gold");
            return goldenBag.ChildCount();
        }

        private static int First(Dictionary<string, List<(int, string)>> input)
        {
            List<Bag> bags = GetBagsFromInput(input);

            var goldenBag = bags.First(b => b.Color == "shiny gold");

            return goldenBag.AncestorCount();
        }

        private static List<Bag> GetBagsFromInput(Dictionary<string, List<(int, string)>> input)
        {
            var bags = new List<Bag>();
            foreach (var bagColors in input)
            {
                bags.Add(new Bag { Color = bagColors.Key, Children = new List<(int, Bag)>(), Parents = new List<Bag>() });
            }
            foreach (var bag in bags)
            {
                var childList = new List<(int, Bag)>();

                var childInput = input.First(x => x.Key == bag.Color).Value;
                childInput.ForEach(ci => childList.Add((ci.Item1, bags.First(b => b.Color == ci.Item2))));
                bag.Children.AddRange(childList);

                var parentList = new List<Bag>();

                var parentInput = input.Where(i => i.Value.Any(v => v.Item2 == bag.Color)).Select(x => x.Key);
                parentList.AddRange(bags.Where(b => parentInput.Any(p => p == b.Color)));
                bag.Parents.AddRange(parentList);
            }

            return bags;
        }

        private static int GetParentCount(string currentBag, int currentCount, Dictionary<string, List<string>> input)
        {
            input.Remove(currentBag);

            if (input.Count == 0)
                return currentCount;

            var parents = input.Where(x => x.Value.Contains(currentBag));

            currentCount += parents.Count();

            foreach (var child in parents)
            {
                currentCount += GetParentCount(child.Key, currentCount, input);
            }

            return currentCount;
        }

        private class Bag
        {
            public string Color { get; set; }
            public List<(int, Bag)> Children { get; set; }
            public List<Bag> Parents { get; set; }
            public HashSet<Bag> Ancestors() => Parents.SelectMany(p => p.Ancestors().Concat(new[] { p })).ToHashSet();
            public int AncestorCount() => Ancestors().Count;
            public int ChildCount() => Children.Sum(c => c.Item1 + c.Item1 * c.Item2.ChildCount());
        }
    }
}
