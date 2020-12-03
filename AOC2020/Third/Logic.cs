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
            var map = new SlopeMap(input);

            return GetTreeCount(map, 3, 1);
        }

        public static int Third2(List<string> input)
        {
            var map = new SlopeMap(input);

            var instructions = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2),
            };

            var result = 1;

            foreach (var instruction in instructions)
            {
                result = result * GetTreeCount(map, instruction.Item1, instruction.Item2);
            }

            return result;
        }

        private static int GetTreeCount(SlopeMap map, int stepX, int stepY)
        {
            var treeCount = 0;

            var x = 0;
            var y = 0;

            while (y < map.MapHeight)
            {
                if (map.GetGeologyForCoordinate(x, y) == MapGeology.Tree)
                    treeCount++;

                x += stepX;
                if (x > map.MapWidth - 1)
                {
                    x -= map.MapWidth;
                }

                y += stepY;
            }

            return treeCount;
        }
    }

    public class SlopeMap
    {
        public List<string> Map { get; set; }
        public int MapHeight { get; set; }
        public int MapWidth { get; set; }

        public SlopeMap(List<string> input)
        {
            MapHeight = input.Count;
            MapWidth = input[0].Length;
            Map = input;
        }

        public MapGeology GetGeologyForCoordinate(int x, int y)
        {
            var dataForCoordinate = Map[y][x];

            switch (dataForCoordinate)
            {
                case '.':
                    return MapGeology.OpenSpace;
                case '#':
                    return MapGeology.Tree;
                default:
                    break;
            }
            return MapGeology.Void;
        }
    }

    public enum MapGeology
    {
        Tree,
        OpenSpace,
        Void
    }
}
