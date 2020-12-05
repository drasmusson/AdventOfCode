using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Fifth
{
    public static class Logic
    {
        public static int Run()
        {
            var input = InputParser.InputList;
            int result1 = First(input);
            int result2 = Second(input);
            return result2;
        }

        private static int Second(List<string> input)
        {
            var seatIDs = new List<int>();

            foreach (var seat in input)
            {
                var rowAndColumn = GetMeMySeat(seat);
                seatIDs.Add(CalculateMySeatID(rowAndColumn.Item1, rowAndColumn.Item2));
            }

            seatIDs.Sort();
            return Enumerable.Range(seatIDs.First(), seatIDs.Last()).Except(seatIDs).First();
        }

        private static int First(List<string> input)
        {
            var highestSeatID = 0;

            foreach (var seat in input)
            {
                var rowAndColumn = GetMeMySeat(seat);
                var seatID = CalculateMySeatID(rowAndColumn.Item1, rowAndColumn.Item2);
                if (seatID > highestSeatID)
                    highestSeatID = seatID;
            }

            return highestSeatID;
        }

        public static int CalculateMySeatID(int row, int column)
        {
            return row * 8 + column;
        }

        public static (int, int) GetMeMySeat(string input)
        {
            var rowTotal = 127;
            var colTotal = 7;

            var inputRow = input.Substring(0, 7);
            var inputCol = input.Substring(7);

            var rowResult = FindRow(0, rowTotal, inputRow);
            var colResult = FindRow(0, colTotal, inputCol);

            return (rowResult, colResult);
        }

        private static int FindRow(int rangeStart, int rangeEnd, string instructions)
        {
            if (instructions.Length == 0)
            {
                return rangeStart;
            }

            var middle = (rangeStart + rangeEnd) / 2;

            switch (instructions[0])
            {
                case 'F':
                case 'L':
                    rangeEnd = middle;
                    break;
                case 'B':
                case 'R':
                    rangeStart = middle + 1;
                    break;
                default:
                    break;
            }

            return FindRow(rangeStart, rangeEnd, instructions.Remove(0, 1));
        }
    }
}
