using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Advent_2022.Solutions
{
    public static class Day4
    {
        public static int SolvePartOne(IEnumerable<string> data)
        {
            int total = 0;
            foreach (string line in data)
            {
                var bounds = new List<Vector2>();
                string[] sections = line.Split(',');

                bounds.AddRange(sections.Select(section => section.Split('-')).Select(ranges =>
                    new Vector2(float.Parse(ranges[0]), float.Parse(ranges[1]))));
                
                if ((bounds[0].X <= bounds[1].X && bounds[0].Y >= bounds[1].Y) ||
                    (bounds[1].X <= bounds[0].X && bounds[1].Y >= bounds[0].Y))
                    total++;
            }

            return total;
        }

        public static int SolvePartTwo(IEnumerable<string> data)
        {
            int total = 0;
            foreach (string line in data)
            {
                var bounds = new List<Vector2>();
                string[] sections = line.Split(',');

                bounds.AddRange(sections.Select(section => section.Split('-')).Select(ranges =>
                    new Vector2(float.Parse(ranges[0]), float.Parse(ranges[1]))));

                var range = Enumerable.Range((int) bounds[1].X, (int) (bounds[1].Y - bounds[1].X) + 1).ToList();
                var range2 = Enumerable.Range((int) bounds[0].X, (int) (bounds[0].Y - bounds[0].X) + 1).ToList();

                if (range.Contains((int) bounds[0].X) || range.Contains((int) bounds[0].Y) ||
                    range2.Contains((int) bounds[1].X) || range2.Contains((int) bounds[1].Y)) total++;
            }

            return total;
        }
    }
}