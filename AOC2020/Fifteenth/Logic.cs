using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Fifteenth
{
    public static class Logic
    {
        public static int Run()
        {
            var input = InputParser.InputList;

            var result1 = First(input);
            var result2 = Second(input);
            return result1;
        }

        private static int First(List<int> input)
        {
            var round = input.Count();
            (int number, int round) mostRecentlySpoken = (input.Last(), round);
            input.RemoveAt(input.Count - 1);

            Dictionary<int, int> spokenNumbersWithIndexes = SetupSpokenNumbersDictionary(input);

            do
            {
                if (spokenNumbersWithIndexes.TryGetValue(mostRecentlySpoken.number, out int lastRound))
                {
                    spokenNumbersWithIndexes[mostRecentlySpoken.number] = round;
                    mostRecentlySpoken = (round - lastRound, round + 1);
                }
                else
                {
                    spokenNumbersWithIndexes.Add(mostRecentlySpoken.number, mostRecentlySpoken.round);
                    mostRecentlySpoken = (0, round + 1);
                }
                round++;
            } while (round < 2020);

            return mostRecentlySpoken.number;
        }

        private static int Second(List<int> input)
        {
            var round = input.Count();
            (int number, int round) mostRecentlySpoken = (input.Last(), round);
            input.RemoveAt(input.Count - 1);

            Dictionary<int, int> spokenNumbersWithIndexes = SetupSpokenNumbersDictionary(input);

            do
            {
                if (spokenNumbersWithIndexes.TryGetValue(mostRecentlySpoken.number, out int lastRound))
                {
                    spokenNumbersWithIndexes[mostRecentlySpoken.number] = round;
                    mostRecentlySpoken = (round - lastRound, round + 1);
                }
                else
                {
                    spokenNumbersWithIndexes.Add(mostRecentlySpoken.number, mostRecentlySpoken.round);
                    mostRecentlySpoken = (0, round + 1);
                }
                round++;
            } while (round < 30000000);

            return mostRecentlySpoken.number;
        }

        private static Dictionary<int, int> SetupSpokenNumbersDictionary(List<int> input)
        {
            var spokenNumbersWithIndexes = new Dictionary<int, int>();
            for (int i = 0; i < input.Count(); i++)
            {
                spokenNumbersWithIndexes.Add(input[i], i + 1);
            }

            return spokenNumbersWithIndexes;
        }
    }
}
