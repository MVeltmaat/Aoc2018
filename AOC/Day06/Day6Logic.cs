using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AOC.Day06
{
    public interface IDay6
    {
        int ComputeLargesFiniteArea(List<Point> coordinates);
        List<Point> ParseCoordinates(List<string> input);
    }

    public class Day6Logic : IDay6
    {
        public int ComputeLargesFiniteArea(List<Point> coordinates)
        {
            var gridWidth = coordinates.Select(c => c.X).Max()+1;
            var gridHeight = coordinates.Select(c => c.Y).Max()+1;

            var grid = new int[gridWidth, gridHeight];
            var dict = new Dictionary<long, Point>();
            var candidates = new Dictionary<long, Point>();
            for (int i = 0; i < coordinates.Count; i++)
            {
                // initialize grid
                dict.Add(i, coordinates[i]);
                candidates.Add(i, coordinates[i]);
                grid[coordinates[i].X, coordinates[i].Y] = i;
            }

            
            
            return 0;
        }

        public List<Point> ParseCoordinates(List<string> input)
        {
            var coordinates = new List<Point>();
            foreach (var line in input)
            {
                var numbers = line.Split(',');
                var x = int.Parse(numbers[0]);
                var y = int.Parse(numbers[1]);
                coordinates.Add(new Point(x, y));
            }

            return coordinates;
        }
    }
}
