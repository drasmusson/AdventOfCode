using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2020.Third
{
    public class Logic
    {
        public static int Run()
        {
            var input = Third.Input.InputList;

            var treeCount = Third2(input);

            return treeCount;
        }

        public static int Third1(List<string> input)
        {
            return GetTreeCount(input, 3, 1);
        }

        public static int GetTreeCount(List<string> input, int stepX, int stepY)
        {
            var height = input.Count;
            var width = input[0].Length;

            var treeCount = 0;

            var x = 0;
            var y = 0;

            while(y < height)
            {
                if (input[y][x] == '#')
                    treeCount++;


                x += stepX;
                if (x > width - 1)
                {
                    x -= width;
                }

                y += stepY;
            }

            return treeCount;
        }

        public static int Third2(List<string> input)
        {
            var stepData = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2),
            };

            var result = 1;

            foreach (var step in stepData)
            {
                result = result * GetTreeCount(input, step.Item1, step.Item2);
            }

            return result;
        }
    }
}
