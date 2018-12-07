namespace AOC.Day07
{
    public class Taakje
    {
        public string Step { get; set; }
        public int Start { get; set; }
        public int Stop => Start + Duration;
        public int Duration { get; set; }

        public Taakje(int start, int duration, string step)
        {
            Start = start;
            Duration = duration;
            Step = step;
        }

        public bool IsBusyOnTime(int time)
        {
            return time >= Start && time < Stop;
        }
    }
}