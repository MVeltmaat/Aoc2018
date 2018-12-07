using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AOC.Day04;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class Day4Test
    {
        private Day4Logic _cut;

        [Test]
        public void TestSleepiest()
        {
            var input = GetStringInput();
            foreach (var activityRecord in input)
            {
                Console.WriteLine(activityRecord.ToString());
            }
            var result = _cut.ComputeActivities(input);
            Assert.AreEqual(240, result);
        }

        // That's not the right answer; your answer is too low. (You guessed 49137.)

        [SetUp]
        public void Setup()
        {
            _cut = new Day4Logic();
        }

        internal List<ActivityRecord> GetInput()
        {
            var path = Constants.TestPath + "Day04Test.txt";
            string[] lines = File.ReadAllLines(path);

            return lines.Select(i => new ActivityRecord(i)).ToList();
        }

        internal List<string> GetStringInput()
        {
            var path = Constants.TestPath + "Day04Test.txt";
            string[] lines = File.ReadAllLines(path);

            return lines.ToList();
        }
    }
}
