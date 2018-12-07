using System;

namespace AOC.Day04
{
    public class ActivityRecord
    {
        //[1518-11-01 00:00] Guard #10 begins shift
        //[1518 - 11 - 01 00:05] falls asleep
        //[1518 - 11 - 01 00:25] wakes up
        public int Guard { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Activity { get; set; }
        public bool FallsAsleep { get; set; }
        public bool WakesUp { get; set; }

        public ActivityRecord(string input)
        {
            char[] delimiterChars = { '[', ']',};

            string[] words = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            TimeStamp = DateTime.Parse(words[0]);
            Activity = words[1];
        }

        public override string ToString()
        {
            return $"{TimeStamp} {Guard} {Activity} {FallsAsleep} {WakesUp}";
        }
    }

}
