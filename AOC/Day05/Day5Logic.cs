using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOC.CommonMetrics;

namespace AOC.Day05
{
    public interface IDay5
    {
        int RemainingUnits(string input);
        string ReactPolymer(string input);
        int OptimizePolymer(string input);
    }

    public class Day5Logic : IDay5
    {
        public int RemainingUnits(string input)
        {
            var remaining = ReactPolymer(input);
            return remaining.Length;
        }

        public string ReactPolymer(string input)
        {
            var inputs = input.Select(i => i.ToString()).ToList();
            
            var reactionResult = ReactList(inputs);
            var reacted = reactionResult.Reacted;
            while (reacted)
            {
                reactionResult = ReactList(reactionResult.Remaining);
                reacted = reactionResult.Reacted;
            }
            reactionResult = ReactList(reactionResult.Remaining);
            return CollectionHelper.GetStringFromCollection(reactionResult.Remaining);
        }

        private ReactionResult ReactList(List<string> chars)
        {
            var reacted = false;
            List<string> remaining = new List<string>();
            for (int i = 0; i < chars.Count - 1; i++)
            {
                if (React(chars[i], chars[i + 1]))
                {
                    // delete both i and i+1
                    reacted = true;
                    i++;
                }
                else
                {
                    remaining.Add(chars[i]);
                    if (i == chars.Count - 2)
                    {
                        remaining.Add(chars[i+1]);
                    }
                }
            }

            return new ReactionResult()
            {
                Reacted = reacted,
                Remaining = remaining
            };
        }

        public struct ReactionResult
        {
            public bool Reacted { get; set; }
            public List<string> Remaining { get; set; }
        }

        

        public bool React(string s1, string s2)
        {
            //var s1 = c1.ToString();
            //var s2 = c2.ToString();

            // a a -> 2up a A 1 up A a -> false ok
            // A a -> 2up A A (eq) 1up a A -> false 
            return s1.Equals(s2.ToUpper()) ^ s1.ToUpper().Equals(s2);
        }

        public int OptimizePolymer(string input)
        {
            List<string> options = GetOptions(input);
            int lowest = input.Length;
            foreach (var option in options)
            {
                string cleansedInput = GetCleansedInput(input, option);
                var remainingLength = RemainingUnits(cleansedInput);
                if (remainingLength < lowest)
                    lowest = remainingLength;
            }

            return lowest;
        }

        private string GetCleansedInput(string input, string option)
        {
            var cleansed = input.Replace(option, "");
            cleansed = cleansed.Replace(option.ToUpper(), "");
            return cleansed;
        }

        private List<string> GetOptions(string input)
        {
            var list = input.ToLower().ToCharArray().Distinct();
            Console.WriteLine(list.Count());
            return list.Select(c => c.ToString()).ToList();
        }
    }
}
