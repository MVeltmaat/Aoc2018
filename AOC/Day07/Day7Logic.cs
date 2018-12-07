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
        int ComputeDuration(List<Step> steps, int nrWorkers, int defaultTime);
    }

    // p1: EPXKISWCFTZVJHDGNABLQYMORU -> fout
    // p1: EPWCFXKISTZVJHDGNABLQYMORU
    // p2: 952

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
            var fulfilled = new List<string> { firstFulfilledStep };

            while (unfulfilledSteps.Any())
            {
                var remainingSteps = dependencyValues.Where(s => unfulfilledSteps.Contains(s.Step)).ToList();
                Console.WriteLine($"Number of remaining steps: {remainingSteps.Count}");

                var toFulfill = remainingSteps.Where(s => s.IsBlockedBy.TrueForAll(x => CanbeFulfilled(x, fulfilled))).OrderBy(l => l.Step).First();
                fulfilled.Add(toFulfill.Step);
                unfulfilledSteps.Remove(toFulfill.Step);
            }

            // Console.WriteLine(CollectionHelper.GetStringFromCollection(fulfilled));
            
            var result = CollectionHelper.GetStringFromCollection(fulfilled);
            return result;
        }

        public int ComputeDuration(List<Step> steps, int nrWorkers, int defaultTime)
        {
            var dependencies = ComputeDependencies(steps);

            var all = GetAllPossibleSteps(steps);
            var dependencyValues = UpdateDependenciesWithMissingSteps(dependencies, all).Values.Select(x => x).ToList();

            var workers = InitializeWorkers(nrWorkers);
            var unfulfilledSteps = dependencyValues.Select(d => d.Step).OrderBy(s => s).ToList();
            var fulfilled = new List<string>();
            
            Dictionary<string, int> taskDoneAt = DetermineFirstTasksDoneAt(defaultTime, dependencyValues, workers);

            var maxTime = MaxTime(defaultTime);

            for (var time = 1; time <= maxTime; time++)
            {
                UpdateCompletedTasks(taskDoneAt, unfulfilledSteps, fulfilled, time);
                if (unfulfilledSteps.Any() == false)
                    return time;

                var workersWorkingOn = GetBusyWorkersWorkingOn(workers, time);
                var unackkedSteps = GetRemainingUnacknowledgedSteps(dependencyValues, workersWorkingOn);
                List<StepDependencies> remainingSteps =
                    unackkedSteps.Where(s => unfulfilledSteps.Contains(s.Step)).ToList();

                // Console.WriteLine($"Number of remaining unhandled steps: {remainingSteps.Count}");

                var availableWorkers = GetAvailableWorkers(workers, time);
                var toFulfill = remainingSteps.Where(s => s.IsBlockedBy.TrueForAll(x => CanbeFulfilled(x, fulfilled)))
                    .OrderBy(l => l.Step).Take(availableWorkers.Count).ToList();

                AssignTasksToWorker(toFulfill.Select(s => s.Step).ToList(), availableWorkers, time, defaultTime, taskDoneAt);
            }

            return 0;
        }

        private Dictionary<string, int> DetermineFirstTasksDoneAt(int defaultTime, List<StepDependencies> dependencyValues, List<Worker> workers)
        {
            var availableWorkers = GetAvailableWorkers(workers, 0);
            var firstFulfilledSteps = dependencyValues.Where(v => v.IsBlockedBy.Count == 0).Select(d => d.Step)
                .OrderBy(s => s).Take(availableWorkers.Count).ToList();

            var taskDoneAt = new Dictionary<string, int>();
            AssignTasksToWorker(firstFulfilledSteps, availableWorkers, 0, defaultTime, taskDoneAt);
            return taskDoneAt;
        }

        private static List<StepDependencies> GetRemainingUnacknowledgedSteps(List<StepDependencies> dependencyValues,
            List<string> workersWorkingOn)
        {
            return dependencyValues.Where(s => workersWorkingOn.Contains(s.Step) == false).ToList();
        }

        private List<string> GetBusyWorkersWorkingOn(List<Worker> workers, int time)
        {
            var busyWorkers = workers.Where(w => w.IsAvailable(time) == false).ToList();
            return busyWorkers.Select(w => w.WorkingOnStep(time)).ToList();
        }

        private void UpdateCompletedTasks(Dictionary<string, int> taskDoneAt, List<string> unfulfilledSteps, List<string> fulfilled, int time)
        {
            var completedTasksAtTime = CompletedTasksAtTime(taskDoneAt, time);
            foreach (var completedTask in completedTasksAtTime)
            {
                fulfilled.Add(completedTask);
                unfulfilledSteps.Remove(completedTask);
            }
        }

        private List<string> CompletedTasksAtTime(Dictionary<string, int> tasksDoneAt, int time)
        {
            if (tasksDoneAt.ContainsValue(time))
            {
                return tasksDoneAt.Where(t => t.Value == time).Select(t => t.Key).ToList();
            }
            return new List<string>();
        }

        private int MaxTime(int defaultTime)
        {
            var maxTime = 0;
            for (int i = 0; i <= 26; i++)
            {
                maxTime += defaultTime + 26;
            }
            return maxTime;
        }

        private void AssignTasksToWorker(List<string> toFulfillSteps, List<Worker> availableWorkers, int startTime, int defaultTime, Dictionary<string, int> taskDoneAt)
        {
            if(toFulfillSteps.Count > availableWorkers.Count)
                throw new ArgumentException($"Only {availableWorkers.Count} workers available; and trying to do {toFulfillSteps.Count} tasks");
            for (int i = 0; i < toFulfillSteps.Count; i++)
            {
                var taakje = new Taakje(startTime, GetDuration(toFulfillSteps[i], defaultTime), toFulfillSteps[i]);
                availableWorkers[i].Taakjes.Add(taakje);
                taskDoneAt.Add(toFulfillSteps[i], taakje.Stop);
            }
        }

        private int GetDuration(string letter, int defaultTime)
        {
            var character = letter.First();
            var index = char.ToUpper(character) - 64;
            return index + defaultTime;
        }

        private List<Worker> GetAvailableWorkers(List<Worker> workers, int time)
        {
            return workers.Where(w => w.IsAvailable(time)).ToList();
        }
        
        private List<Worker> InitializeWorkers(int nrWorkers)
        {
            var workers = new List<Worker>();
            for (var i = 0; i < nrWorkers; i++)
            {
                var w = new Worker(){Id = i};
                workers.Add(w);
            }

            return workers;
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
}
