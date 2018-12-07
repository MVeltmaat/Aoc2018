using AOC.Day02;

namespace AOC.Day03
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDay3 day3Logic = new Day3Logic();
            IExecuter day3 = new Day3Executer(day3Logic);
            return day3;
        }
    }
}
