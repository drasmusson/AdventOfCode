using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Nineteenth
{
    public static class Logic
    {
        public static List<string> Rule31PossibleStrings;
        public static List<string> Rule42PossibleStrings;

        public static int Run()
        {
            var input = InputParser.InputList;

            //var result1 = First(input);
            var result2 = Second(input);

            return result2;
        }

        private static int First(List<Rule> input)
        {
            var rule = input.First(r => r.Id == 0);

            rule.GetPossibleStrings();
            var possibleStrings = rule.PossibleStrings;
            var messages = InputParser.MessageList;

            var result = messages.Intersect(possibleStrings).Count();

            return result;
        }

        private static int Second(List<Rule> input)
        {
            var rule42 = input.First(r => r.Id == 42);
            var rule31 = input.First(r => r.Id == 31);

            rule42.GetPossibleStrings();
            rule31.GetPossibleStrings();

            Rule31PossibleStrings = rule31.PossibleStrings;
            Rule42PossibleStrings = rule42.PossibleStrings;

            var messages = InputParser.MessageList;

            var validCounter = 0;
            foreach (var message in messages)
            {
                if (message.Count() % 8 == 0)
                {
                    var chunks = SplitMessageInParts(message);

                    if (Validate(chunks))
                        validCounter++;
                }
            }

            return validCounter;
        }

        private static bool Validate(List<string> chunks)
        {
            if (Rule42PossibleStrings.Contains(chunks.First()) && Rule42PossibleStrings.Contains(chunks[1]) && Rule31PossibleStrings.Contains(chunks.Last()))
            {
                var count42 = 0;
                var count31 = 0;

                foreach (var chunk in chunks)
                {
                    if (Rule42PossibleStrings.Contains(chunk) && count31 == 0)
                    {
                        count42++;
                        continue;
                    }

                    if (Rule31PossibleStrings.Contains(chunk))
                    {
                        count31++;
                        continue;
                    }
                    return false;
                }
                return count31 < count42;
            }
            return false;
        }

        private static List<string> SplitMessageInParts(string message)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (i != 0 && i % 8 == 0)
                    sb.Append(' ');
                sb.Append(message[i]);
            }
            string formatted = sb.ToString();
            return formatted.Split(" ").ToList();
        }
    }
    public class Rule
    {
        public int Id { get; set; }
        public List<Rule> ChildRules { get; set; }
        public List<Rule> AlternativeChildRules { get; set; }
        public string Value { get; set; }
        public List<string> PossibleStrings { get; set; }

        public Rule(int id)
        {
            Id = id;
            ChildRules = new List<Rule>();
            AlternativeChildRules = new List<Rule>();
            Value = null;
            PossibleStrings = new List<string>();
        }

        public void GetPossibleStrings()
        {
            if (!PossibleStrings.Any() && !string.IsNullOrEmpty(Value))
            {
                PossibleStrings.Add(Value);
                return;
            }
            else if (PossibleStrings.Any())
            {
                return;
            }

            ChildRules.ForEach(cr => cr.GetPossibleStrings());
            AlternativeChildRules.ForEach(cr => cr.GetPossibleStrings());

            if (ChildRules.Count == 1 && ChildRules.First().PossibleStrings.Any())
            {
                foreach (var fc in ChildRules.Last().PossibleStrings)
                {
                    PossibleStrings.Add(fc);
                }
            }

            if (ChildRules.Count == 2)
            {
                if (ChildRules.First().PossibleStrings.Any() && ChildRules.Last().PossibleStrings.Any())
                {
                    foreach (var fc in ChildRules.First().PossibleStrings)
                    {
                        foreach (var sc in ChildRules.Last().PossibleStrings)
                        {
                            PossibleStrings.Add(fc + sc);
                        }
                    }
                }
            }

            if (AlternativeChildRules.Count == 1 && AlternativeChildRules.First().PossibleStrings.Any())
            {
                foreach (var fc in AlternativeChildRules.Last().PossibleStrings)
                {
                    PossibleStrings.Add(fc);
                }
            }

            if (AlternativeChildRules.Count == 2)
            {
                if (AlternativeChildRules.First().PossibleStrings.Any() && AlternativeChildRules.Last().PossibleStrings.Any())
                {
                    foreach (var fc in AlternativeChildRules.First().PossibleStrings)
                    {
                        foreach (var sc in AlternativeChildRules.Last().PossibleStrings)
                        {
                            PossibleStrings.Add(fc + sc);
                        }
                    }
                }
            }
        }
    }
}
