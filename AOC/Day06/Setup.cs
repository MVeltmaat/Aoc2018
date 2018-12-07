using AOC.Day02;

namespace AOC.Day06
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDay6 day6Logic = new Day6Logic();
            IExecuter day6 = new Day6Executer(day6Logic);
            return day6;
        }
    }
}
