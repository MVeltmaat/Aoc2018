namespace AOC.Day04
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDay4 day4Logic = new Day4Logic();
            IExecuter day4 = new Day4Executer(day4Logic);
            return day4;
        }
    }
}
