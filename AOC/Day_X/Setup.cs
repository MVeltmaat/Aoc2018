namespace AOC.Day_X
{
    public static class Setup
    {
        public static IExecuter GetExecuter()
        {
            IDayX dayXLogic = new DayXLogic();
            IExecuter dayXExecuter = new DayXExecuter(dayXLogic);
            return dayXExecuter;
        }
    }
}
