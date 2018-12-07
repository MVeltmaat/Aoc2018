using AOC.Day02;

namespace AOC.Day05
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDay5 day5Logic = new Day5Logic();
            IExecuter day5 = new Day5Executer(day5Logic);
            return day5;
        }
    }
}
