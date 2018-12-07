using System;
using System.Collections.Generic;

namespace AOC.Day01
{
    public class Day1Logic : IDay1
    {
        public int ComputeRepeatedFrequency(int[] inputs)
        {
            var freqs = new List<int>();
            var freq = 0;
            freqs.Add(freq);
            bool found = false;
            while (found == false)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    freq += inputs[i];
                    if (freqs.Contains(freq))
                    {
                        found = true;
                    }
                    freqs.Add(freq);
                    if (found)
                    {
                        return freq;
                    }

                    if (i == inputs.Length)
                    {
                        Console.WriteLine("length reached; starting over");
                        i = 0;
                    }
                }
            }
            return 0;
        }
    }
}