using System;

namespace AOC.Day01
{
    public class Day1Executer : IExecuter
    {
        public int Day => 1;
        private readonly IDay1 _day1;

        public Day1Executer(IDay1 day1)
        {
            _day1 = day1;
        }


        public void Part1()
        {
            Console.WriteLine($"Result to day 1, part 1 is not computed.");
        }

        public void Part2()
        {
            var input = Input.Input.GetInputDay1();
            var result = _day1.ComputeRepeatedFrequency(input);
            Console.WriteLine($"Result to day 1, part 2 is {result}");
        }
    }
}
