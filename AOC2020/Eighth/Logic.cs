using System;
using System.Collections.Generic;

namespace AOC2020.Eighth
{
    public static class Logic
    {
        public static int Run()
        {
            var input = InputParser.InputList;

            var parsedInputs = ParseInputToInstructions(input);
            var result1 = RunProgram(parsedInputs).Item1;
            var result2 = GetAccumulatorForTerminateable(parsedInputs);
            return result2;
        }

        private static int GetAccumulatorForTerminateable(List<Instruction> instructions)
        {
            for (int i = 0; i < instructions.Count; i++)
            {
                var currentInstruction = instructions[i];

                switch (currentInstruction.Operation)
                {
                    case OperationEnum.Acc:
                        break;

                    case OperationEnum.Jmp:
                        currentInstruction.FlipOperation();
                        var result = RunProgram(instructions);
                        if (result.Item2)
                            return result.Item1;

                        currentInstruction.FlipOperation();
                        instructions.ResetCallCount();
                        break;

                    case OperationEnum.Nop:
                        currentInstruction.FlipOperation();
                        var result2 = RunProgram(instructions);
                        if (result2.Item2)
                            return result2.Item1;

                        currentInstruction.FlipOperation();
                        instructions.ResetCallCount();
                        break;

                    default:
                        break;
                }
            }
            return 0;
        }

        private static (int, bool) RunProgram(List<Instruction> instructions)
        {
            var accumulator = 0;

            for (int i = 0; i < instructions.Count; i++)
            {
                var currentInstruction = instructions[i];

                switch (currentInstruction.Operation)
                {
                    case OperationEnum.Acc:
                        currentInstruction.NumberOfCalls += 1;
                        if (currentInstruction.NumberOfCalls > 1)
                            return (accumulator, false);

                        accumulator += currentInstruction.Argument;

                        break;

                    case OperationEnum.Jmp:
                        currentInstruction.NumberOfCalls += 1;

                        if (currentInstruction.NumberOfCalls > 1)
                            return (accumulator, false);

                        i += currentInstruction.Argument - 1;
                        break;

                    case OperationEnum.Nop:
                        if (currentInstruction.NumberOfCalls > 1)
                            return (accumulator, false);

                        currentInstruction.NumberOfCalls += 1;
                        break;

                    default:
                        break;
                }
            }

            return (accumulator, true);
        }

        private static List<Instruction> ResetCallCount(this List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                instruction.NumberOfCalls = 0;
            }
            return instructions;
        }

        private static List<Instruction> ParseInputToInstructions(List<string> input)
        {
            var instructionList = new List<Instruction>();

            foreach (var row in input)
            {
                var rowSplit = row.Split(" ");

                var instruction = new Instruction
                {
                    Operation = (OperationEnum)Enum.Parse(typeof(OperationEnum), rowSplit[0], true),
                    Argument = int.Parse(rowSplit[1])
                };
                instructionList.Add(instruction);
            }

            return instructionList;
        }

        private class Instruction
        {
            public OperationEnum Operation { get; set; }
            public int Argument { get; set; }
            public int NumberOfCalls { get; set; }

            public void FlipOperation()
            {
                switch (Operation)
                {
                    case OperationEnum.Acc:
                        break;
                    case OperationEnum.Jmp:
                        Operation = OperationEnum.Nop;
                        break;
                    case OperationEnum.Nop:
                        Operation = OperationEnum.Jmp;
                        break;
                    default:
                        break;
                }
            }
        }

        private enum OperationEnum
        {
            Acc,
            Jmp,
            Nop
        }
    }
}