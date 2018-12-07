using System;

namespace AOC.Day03
{
    public class Day3Executer : IExecuter
    {
        public int Day => 3;
        private readonly IDay3 _day3;

        public Day3Executer(IDay3 day3)
        {
            _day3 = day3;
        }


        public void Part1()
        {
            var input = Input.Input.GetInputDay3();
            var result = _day3.ComputeOverlapping(input);
            Console.WriteLine($"Result to day {Day}, part 1 is {result} ");
        }

        public void Part2()
        {
            var input = Input.Input.GetInputDay3();
            var result = _day3.ComputeNonOverlapping(input);
            Console.WriteLine($"Result to day {Day}, part 2 is {result}");
        }
    }
}
