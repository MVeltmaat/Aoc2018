namespace AOC.Day07
{
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