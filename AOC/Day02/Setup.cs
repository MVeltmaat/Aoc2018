namespace AOC.Day02
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDay2 day2Logic = new Day2Logic();
            IExecuter day2 = new Day2Executer(day2Logic);
            return day2;
        }
    }
}
