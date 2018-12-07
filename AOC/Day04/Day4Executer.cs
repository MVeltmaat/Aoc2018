using System;

namespace AOC.Day04
{
    public class Day4Executer : IExecuter
    {
        public int Day => 4;
        private readonly IDay4 _day4;

        public Day4Executer(IDay4 day4)
        {
            _day4 = day4;
        }


        public void Part1()
        {
            var input = Input.Input.GetStringInputDay4();
            var result = _day4.ComputeActivities(input);
            Console.WriteLine($"Result to day {Day}, part 1 is {result} ");
        }

        public void Part2()
        {
            var input = Input.Input.GetInputDay4();
            var result = 0;//_day4.ComputeNonOverlapping(input);
            Console.WriteLine($"Result to day {Day}, part 2 is {result}");
        }
    }
}
