using System.Collections.Generic;
using System.Text;

namespace AOC.CommonMetrics
{
    public static class CollectionHelper
    {
        public static string GetStringFromCollection(ICollection<string> collection)
        {
            var builder = new StringBuilder();
            builder.Append("");
            foreach (var line in collection)
            {
                builder.Append(line);
            }

            return builder.ToString();
        }
    }
}
