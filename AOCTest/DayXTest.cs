using AOC.Day_X;
using NUnit.Framework;

namespace AOCTest
{
    [TestFixture]
    public class DayXTest
    {
        private DayXLogic _cut;

        [SetUp]
        public void Setup()
        {
            _cut = new DayXLogic();
        }

        public void TestInitial()
        {
            var result = _cut.Initial();
            Assert.AreEqual("Wh00pWh00p", result);
        }
        
    }
}
