using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020.Eighteenth
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

        private static long First(List<string> input)
        {
            long result = 0;
            foreach (var line in input)
            {
                var calculator = new CalcultatorV1(line);
                calculator.CalculateString();
                result += calculator.Result;
            }
            return result;
        }

        private static long Second(List<string> input)
        {
            long result = 0;
            foreach (var line in input)
            {
                result += CalString(Regex.Replace(line, @"\s", "")).result;
            }

            return result;
        }

        private static (int index, long result) CalString(string currentSubstring)
        {
            var sb = new StringBuilder();
            long result = 0;
            var substringIndex = 0;
            do
            {
                var c = currentSubstring[substringIndex];
                switch (c)
                {
                    case '(':
                        var substringResult = CalString(currentSubstring.Substring(substringIndex + 1));
                        sb.Append(substringResult.result);
                        substringIndex += substringResult.index + 2;
                        break;

                    case ')':
                        return (substringIndex, MultiplicationAndAddition(sb.ToString()));

                    default:
                        sb.Append(c);
                        substringIndex++;
                        break;
                }
            } while (substringIndex < currentSubstring.Length);

            result += MultiplicationAndAddition(sb.ToString());
            return (0, result);
        }

        private static long MultiplicationAndAddition(string stringWithoutParenthesis)
        {
            string[] multiplySubstrings = stringWithoutParenthesis.Split("*");
            long multiplyResult = 1;

            foreach (var multiplySubstring in multiplySubstrings)
            {
                multiplyResult *= Addition(multiplySubstring);
            }
            return multiplyResult;
        }

        private static long Addition(string multiplySubstring)
        {
            var additionSplit = multiplySubstring.Split("+");
            long additionResult = 0;

            foreach (var addition in additionSplit)
            {
                if (long.TryParse(addition, out var cInt))
                {
                    additionResult += cInt;
                }
            }
            return additionResult;
        }
    }

    internal class CalcultatorV1
    {
        public long Result { get; set; }
        private string InputLine { get; set; }
        private int CurrentIndex { get; set; }
        public CalcultatorV1(string inputLine)
        {
            InputLine = Regex.Replace(inputLine, @"\s", "");
            Result = 0;
            CurrentIndex = 0;
        }

        public long CalculateString()
        {
            char currentOperator = '+';
            long currentResult = 0;
            do
            {
                var currentChar = InputLine[CurrentIndex];
                if (int.TryParse(currentChar.ToString(), out int currentInt))
                {
                    currentResult = ApplyOperator(currentInt, currentOperator, currentResult);
                    CurrentIndex++;
                }
                else
                {
                    switch (currentChar)
                    {
                        case '+':
                        case '*':
                            currentOperator = currentChar;
                            CurrentIndex++;
                            break;

                        case '(':
                            CurrentIndex++;
                            currentResult = ApplyOperator(CalculateString(), currentOperator, currentResult);
                            break;

                        case ')':
                            CurrentIndex++;
                            return currentResult;

                        default:
                            break;
                    }
                }
            } while (CurrentIndex < InputLine.Length);

            Result = currentResult;
            return Result;
        }

        private long ApplyOperator(long currentInt, char currentOperator, long currentResult)
        {
            switch (currentOperator)
            {
                case '+':
                    currentResult += currentInt;
                    break;

                case '*':
                    currentResult *= currentInt;
                    break
                        ;
                default:
                    break;
            }
            return currentResult;
        }
    }
}
