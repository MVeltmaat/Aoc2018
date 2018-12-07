using AOC.Day05;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day5Test
    {
        private Day5Logic _cut;

        [SetUp]
        public void Setup()
        {
            _cut = new Day5Logic();
        }

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

        [TestCase("aA", 0)]
        [TestCase("abBA", 0)]
        [TestCase("abAB", 4)]
        [TestCase("aabAAB", 6)]
        [TestCase("dabAcCaCBAcCcaDA", 10)]
        public void TestRemainingUnits(string input, int expected)
        {
            var result = _cut.RemainingUnits(input);
            Assert.AreEqual(expected, result);
        }

        public void TestLengthAfterOptimization()
        {
            var input = "dabAcCaCBAcCcaDA";
            var result = _cut.OptimizePolymer(input);
            Assert.AreEqual(4, result);
        }
        
    }
}
