using System;

namespace AOC.Day07
{
    public class Day7Executer : IExecuter
    {
        public int Day => 7;
        private readonly IDay7 _day7;

        public Day7Executer(IDay7 day7)
        {
            _day7 = day7;
        }


        public void Part1()
        {
            var input = Input.Input.GetListInput(Day);
            var steps = _day7.Parse(input);
            var result = _day7.ComputeOrder(steps);
            Console.WriteLine($"Result to day {Day}, part 1 is {result} ");
        }

        public void Part2()
        {
            var input = Input.Input.GetStringInput(Day);
            var result = _day7.Initial();
            Console.WriteLine($"Result to day {Day}, part 2 is {result} ");
        }
    }
}
