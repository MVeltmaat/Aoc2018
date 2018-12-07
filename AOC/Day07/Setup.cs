namespace AOC.Day07
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDay7 day7Logic = new Day7Logic();
            IExecuter day7Executer = new Day7Executer(day7Logic);
            return day7Executer;
        }
    }
}
