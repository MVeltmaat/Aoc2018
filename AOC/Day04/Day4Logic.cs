using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC.Day04
{
    public interface IDay4
    {
        int ComputeActivities(List<ActivityRecord> input);
        int ComputeActivities(List<string> input);
    }

    public class Day4Logic : IDay4
    {
        public int ComputeActivities(List<ActivityRecord> input)
        {
            var sorted = input.OrderBy(i => i.TimeStamp).ToList();
            InitializeAwakeAndAsleep(sorted);
            List<GuardDateObject> guardsAsleep = InitializeSleepyTimes(sorted);

            var sleepiestGuardRecord = guardsAsleep.OrderByDescending(g => g.MinutesAsleep).FirstOrDefault();

            var sleepyGuard = sleepiestGuardRecord.Guard;

            var bestMinute = GetBestMinute(guardsAsleep, sleepyGuard);
            Console.WriteLine($"Sleepiest guard {sleepyGuard} on sleepiest minute {bestMinute}");
            return sleepyGuard * bestMinute;
        }

        public int ComputeActivities(List<string> input)
        {
            input.Sort();
            var activities = ParseActivities(input);

            List<GuardDateObject> guardsAsleep = InitializeSleepyTimes(activities);

            var sleepiestGuardRecord = guardsAsleep.OrderByDescending(g => g.MinutesAsleep).FirstOrDefault();
            foreach (var activityRecord in activities.Where(a => a.Guard == sleepiestGuardRecord.Guard))
            {
                Console.WriteLine(activityRecord);
            }

            var sleepyGuard = sleepiestGuardRecord.Guard;

            var bestMinute = GetBestMinute(guardsAsleep, sleepyGuard);
            Console.WriteLine($"Sleepiest guard {sleepyGuard} on sleepiest minute {bestMinute}");
            return sleepyGuard * bestMinute;
        }

        private List<ActivityRecord> ParseActivities(List<string> input)
        {
            var activities = new List<ActivityRecord>();
            int currentGuard = 0;
            foreach (string line in input)
            {
                var activityRecord = new ActivityRecord(line);
                if (activityRecord.Activity.Contains('#'))
                {
                    var words = activityRecord.Activity.Split('#', ' ');
                    // Guard #10 begins shift
                    currentGuard = int.Parse(words[3]);
                }

                activityRecord.Guard = currentGuard;
                if (activityRecord.Activity.Contains("asleep"))
                    activityRecord.FallsAsleep = true;
                if (activityRecord.Activity.Contains("wakes"))
                    activityRecord.WakesUp = true;

                activities.Add(activityRecord);
            }

            return activities;
        }

        private static List<GuardDateObject> InitializeSleepyTimes(IList<ActivityRecord> sorted)
        {
            var guardsAsleep = new List<GuardDateObject>();
            GuardDateObject guardDate = null;
            Nap nap = null;
            DateTime date = DateTime.MinValue;
            foreach (var activityRecord in sorted)
            {
                if (activityRecord.TimeStamp.Date != date)
                {
                    if (guardDate != null)
                        guardsAsleep.Add(guardDate);

                    guardDate = new GuardDateObject()
                    {
                        Date = activityRecord.TimeStamp.Date,
                        Guard = activityRecord.Guard
                    };
                }
                if (activityRecord.FallsAsleep)
                {
                    nap = new Nap() { Start = activityRecord.TimeStamp.Minute };
                }

                if (activityRecord.WakesUp)
                {
                    nap.Stop = activityRecord.TimeStamp.Minute;
                    guardDate.SleepyTimes.Add(nap);
                }

            }

            guardsAsleep.Add(guardDate);

            return guardsAsleep;
        }

        private static void InitializeAwakeAndAsleep(List<ActivityRecord> sorted)
        {
            var guard = 0;
            foreach (var activityRecord in sorted)
            {
                if (activityRecord.Activity.Contains('#'))
                {
                    var words = activityRecord.Activity.Split('#', ' ');
                    // Guard #10 begins shift
                    guard = int.Parse(words[3]);
                }

                activityRecord.Guard = guard;
                if (activityRecord.Activity.Contains("asleep"))
                    activityRecord.FallsAsleep = true;
                if (activityRecord.Activity.Contains("wakes"))
                    activityRecord.WakesUp = true;
            }
        }

        private  int GetBestMinute(List<GuardDateObject> guardsAsleep, int sleepyGuard)
        {
            var guardsRecords = guardsAsleep.Where(g => g.Guard == sleepyGuard).ToList();

            var minutes = new int[60];
            foreach (var sleepyTimes in guardsRecords.Select(r => r.SleepyTimes).ToList())
            {
                foreach (var sleepyTime in sleepyTimes)
                {
                    for (int i = sleepyTime.Start; i < sleepyTime.Stop; i++)
                    {
                        minutes[i]++;
                    }
                }
            }

            var maxAsleepMinutes = minutes.ToArray().Max();
            //for(int i = 0; i < minutes.Length; i++)
            //{
            //    Console.WriteLine($"{i} {minutes[i]}");
            //}
            var sleepiestMinute = Array.FindIndex(minutes, m => m == maxAsleepMinutes);
            return sleepiestMinute;
        }
    }

    internal class Nap
    {
        public int Start { get; set; }
        public int Stop { get; set; }
        public int TotalMinutes => Stop - Start;
    }

    internal class GuardDateObject{
        public int Guard { get; set; }
        public DateTime Date { get; set; }
        public int MinutesAsleep => SleepyTimes.Sum(s => s.TotalMinutes);
        public List<Nap> SleepyTimes { get; set; }

        public GuardDateObject()
        {
            SleepyTimes = new List<Nap>();
        }
    }
}
