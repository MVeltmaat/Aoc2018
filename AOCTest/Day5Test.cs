using AOC.Day05;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day5Test
    {
        private Day5Logic _cut;

        [TestCase("aA", "")]
        [TestCase("abBA", "")]
        [TestCase("abAB", "abAB")]
        [TestCase("aabAAB", "aabAAB")]
        [TestCase("dabAcCaCBAcCcaDA", "dabCBAcaDA")]
        public void TestReactingPolymers(string input, string expected)
        {
            var result = _cut.ReactPolymer(input);
            Assert.AreEqual(expected, result);
        }
        
        [SetUp]
        public void Setup()
        {
            _cut = new Day5Logic();
        }
        
    }
}
