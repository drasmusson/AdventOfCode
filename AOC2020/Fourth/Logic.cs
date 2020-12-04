using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2020.Fourth
{
    public static class Logic
    {
        public static int Run()
        {
            var listOfPassportInputs = Input.InputList;

            var listOfNorthPoleCredentials = new List<NorthPoleCredentials>();

            foreach (var passportInput in listOfPassportInputs)
            {
                listOfNorthPoleCredentials.Add(new NorthPoleCredentials(passportInput));
            }

            return listOfNorthPoleCredentials.Count(x => x.IsValidPassport2());
        }
    }

    public class NorthPoleCredentials
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }

        public NorthPoleCredentials(List<string> inputData)
        {
            var birthdaystring = inputData.Where(inputLine => inputLine.Contains("byr:")).FirstOrDefault();
            var issueYearString = inputData.Where(inputLine => inputLine.Contains("iyr:")).FirstOrDefault();
            var expirationYearstring = inputData.Where(inputLine => inputLine.Contains("eyr:")).FirstOrDefault();
            var heightstring = inputData.Where(inputLine => inputLine.Contains("hgt:")).FirstOrDefault();
            var hairColorstring = inputData.Where(inputLine => inputLine.Contains("hcl:")).FirstOrDefault();
            var eyeColorstring = inputData.Where(inputLine => inputLine.Contains("ecl:")).FirstOrDefault();
            var passportIDstring = inputData.Where(inputLine => inputLine.Contains("pid:")).FirstOrDefault();
            var countryIDstring = inputData.Where(inputLine => inputLine.Contains("cid:")).FirstOrDefault();

            BirthYear = birthdaystring is null ? null : birthdaystring.Split(":").LastOrDefault();
            IssueYear = issueYearString is null ? null  : issueYearString.Split(":").LastOrDefault();
            ExpirationYear = expirationYearstring is null ? null : expirationYearstring.Split(":").LastOrDefault();
            Height = heightstring is null ? null : heightstring.Split(":").LastOrDefault();
            HairColor = hairColorstring is null ? null : hairColorstring.Split(":").LastOrDefault();
            EyeColor = eyeColorstring is null ? null : eyeColorstring.Split(":").LastOrDefault();
            PassportID = passportIDstring is null ? null : passportIDstring.Split(":").LastOrDefault();
            CountryID = countryIDstring is null ? null : countryIDstring.Split(":").LastOrDefault();
        }

        public bool IsValidPassport1()
        {
            return !(BirthYear is null) && !(IssueYear is null) && !(ExpirationYear is null) && !(Height is null) && !(HairColor is null) && !(EyeColor is null) && !(PassportID is null);
        }

        public bool IsValidPassport2()
        {
            return IsBirthYearValid2() && IsIssueYearValid2() && IsExpirationYearValid2() && IsHeightValid2() && IsHairColorValid2() && IsEyeColorValid2() && IsPassportIDValid2();
        }

        public bool IsBirthYearValid2()
        {
            if (BirthYear is null)
                return false;

            if (int.TryParse(BirthYear, out var parsedBirthYear))
                return parsedBirthYear >= 1920 && parsedBirthYear <= 2002;

            return false;
        }

        public bool IsIssueYearValid2()
        {
            if (IssueYear is null)
                return false;

            if (int.TryParse(IssueYear, out var parsedIssueYear))
                return parsedIssueYear >= 2010 && parsedIssueYear <= 2020;

            return false;
        }

        public bool IsExpirationYearValid2()
        {
            if (ExpirationYear is null)
                return false;

            if (int.TryParse(ExpirationYear, out var parsedExpirationYear))
                return parsedExpirationYear >= 2010 && parsedExpirationYear <= 2030;

            return false;
        }

        public bool IsHeightValid2()
        {
            if (Height is null)
                return false;

            var heightUnit = Height.Substring(Height.Length - 2);

            if (heightUnit == "cm")
            {
                int.TryParse(Height.Substring(0, Height.Length - 2), out var parsedHeight);

                return parsedHeight >= 150 && parsedHeight <= 193;
            }
            if (heightUnit == "in")
            {
                int.TryParse(Height.Substring(0, Height.Length - 2), out var parsedHeight);

                return parsedHeight >= 59 && parsedHeight <= 76;
            }
            return false;
        }

        public bool IsHairColorValid2()
        {
            if (HairColor is null)
                return false;

            if (HairColor.Length == 7)
            {
                if (HairColor[0] == '#')
                {
                    return Regex.IsMatch(HairColor.Split('#').Last(), @"^[a-fA-F0-9]+$");
                }
            }
            return false;
        }

        public bool IsEyeColorValid2()
        {
            if (EyeColor is null)
                return false;

            if (EyeColor == "amb" || EyeColor == "blu" || EyeColor == "brn" || EyeColor == "gry" || EyeColor == "grn" || EyeColor == "hzl" || EyeColor == "oth")
            {
                return true;
            }
            return false;
        }

        public bool IsPassportIDValid2()
        {
            if (PassportID is null)
                return false;

            if (PassportID.Length == 9)
                return int.TryParse(PassportID, out var r);

            return false;
        }
    }
}
