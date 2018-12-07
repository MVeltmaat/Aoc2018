using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOC.CommonMetrics;

namespace AOC.Day02
{
    public interface IDay2
    {
        int ComputeChecksum(List<string> input);
        string GetCommonLetters(List<string> input);
    }

    public class Day2Logic : IDay2
    {
        public int ComputeChecksum(List<string> input)
        {
            var nr2 = 0;
            var nr3 = 0;

            foreach (var boxId in input)
            {
                var letterArray = boxId.ToCharArray();
                var letterDict = letterArray.Distinct()
                    .ToDictionary(letter => letter, letter => boxId.Count(x => x == letter));
                
                if (letterDict.Any(d => d.Value == 2))
                    nr2++;
                if (letterDict.Any(d => d.Value == 3))
                    nr3++;
            }

            return nr2 * nr3;
        }

        public string GetCommonLetters(List<string> input)
        {
            for (var rows = 0; rows < input.Count; rows++)
            {
                for (var columns = 0; columns < input.Count; columns++)
                {
                    if(rows == columns)
                        continue;
                    var distance = LevenshteinDistance.Compute(input[rows], input[columns]);
                    if (distance == 1)
                    {
                        return CommonString(input[rows], input[columns]);
                    }
                }
            }
            return string.Empty;
        }

        private static string CommonString(string s1, string s2)
        {
            var output = new StringBuilder();
            var s1A = s1.ToCharArray();
            var s2A = s2.ToCharArray();
            for (var i = 0; i < s1.Length; i++)
            {
                if(s1A[i] == s2A[i])
                {
                    output.Append(s1A[i]);
                }
            }

            return output.ToString();
        }
    }
}
