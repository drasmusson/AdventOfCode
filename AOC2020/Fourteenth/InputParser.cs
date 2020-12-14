using AOC2020.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Fourteenth
{
    public static class InputParser
    {
        public static List<(string, List<ProgramInput>)> InputList => GetInput();
        private static List<(string, List<ProgramInput>)> GetInput()
        {
            var stringInput = Resources.ResourceManager.GetObject("FourteenthInput") as string;
            var listInput = stringInput.Split("mask = ", StringSplitOptions.RemoveEmptyEntries).ToList();

            var input = new List<(string, List<ProgramInput>)>();

            foreach (var maskChunk in listInput)
            {
                var maskList = maskChunk.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var maskAndInput = (maskList.First(), new List<ProgramInput>());
                var inputList = maskList.Skip(1);
                foreach (var pi in inputList)
                {
                    var programInput = new ProgramInput();

                    var piSplit = pi.Split("] = ");
                    programInput.Value = int.Parse(piSplit.Last());
                    programInput.MemoryPosition = int.Parse(piSplit.First().Split("mem[").Last());
                    maskAndInput.Item2.Add(programInput);
                }
                input.Add(maskAndInput);
            }

            return input;
        }
    }

    public class ProgramInput
    {
        public int MemoryPosition { get; set; }
        public int Value { get; set; }
    }
}
