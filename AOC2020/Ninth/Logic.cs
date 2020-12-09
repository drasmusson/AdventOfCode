using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Ninth
{
    public static class Logic
    {
        public static long Run()
        {
            var input = InputParser.InputList;
            long result2 = Second(input, 25);

            return result2;
        }

        public static long Second(List<long> input, int numberOfPreamblesToSearchIn)
        {
            var preambles = ParseToPreabmles(input);

            var result1 = FindTheWrongPreamble(preambles, numberOfPreamblesToSearchIn);
            var result2 = IndexesForLongestRangeAddingToNumber(preambles, result1);
            return result2.Item1 + result2.Item2;
        }

        private static (long, long) IndexesForLongestRangeAddingToNumber(List<Preamble> preambles, long numberToSearchFor)
        {
            var longestRangeSize = 0;
            (long, long)longestRange = (0, 0);

            var currentRangeSize = 2;

            var iterator = 0;
            do
            {
                var currentRange = preambles.GetRange(iterator, currentRangeSize).Select(p => p.Value).ToList();
                if (currentRange.Sum() == numberToSearchFor && currentRangeSize > longestRangeSize)
                {
                    longestRangeSize = currentRangeSize;
                    longestRange = (currentRange.Min(), currentRange.Max());
                }
                if ((iterator + currentRangeSize) >= preambles.Count)
                {
                    iterator = 0;
                    currentRangeSize++;
                } else
                {
                    iterator++;
                }
            } while (currentRangeSize < preambles.Count);

            return longestRange;
        }

        public static long First(List<long> input, int numberOfPreamblesToSearchIn)
        {
            var preambles = ParseToPreabmles(input);

            var result1 = FindTheWrongPreamble(preambles, numberOfPreamblesToSearchIn);
            return result1;
        }

        private static long FindTheWrongPreamble(List<Preamble> preambles, int numberOfPreamblesToSearchIn)
        {
            for (int i = 0; i < preambles.Count; i++)
            {
                var currentPreamblesToSearchIn = preambles.GetRange(i, numberOfPreamblesToSearchIn);
                var preambleUnderControll = preambles[i + numberOfPreamblesToSearchIn];

                var parents = preambleUnderControll.FindMyParentsInThesePreambles(currentPreamblesToSearchIn);
                if (parents is null)
                    return preambleUnderControll.Value;

            }

            return 0;
        }

        private static List<Preamble> ParseToPreabmles(List<long> input)
        {
            return input.Select(i => new Preamble { Value = i }).ToList();
        }

        private class Preamble
        {
            public long Value { get; set; }

            public (Preamble, Preamble)? FindMyParentsInThesePreambles(List<Preamble> preambles)
            {
                for (int i = 0; i < preambles.Count; i++)
                {
                    for (int j = 0; j < preambles.Count; j++)
                    {
                        if (i != j)
                        {
                            long sum = preambles[i].Value + preambles[j].Value;
                            if (sum == Value)
                            {
                                return (preambles[i], preambles[j]);
                            }
                        }
                    }
                }
                return null;
            }
        }
    }

}
