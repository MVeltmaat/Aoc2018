using System.Collections.Generic;
using AOC.Day02;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day2Test
    {
        private Day2Logic _cut;

        [Test]
        public void TestCheckSum()
        {
            var input = GetInput();
            var result = _cut.ComputeChecksum(input);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void TestCommonLetters()
        {
            var input = GetInputPart2();
            var result = _cut.GetCommonLetters(input);
            Assert.AreEqual("fgij", result);
        }

        [SetUp]
        public void Setup()
        {
            _cut = new Day2Logic();
        }
        
        internal List<string> GetInput()
        {
            return new List<string>()
            {
                "abcdef", "bababc", "abbcde", "abcccd",  "aabcdd", "abcdee", "ababab"
            };
        }

        internal List<string> GetInputPart2()
        {
            return new List<string>()
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"};
        }
    }
    
}
