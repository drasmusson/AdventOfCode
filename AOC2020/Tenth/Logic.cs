using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace AOC2020.Tenth
{
    public static class Logic
    {
        public static long Run()
        {
            var input = InputParser.InputList;

            //var result1 = First(input);
            var result2 = Second(input);

            return result2;
        }

        private static long First(List<int> input)
        {
            input.Sort();

            var oneJolts = input[0];
            var threeJolts = 1;

            for (int i = 0; i < input.Count - 1; i++)
            {
                var current = input[i];
                var next = input[i + 1];

                switch (next - current)
                {
                    case 1:
                        oneJolts++;
                        break;

                    case 3:
                        threeJolts++;
                        break;
                    
                    default:
                        break;
                }
            }

            return oneJolts * threeJolts;
        }

        public static long Second(List<int> input)
        {
            input.Add(0);
            input.Sort();
            input.Add(input.Last() + 3);

            var joltMap = new (int, long)[input.Last() + 1];
            input.ForEach(i => joltMap[i] = (1, 0));
            joltMap[joltMap.Length - 1] = (1, 1);

            for (int i = joltMap.Length - 1; i > 0; i--)
            {
                if (joltMap[i].Item1 == 0)
                    continue;

                if (joltMap.ElementAtOrDefault(i - 1).Item1 != 0)
                {
                    joltMap[i - 1].Item2 += joltMap[i].Item2;
                }

                if (joltMap.ElementAtOrDefault(i - 2).Item1 != 0)
                {
                    joltMap[i - 2].Item2 += joltMap[i].Item2;
                }

                if (joltMap.ElementAtOrDefault(i - 3).Item1 != 0)
                {
                    joltMap[i - 3].Item2 += joltMap[i].Item2;
                }
            }
            long result = joltMap[0].Item2;
            return result;
        }
    }
}
