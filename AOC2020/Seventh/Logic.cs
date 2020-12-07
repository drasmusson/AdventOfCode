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
            var input = InputParser.InputList;

            var result1 = First(input);
            var result2 = Second(input);
            return result2;
        }

        private static int Second(Dictionary<string, List<string>> input)
        {
            List<Bag> bags = GetBagsFromInput(input);

            var goldenBag = bags.First(b => b.Color == "shiny gold");
            return goldenBag.ChildCount();
        }

        private static int First(Dictionary<string, List<string>> input)
        {
            List<Bag> bags = GetBagsFromInput(input);

            var goldenBag = bags.First(b => b.Color == "shiny gold");

            return goldenBag.AncestorCount();
        }

        private static List<Bag> GetBagsFromInput(Dictionary<string, List<string>> input)
        {
            var bags = new List<Bag>();
            foreach (var bagColors in input)
            {
                var children = new List<Bag>();
                bagColors.Value.ForEach(x => children.Add(new Bag { Color = x }));

                var parents = new List<Bag>();
                input.Where(x => x.Value.Contains(bagColors.Key)).ToList().ForEach(y => parents.Add(new Bag { Color = y.Key }));
                bags.Add(new Bag { Color = bagColors.Key, Children = children, Parents = new List<Bag>() });
            }
            foreach (var bag in bags)
            {
                bag.Parents.AddRange(bags.Where(b => b.Children.Any(c => c.Color == bag.Color)));
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
            public List<Bag> Children { get; set; }
            public List<Bag> Parents { get; set; }
            public HashSet<Bag> Ancestors() => Parents.SelectMany(p => p.Ancestors().Concat(new[] { p })).ToHashSet();
            public int AncestorCount() => Ancestors().Count;
            public int ChildCount() => Children.Count + Children.Sum(c => c.ChildCount());
        }
    }
}
