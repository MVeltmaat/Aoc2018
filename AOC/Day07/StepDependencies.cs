using System.Collections.Generic;
using AOC.CommonMetrics;

namespace AOC.Day07
{
    public class StepDependencies
    {
        public string Step { get; set; }
        public List<string> IsBlockedBy;

        public StepDependencies()
        {
            IsBlockedBy = new List<string>();
        }

        public override string ToString()
        {
            return $"Step {Step} is blocked by {CollectionHelper.GetStringFromCollection(IsBlockedBy)}";
        }
    }
}