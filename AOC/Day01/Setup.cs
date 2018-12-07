namespace AOC.Day01
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDay1 day1Logic = new Day1Logic();
            IExecuter day1 = new Day1Executer(day1Logic);
            return day1;
        }
    }
}
