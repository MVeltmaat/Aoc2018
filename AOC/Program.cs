using System;
using System.Collections.Generic;

namespace AOC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IExecuter> executers = GetExecuters();

            foreach (var executer in executers)
            {
                executer.Part1();
                executer.Part2();
            }

            Console.ReadKey();
        }

        private static List<IExecuter> GetExecuters()
        {
            var executers = new List<IExecuter>();

            //executers.Add(Day01.Setup.GetExecuter());
            //executers.Add(Day02.Setup.GetExecuter());
            //executers.Add(Day03.Setup.GetExecuter());
            //executers.Add(Day04.Setup.GetExecuter());
            executers.Add(Day05.Setup.GetExecuter());
            //executers.Add(Day06.Setup.GetExecuter());

            return executers;
        }
    }
}
