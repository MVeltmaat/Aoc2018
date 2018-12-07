using System;

namespace AOC.Day02
{
    public class Day2Executer : IExecuter
    {
        public int Day => 2;
        private readonly IDay2 _day2;

        public Day2Executer(IDay2 day2)
        {
            _day2 = day2;
        }


        public void Part1()
        {
            var input = Input.Input.GetInputDay2();
            var result = _day2.ComputeChecksum(input);
            Console.WriteLine($"Result to day 2, part 1 is {result}");
        }

        public void Part2()
        {
            var input = Input.Input.GetInputDay2();
            var result = _day2.GetCommonLetters(input);
            Console.WriteLine($"Result to day 2, part 2 is {result}");
        }
    }
}
