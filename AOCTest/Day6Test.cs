using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Day06;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day6Test
    {
        private Day6Logic _cut;

        [Test]
        public void TestAreas()
        {
            var input = GetStringInput();
            var coordinates = _cut.ParseCoordinates(input);
            var result = _cut.ComputeLargesFiniteArea(coordinates);
            Assert.AreEqual(17, result);
        }
        
        [SetUp]
        public void Setup()
        {
            _cut = new Day6Logic();
        }

        internal List<string> GetStringInput()
        {
            var path = Constants.TestPath + "Day06Test.txt";
            string[] lines = File.ReadAllLines(path);

            return lines.ToList();
        }
    }
}
