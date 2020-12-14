using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AOC2020.Thirteenth
{
    public static class Logic
    {
        
        public static long Run()
        {
            //var input = InputParser.InputList;
            var input2 = InputParser.InputList2;
            //var result1 = First(input);
            var result2 = SecondTry2(input2);
            return result2;
        }

        private static long SecondTry2(List<string> input2)
        {
            var data = new List<(int, int)>();
            
            for (int i = 0; i < input2.Count; i++)
            {

                if (input2[i] != "x")
                {
                    var id = int.Parse(input2[i]);

                    data.Add((id, i));
                }
            }
            long jumps = 1;
            var currentIndexToSearchFor = 0;

            for (long i = 1; i < long.MaxValue; i+= jumps)
            {
                if ((i + data[currentIndexToSearchFor].Item2) % data[currentIndexToSearchFor].Item1 == 0)
                {
                    jumps = data[currentIndexToSearchFor].Item1 * jumps;

                    currentIndexToSearchFor++;

                    if (currentIndexToSearchFor == data.Count)
                    {
                        return i;
                    }

                    i += jumps;
                }
            }
            return 0;
        }

        private static long Second(List<string> input2)
        {
            var data = new List<(int, int)>();
            var jumps = 0;
            var jumpIndex = 0;

            for (int i = 0; i < input2.Count; i++)
            {

                if (input2[i] != "x")
                {
                    var id = int.Parse(input2[i]);

                    data.Add((id, i));
                    if (jumps < id)
                    {
                        jumps = id;
                        jumpIndex = i;
                    }
                }
            }

            data = data.Where(x => x.Item1 != jumps).ToList();

            var startpoint = jumps * 300000000000;

            var sw2 = new Stopwatch();
            sw2.Start();
            for (long i = startpoint-jumpIndex; i < long.MaxValue; i+= jumps)
            {
                var correctCounter = 0;

                foreach (var bus in data)
                {
                    var modulus = (i + bus.Item2) % bus.Item1;

                    if (modulus != 0)
                    {
                        correctCounter = 0;
                        break;
                    }
                    correctCounter++;
                    Debug.WriteLine(correctCounter);
                }


                if (correctCounter != data.Count)
                {
                    continue;
                }
                Debug.WriteLine("Total time:");
                Debug.WriteLine(sw2.Elapsed);

                return i;
            }

            return 0;
        }

        private static int First((int myTimeStamp, List<int> busIds) input)
        {
            var myTimeStamp = input.myTimeStamp;
            var lowestDifference = int.MaxValue;
            var lowestBusId = 0;

            foreach (var busId in input.busIds)
            {
                var divide = (decimal)myTimeStamp / (decimal)busId;
                var nextTourCycle = (int)Math.Ceiling(divide);
                int difference = nextTourCycle * busId - myTimeStamp;
                if (difference < lowestDifference)
                {
                    lowestDifference = difference;
                    lowestBusId = busId;
                }
            }
            return lowestBusId * lowestDifference;
        }
    }
}
