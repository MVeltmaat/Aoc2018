using System;
using System.Collections.Generic;
using System.Linq;
using AOC.CommonMetrics;

namespace AOC.Day07
{
    public interface IDay7
    {
        string Initial();
        List<Step> Parse(List<string> input);
        string ComputeOrder(List<Step> input);
    }

    // p1: EPXKISWCFTZVJHDGNABLQYMORU -> fout
    // p1: EPWCFXKISTZVJHDGNABLQYMORU

    public class Day7Logic : IDay7
    {
        public string Initial()
        {
            return "Wh00pWh00p";
        }

        public List<Step> Parse(List<string> input)
        {
            return input.Select(s => new Step(s)).ToList();
        }

        public string ComputeOrder(List<Step> steps)
        {
            var dependencies = ComputeDependencies(steps);

            var all = GetAllPossibleSteps(steps);
            var dependencyValues = UpdateDependenciesWithMissingSteps(dependencies, all).Values.Select(x => x).ToList();

            var firstFulfilledStep = dependencyValues.Where(v => v.IsBlockedBy.Count == 0).Select(d => d.Step).OrderBy(s => s).First();
            var unfulfilledSteps = dependencyValues.Where(v => v.Step != firstFulfilledStep).Select(d => d.Step)
                .OrderBy(s => s).ToList();
            var fulfilled = new List<string> {firstFulfilledStep};

            while (unfulfilledSteps.Any())
            {
                var remainingSteps = dependencyValues.Where(s => unfulfilledSteps.Contains(s.Step)).ToList();
                Console.WriteLine($"Number of remaining steps: {remainingSteps.Count}");

                var toFulfill = remainingSteps.Where(s => s.IsBlockedBy.TrueForAll(x => CanbeFulfilled(x, fulfilled))).OrderBy(l => l.Step).First();
                fulfilled.Add(toFulfill.Step);
                unfulfilledSteps.Remove(toFulfill.Step);
            }


            Console.WriteLine(CollectionHelper.GetStringFromCollection(fulfilled));


            var result = CollectionHelper.GetStringFromCollection(fulfilled);
            return result;
        }

        private static bool CanbeFulfilled(String s, List<string> fulfilled)
        {
            return fulfilled.Contains(s);
        }

        private Dictionary<string, StepDependencies> UpdateDependenciesWithMissingSteps(Dictionary<string, StepDependencies> dependencies, List<string> all)
        {
            foreach (var line in all)
            {
                if (dependencies.ContainsKey(line))
                    continue;

                var dependency = new StepDependencies { Step = line };
                dependencies.Add(line, dependency);
            }

            return dependencies;
        }

        private static List<string> GetAllPossibleSteps(List<Step> steps)
        {
            var finishedList = steps.Select(s => s.MustBeFinished).Distinct();
            var mustBeginList = steps.Select(s => s.BeforeCanBegin).Distinct();
            var all = finishedList.Union(mustBeginList).Distinct().ToList();
            return all;
        }

        private Dictionary<string, StepDependencies> ComputeDependencies(List<Step> steps)
        {
            var stepDepDict = new Dictionary<string, StepDependencies>();
            foreach (var step in steps)
            {
                if (stepDepDict.ContainsKey(step.BeforeCanBegin))
                {
                    stepDepDict[step.BeforeCanBegin].IsBlockedBy.Add(step.MustBeFinished);
                }
                else
                {
                    var dependency = new StepDependencies {Step = step.BeforeCanBegin};
                    dependency.IsBlockedBy.Add(step.MustBeFinished);
                    stepDepDict.Add(step.BeforeCanBegin, dependency);
                }
            }

            return stepDepDict;
        }
    }

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

    public class Step
    {
        public string MustBeFinished { get; set; }
        public string BeforeCanBegin { get; set; }

        public override string ToString()
        {
            return $"Step {MustBeFinished} must be finished before step {BeforeCanBegin} can begin.";
        }

        public Step(string s)
        {
            var words = s.Split(' ');
            MustBeFinished = words[1];
            BeforeCanBegin = words[7];
        }
    }
}
