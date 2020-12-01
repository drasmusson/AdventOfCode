using System.Collections.Generic;
using System.Linq;

namespace AOC2020
{
    public static class Logic
    {

        public static int First1(List<int> input)
        {
            var matches = new List<int>();

            foreach (var item in input)
            {
                foreach (var item2 in input)
                {
                    if (CheckMatch(item, item2, 2020))
                        matches.AddRange(new List<int> { item, item2 });
                }
            }

            return Multiply(matches[0], matches[1]);
        }

        public static int First2(List<int> input)
        {
            var matches = new List<int>();

            foreach (var item in input)
            {
                foreach (var item2 in input)
                {
                    foreach (var item3 in input)
                    {
                        if (CheckMatch(item, item2, item3, 2020))
                            matches.AddRange(new List<int> { item, item2, item3 });
                    }
                }
            }

            return Multiply(matches[0], matches[1], matches[2]);
        }

        public static int First2Faster(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                var currentSum = 2020 - input[i];
                var remaining = new List<int>();

                for (int j = i + 1; j < input.Count; j++)
                {
                    if (remaining.Contains(currentSum - input[j]))
                    {
                        return Multiply(input[i], input[j], currentSum - input[j]);
                    }
                    remaining.Add(input[j]);
                }
            }

            return 0;
        }

        private static bool CheckMatch(int inputOne, int inputTwo, int targetSum)
        {
            return inputOne + inputTwo == targetSum;
        }

        private static bool CheckMatch(int inputOne, int inputTwo, int inputThree, int targetSum)
        {
            return inputOne + inputTwo + inputThree == targetSum;
        }

        private static int Multiply(int inputOne, int inputTwo)
        {
            return inputOne * inputTwo;
        }

        private static int Multiply(int inputOne, int inputTwo, int inputThree)
        {
            return inputOne * inputTwo * inputThree;
        }
    }
}