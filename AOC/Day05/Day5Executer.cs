using System;

namespace AOC.Day05
{
    public class Day5Executer : IExecuter
    {
        public int Day => 5;
        private readonly IDay5 _day5;

        public Day5Executer(IDay5 day5)
        {
            _day5 = day5;
        }


        public void Part1()
        {
            var input = Input.Input.GetInputDay5();
            var result = _day5.RemainingUnits(input);
            Console.WriteLine($"Result to day {Day}, part 1 is {result} ");
            //File.WriteAllText(Input.Output.GetOutputPath(Day), result);
        }

        public void Part2()
        {
            var input = Input.Input.GetInputDay5();
            var result = _day5.OptimizePolymer(input);
            Console.WriteLine($"Result to day {Day}, part 2 is {result} ");
        }
    }
}
