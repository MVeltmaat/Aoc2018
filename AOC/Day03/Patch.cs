using System;
using System.Drawing;

namespace AOC.Day03
{
    public class Patch
    {
        public int Id { get; set; }
        public int StartHor { get; set; }
        public int StartVer { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Vierkantje { get; set; }
        
        public int TotalWidth => StartHor + Width;
        public int TotalHeight => StartVer + Height;

        public Patch(string input)
        {
            // #1 @ 662,777: 18x27
            char[] delimiterChars = { '#','@', ',', 'x', ':', '\t' };
            
            string[] words = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
            Id = Int16.Parse(words[0]);
            StartHor = Int16.Parse(words[1]);
            StartVer = Int16.Parse(words[2]);
            Width = Int16.Parse(words[3]);
            Height = Int16.Parse(words[4]);
            Vierkantje = new Rectangle(StartHor, StartVer, Width, Height);
        }

        public override string ToString()
        {
            return $"#{Id} @ {StartHor},{StartVer}: {Width}x{Height}";
        }


    }
}
