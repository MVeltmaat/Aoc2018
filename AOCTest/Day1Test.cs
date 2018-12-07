using AOC.Day01;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day1Test
    {
        private Day1Logic _cut;

        [SetUp]
        public void SetUp()
        {
            _cut = new Day1Logic();
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(0, TestFreqRep(new[] {1, -1}));
            Assert.AreEqual(10, TestFreqRep(new[] {3, 3, 4, -2, -4}));
            Assert.AreEqual(5, TestFreqRep(new[] {-6, 3, 8, 5, -6}));
            Assert.AreEqual(14, TestFreqRep(new[] {7, 7, -2, -7, -4}));
            Assert.AreEqual(2, TestFreqRep(new[] {1, -2, 3, 1}));
        }

        int TestFreqRep(int[] input)
        {
            return _cut.ComputeRepeatedFrequency(input);
        }
    }
}
