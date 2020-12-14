using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Fourteenth
{
    public static class Logic
    {
        public static long Run()
        {
            var input = InputParser.InputList;

            var result1 = First(input);
            var result2 = Second(input);

            return result2;
        }

        private static long First(List<(string mask, List<ProgramInput> inputs)> input)
        {
            var memoryList = new Dictionary<int, long>();

            foreach (var chunk in input)
            {
                foreach (var pi in chunk.inputs)
                {
                    var newValue = ApplyMask(chunk.mask, pi);
                    if (memoryList.ContainsKey(pi.MemoryPosition))
                    {
                        memoryList[pi.MemoryPosition] = newValue;
                    }
                    else
                    {
                        memoryList.Add(pi.MemoryPosition, newValue);
                    }
                }
            }

            return memoryList.Values.Sum();
        }

        private static long Second(List<(string mask, List<ProgramInput> inputs)> input)
        {
            var memoryList = new Dictionary<int, long>();

            foreach (var chunk in input)
            {
                foreach (var pi in chunk.inputs)
                {
                    var newMemoryPosition = ApplyMask2(chunk.mask, pi);
                    if (memoryList.ContainsKey(pi.MemoryPosition))
                    {
                        memoryList[pi.MemoryPosition] = newMemoryPosition;
                    }
                    else
                    {
                        memoryList.Add(pi.MemoryPosition, newMemoryPosition);
                    }
                }
            }

            return memoryList.Values.Sum();
        }

        private static long ApplyMask(string mask, ProgramInput pi)
        {
            var binaryValue = Convert.ToString(pi.Value, 2).PadLeft(36, '0');

            for (int i = 0; i < mask.Length; i++)
            {
                var maskChar = mask[i];
                if (maskChar != 'X')
                {
                    var sb = new StringBuilder(binaryValue);
                    sb[i] = maskChar;
                    binaryValue = sb.ToString();
                }
            }

            return Convert.ToInt64(binaryValue, 2);
        }

        private static long ApplyMask2(string mask, ProgramInput pi)
        {
            var binaryValue = Convert.ToString(pi.MemoryPosition, 2).PadLeft(36, '0');

            var xCount = 0;
            var xIndexes = new List<int>();

            for (int i = 0; i < mask.Length; i++)
            {
                var maskChar = mask[i];
                if (maskChar != '0')
                {
                    if (maskChar == 'X')
                    {
                        xCount++;
                        xIndexes.Add(i);
                    }
                    var sb = new StringBuilder(binaryValue);
                    sb[i] = maskChar;
                    binaryValue = sb.ToString();
                }
            }
            int[] arr = new int[xCount];
            var combinations = new List<string>();
            combinations = Generate(xCount, arr, 0, combinations);

            var memoryPositions = new List<long>();
            foreach (var c in combinations)
            {
                // Find memory position by replacing X in binaryValue with corresponding bit from combination

            }

            return Convert.ToInt64(binaryValue, 2);
        }

        static List<string> Generate(int n, int[] arr, int i, List<string> combinations)
        {
            if (i == n)
            {
                var s = string.Join("", arr);
                combinations.Add(s);
                return combinations;
            }

            // First assign "0" at ith position 
            // and try for all other permutations 
            // for remaining positions 
            arr[i] = 0;
            combinations = Generate(n, arr, i + 1, combinations);

            // And then assign "1" at ith position 
            // and try for all other permutations 
            // for remaining positions 
            arr[i] = 1;
            combinations = Generate(n, arr, i + 1, combinations);

            return combinations;
        }

    }
}
