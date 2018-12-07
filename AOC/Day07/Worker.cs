using System.Collections.Generic;
using System.Linq;

namespace AOC.Day07
{
    public class Worker
    {
        public int Id { get; set; }
        public List<Taakje> Taakjes { get; set; }

        public bool IsAvailable(int time)
        {
            return Taakjes.Any(t => t.IsBusyOnTime(time)) == false;
        }

        public Worker()
        {
            Taakjes = new List<Taakje>();
        }

        public string WorkingOnStep(int time)
        {
            return Taakjes.FirstOrDefault(t => t.IsBusyOnTime(time))?.Step ?? "";
        }
    }
}