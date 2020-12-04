using AOC2020.Fourth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    [TestClass]
    public class Fourth
    {
        [TestMethod]
        public void Fourth2_BirthYearValid()
        {
            var input = new List<string> { "byr:2002" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsTrue(northPoleCredentials.IsBirthYearValid2());
        }

        [TestMethod]
        public void Fourth2_BirthYearInvalid()
        {
            var input = new List<string> { "byr:2003" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsFalse(northPoleCredentials.IsBirthYearValid2());
        }

        [TestMethod]
        public void Fourth2_HeightValid_In()
        {
            var input = new List<string> { "hgt:60in" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsTrue(northPoleCredentials.IsHeightValid2());
        }

        [TestMethod]
        public void Fourth2_HeightValid_Cm()
        {
            var input = new List<string> { "hgt:190cm" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsTrue(northPoleCredentials.IsHeightValid2());
        }

        [TestMethod]
        public void Fourth2_HeightInvalid_In()
        {
            var input = new List<string> { "hgt:190in" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsFalse(northPoleCredentials.IsHeightValid2());
        }

        [TestMethod]
        public void Fourth2_HeightInvalid_Cm()
        {
            var input = new List<string> { "hgt:190" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsFalse(northPoleCredentials.IsHeightValid2());
        }

        [TestMethod]
        public void Fourth2_HairColorValid()
        {
            var input = new List<string> { "hcl:#123abc" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsTrue(northPoleCredentials.IsHairColorValid2());
        }


        [TestMethod]
        public void Fourth2_HairColorInvalid()
        {
            var input = new List<string> { "hcl:#123abz" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsFalse(northPoleCredentials.IsHairColorValid2());
        }

        [TestMethod]
        public void Fourth2_HairColorInvalid2()
        {
            var input = new List<string> { "hcl:123abc" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsFalse(northPoleCredentials.IsHairColorValid2());
        }

        [TestMethod]
        public void Fourth2_EyeColorValid()
        {
            var input = new List<string> { "ecl:brn" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsTrue(northPoleCredentials.IsEyeColorValid2());
        }

        [TestMethod]
        public void Fourth2_EyeColorInvalid()
        {
            var input = new List<string> { "ecl:wat" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsFalse(northPoleCredentials.IsEyeColorValid2());
        }

        [TestMethod]
        public void Fourth2_PassportIDValid()
        {
            var input = new List<string> { "pid:000000001" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsTrue(northPoleCredentials.IsPassportIDValid2());
        }

        [TestMethod]
        public void Fourth2_PassportIDInvalid()
        {
            var input = new List<string> { "pid:0123456789" };

            var northPoleCredentials = new NorthPoleCredentials(input);

            Assert.IsFalse(northPoleCredentials.IsPassportIDValid2());
        }

        [TestMethod]
        public void Fourth2_Passports_Invalid()
        {
            var inputs = new List<List<string>>
            {
                new List<string>{ "eyr:1972", "cid:100", "hcl:#18171d", "ecl:amb", "hgt:170", "pid:186cm", "iyr:2018", "byr:1926" },
                new List<string>{ "iyr:2019", "hcl:#602927", "eyr:1967", "hgt:170cm", "ecl:grn", "pid:012533040", "byr:1946" },
                new List<string>{ "hcl:dab227", "iyr:2012", "ecl:brn", "hgt:182cm", "pid:021572410", "eyr:2020", "byr:1992", "cid:277" },
                new List<string>{ "hgt:59cm", "ecl:zzz", "eyr:2038", "hcl:74454a", "iyr:2023", "pid:3556412378", "byr:2007" }
            };

            var listOfNorthPoleCredentials = inputs.Select(x => new NorthPoleCredentials(x));

            foreach (var northPoleCredentials in listOfNorthPoleCredentials)
            {
                Assert.IsFalse(northPoleCredentials.IsValidPassport2());
            }
        }

        [TestMethod]
        public void Fourth2_Passports_Valid()
        {
            var inputs = new List<List<string>>
            {
                new List<string>{ "pid:087499704", "hgt:74in", "ecl:grn", "iyr:2012", "eyr:2030", "byr:1980", "hcl:#623a2f" },
                new List<string>{ "eyr:2029", "ecl:blu", "cid:129", "byr:1989", "iyr:2014", "pid:896056539", "hcl:#a97842", "hgt:165cm" },
                new List<string>{ "hcl:#888785", "hgt:164cm", "byr:2001", "iyr:2015", "cid:88", "pid:545766238", "ecl:hzl", "eyr:2022" },
                new List<string>{ "iyr:2010", "hgt:158cm", "hcl:#b6652a", "ecl:blu", "byr:1944", "eyr:2021", "pid:093154719" }
            };

            var listOfNorthPoleCredentials = inputs.Select(x => new NorthPoleCredentials(x));

            foreach (var northPoleCredentials in listOfNorthPoleCredentials)
            {
                Assert.IsTrue(northPoleCredentials.IsValidPassport2());
            }
        }
    }
}
