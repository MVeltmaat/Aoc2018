using System.Collections.Generic;
using System.Linq;
using AOC.Day03;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day3Test
    {
        private Day3Logic _cut;

        [Test]
        public void TestOverlapping()
        {
            var input = GetInput();
            var result = _cut.ComputeOverlapping(input);
            Assert.AreEqual(4, result);
        }
        
        [SetUp]
        public void Setup()
        {
            _cut = new Day3Logic();
        }
        
        internal List<Patch> GetInput()
        {
            var input = new List<string>() {"#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2"};
            return input.Select(i => new Patch(i)).ToList();
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
