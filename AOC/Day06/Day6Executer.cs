using System;
using AOC.Day06;

namespace AOC.Day02
{
    public class Day6Executer : IExecuter
    {
        public int Day => 6;
        private readonly IDay6 _day6;

        public Day6Executer(IDay6 day6)
        {
            _day6 = day6;
        }


        public void Part1()
        {
            var input = Input.Input.GetInputDay6();
            var coordinates = _day6.ParseCoordinates(input);
            var result = _day6.ComputeLargesFiniteArea(coordinates);
            Console.WriteLine($"Result to day {Day}, part 1 is {result} ");
        }

        public void Part2()
        {
            var input = Input.Input.GetInputDay6();
            var result = 0;
            Console.WriteLine($"Result to day {Day}, part 2 is {result} ");
        }
    }
}
