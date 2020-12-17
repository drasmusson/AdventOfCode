using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AOC2020.Seventeenth
{
    public static class Logic
    {
        public static int Run()
        {
            var input = InputParser.InputList;
            var sw = new Stopwatch();

            sw.Start();
            var result1 = First(input);
            Debug.WriteLine(sw.Elapsed);
            sw.Reset();
            sw.Start();

            var result2 = Second(input);
            Debug.WriteLine(sw.Elapsed);

            return result2;
        }

        private static int Second(List<string> input)
        {
            var grid = new Cubes4D(input);

            grid.FlipNumberOfTimes(6);

            return grid.Actives.Count;
        }

        private static int First(List<string> input)
        {
            var grid = new Cubes3D(input);

            grid.FlipNumberOfTimes(6);

            return grid.Actives.Count;
        }
    }

    public class Cubes3D
    {
        public HashSet<(int x, int y, int z)> Actives { get; set; }
        public Dictionary<(int x, int y, int z), int> NeighboursWithTouches { get; set; }
        private static List<(int x, int y, int z)> PossibleRelativePermutations => GetPossibleRelativePermutations();

        public Cubes3D(List<string> input)
        {
            Actives = new HashSet<(int x, int y, int z)>();
            NeighboursWithTouches = new Dictionary<(int x, int y, int z), int>();

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '#')
                    {
                        Actives.Add((i, j, 0));
                    }
                }
            }
        }

        public void FlipNumberOfTimes(int numberOfFlips)
        {
            for (int i = 0; i < numberOfFlips; i++)
            {
                Flip();
            }
        }

        private void Flip()
        {
            NeighboursWithTouches = new Dictionary<(int x, int y, int z), int>();
            foreach (var active in Actives)
            {
                AddNeighbourTouches(active);
            }

            var copy = new HashSet<(int, int, int)>();
            foreach (var neighbourWithTouches in NeighboursWithTouches)
            {
                var touches = neighbourWithTouches.Value;
                if ((touches == 2 || touches == 3) && Actives.Contains(neighbourWithTouches.Key))
                {
                    copy.Add(neighbourWithTouches.Key);
                }
                else if (touches == 3 && !Actives.Contains(neighbourWithTouches.Key))
                {
                    copy.Add(neighbourWithTouches.Key);
                }
            }

            Actives = copy;
        }

        private void AddNeighbourTouches((int x, int y, int z) activeCube)
        {
            foreach ((int x, int y, int z) relativePermutation in PossibleRelativePermutations)
            {
                var currentPosition = (activeCube.x + relativePermutation.x, activeCube.y + relativePermutation.y, activeCube.z + relativePermutation.z);

                if (NeighboursWithTouches.ContainsKey(currentPosition))
                {
                    NeighboursWithTouches[currentPosition]++;
                }
                else
                {
                    NeighboursWithTouches.Add(currentPosition, 1);
                }
            }
        }

        private static List<(int x, int y, int z)> GetPossibleRelativePermutations()
        {
            int[] possibleXYZValues = { -1, 0, 1 };
            var xyzCombinations = new List<(int, int, int)>();

            for (int x = 0; x < possibleXYZValues.Length; x++)
            {
                for (int y = 0; y < possibleXYZValues.Length; y++)
                {
                    for (int z = 0; z < possibleXYZValues.Length; z++)
                    {

                        var cx = possibleXYZValues[x];
                        var cy = possibleXYZValues[y];
                        var cz = possibleXYZValues[z];

                        if (!(cx == 0 && cy == 0 && cz == 0))
                        {
                            xyzCombinations.Add((cx, cy, cz));
                        }
                    }
                }
            }

            return xyzCombinations;
        }
    }

    public class Cubes4D
    {
        public HashSet<(int x, int y, int z, int w)> Actives { get; set; }
        public Dictionary<(int x, int y, int z, int w), int> NeighboursWithTouches { get; set; }
        private static List<(int x, int y, int z, int w)> PossibleRelativePermutations => GetPossibleRelativePermutations();

        public Cubes4D(List<string> input)
        {
            Actives = new HashSet<(int, int, int, int)>();
            NeighboursWithTouches = new Dictionary<(int, int, int, int), int>();

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] == '#')
                    {
                        Actives.Add((i, j, 0, 0));
                    }
                }
            }
        }

        public void FlipNumberOfTimes(int numberOfFlips)
        {
            for (int i = 0; i < numberOfFlips; i++)
            {
                Flip();
            }
        }

        private void Flip()
        {
            NeighboursWithTouches = new Dictionary<(int, int, int, int), int>();
            foreach (var active in Actives)
            {
                AddNeighbourTouches(active);
            }

            var copy = new HashSet<(int, int, int,int)>();
            foreach (var neighbourWithTouches in NeighboursWithTouches)
            {
                var touches = neighbourWithTouches.Value;
                if ((touches == 2 || touches == 3) && Actives.Contains(neighbourWithTouches.Key))
                {
                    copy.Add(neighbourWithTouches.Key);
                }
                else if (touches == 3 && !Actives.Contains(neighbourWithTouches.Key))
                {
                    copy.Add(neighbourWithTouches.Key);
                }
            }

            Actives = copy;
        }

        private void AddNeighbourTouches((int x, int y, int z, int w) activeCube)
        {
            foreach ((int x, int y, int z, int w) relativePermutation in PossibleRelativePermutations)
            {
                var currentPosition = (activeCube.x + relativePermutation.x, activeCube.y + relativePermutation.y, activeCube.z + relativePermutation.z, activeCube.w + relativePermutation.w);

                if (NeighboursWithTouches.ContainsKey(currentPosition))
                {
                    NeighboursWithTouches[currentPosition]++;
                }
                else
                {
                    NeighboursWithTouches.Add(currentPosition, 1);
                }
            }
        }

        private static List<(int x, int y, int z, int w)> GetPossibleRelativePermutations()
        {
            int[] possibleXYZValues = { -1, 0, 1 };
            var xyzCombinations = new List<(int, int, int, int)>();

            for (int x = 0; x < possibleXYZValues.Length; x++)
            {
                for (int y = 0; y < possibleXYZValues.Length; y++)
                {
                    for (int z = 0; z < possibleXYZValues.Length; z++)
                    {
                        for (int w = 0; w < possibleXYZValues.Length; w++)
                        {
                            var cx = possibleXYZValues[x];
                            var cy = possibleXYZValues[y];
                            var cz = possibleXYZValues[z];
                            var cw = possibleXYZValues[w];

                            if (!(cx == 0 && cy == 0 && cz == 0 && cw == 0))
                            {
                                xyzCombinations.Add((cx, cy, cz, cw));
                            }

                        }
                    }
                }
            }

            return xyzCombinations;
        }
    }
}
