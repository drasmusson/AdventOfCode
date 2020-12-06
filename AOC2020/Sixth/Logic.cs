using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020.Sixth
{
    public class Logic
    {
        public static int Run()
        {
            var input = InputParser.InputList1;
            var input2 = InputParser.InputList2;

            var result1 = CountDistinctAnswers(input);

            var result2 = CountEqualAnswers(input2);

            return result2;
        }

        private static int CountEqualAnswers(List<Tuple<int, string>> input2)
        {
            return input2.Select(item => CountSameAnswersInGroup(item)).Aggregate((x, y) => x + y);
        }

        private static int CountSameAnswersInGroup(Tuple<int, string> answerGroup)
        {
            var t = answerGroup.Item2.GroupBy(c => c).Select(c => c.Count());
            return t.Count(x => x == answerGroup.Item1);
        }

        private static int CountDistinctAnswers(List<string> input)
        {
            var result = input.Select(ag => ag.Distinct().Count()).Sum();

            return result;
        }
    }
}