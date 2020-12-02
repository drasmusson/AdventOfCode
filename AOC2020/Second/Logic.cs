using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2020.Second
{
    public class Logic
    {
        public static int Run1(List<string> input)
        {
            var passwordDataList = input.Select(line => new PasswordData(line));
            var matchCount = passwordDataList.Where(pwd => pwd.IsValid1()).Count();
            return matchCount;
        }

        public static int Run1()
        {
            var passwordDataList = Input.InputList.Select(line => new PasswordData(line));
            var matchCount = passwordDataList.Where(pwd => pwd.IsValid1()).Count();
            return matchCount;
        }
        public static int Run2(List<string>input)
        {
            var passwordDataList = input.Select(line => new PasswordData(line));
            var matchCount = passwordDataList.Where(pwd => pwd.IsValid2()).Count();
            return matchCount;
        }

        public static int Run2()
        {
            var passwordDataList = Input.InputList.Select(line => new PasswordData(line));
            var matchCount = passwordDataList.Where(pwd => pwd.IsValid2()).Count();
            return matchCount;
        }

    }


    internal class PasswordData
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Char { get; set; }
        public string Password { get; set; }

        public PasswordData(string line)
        {
            var subString = line.Split(" ");

            Min = Int32.Parse(subString[0].Split(('-'))[0]);
            Max = Int32.Parse(subString[0].Split(('-'))[1]);
            Char = subString[1].Split(':')[0][0];
            Password = subString[2];
        }

        public bool IsValid1()
        {
            var count = 0;
            foreach (char c in Password)
                if (c == Char) count++;

            return count >= Min && count <= Max;
        }

        public bool IsValid2()
        {
            var firstMatch = Password[Min-1] == Char;
            var secondMatch = Password[Max-1] == Char;

            return firstMatch ^ secondMatch;
        }
    }
}
