using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Day07;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day7Test
    {
        private Day7Logic _cut;

        [SetUp]
        public void Setup()
        {
            _cut = new Day7Logic();
        }

        [Test]
        public void TestInitial()
        {
            var result = _cut.Initial();
            Assert.AreEqual("Wh00pWh00p", result);
        }

        [Test]
        public void TestOrder()
        {
            var input = GetListInput();
            var steps = _cut.Parse(input);
            var result = _cut.ComputeOrder(steps);
            Assert.AreEqual("CABDFE", result);
        }

        [Test]
        public void TestOrderWithWorkers()
        {
            var input = GetListInput();
            var steps = _cut.Parse(input);
            var result = _cut.ComputeDuration(steps, 2, 0);
            Assert.AreEqual(15, result);
        }

        internal List<string> GetListInput()
        {
            var path = Constants.TestPath + "Day07.txt";
            string[] lines = File.ReadAllLines(path);

            return lines.ToList();
        }

    }
}
