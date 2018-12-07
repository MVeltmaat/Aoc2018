using System;

namespace AOC.Day_X
{
    public class DayXExecuter : IExecuter
    {
        public int Day => 1337;
        private readonly IDayX _dayX;

        public DayXExecuter(IDayX dayX)
        {
            _dayX = dayX;
        }


        public void Part1()
        {
            var input = Input.Input.GetStringInput(Day);
            var result = _dayX.Initial();
            Console.WriteLine($"Result to day {Day}, part 1 is {result} ");
        }

        public void Part2()
        {
            var input = Input.Input.GetStringInput(Day);
            var result = _dayX.Initial();
            Console.WriteLine($"Result to day {Day}, part 2 is {result} ");
        }
    }
}
