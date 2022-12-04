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
                bounds.AddRange(line.Split(',').Select(section => section.Split('-')).Select(ranges =>
                    new Vector2(float.Parse(ranges[0]), float.Parse(ranges[1]))));

                if (IsInBounds(bounds[0], bounds[1]))
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

                if (OverlapsBounds(bounds[0], bounds[1]))
                    total++;
            }

            return total;
        }


        private static bool IsInBounds(Vector2 boundsA, Vector2 boundsB)
        {
            return (boundsA.X <= boundsB.X && boundsA.Y >= boundsB.Y) ||
                   (boundsB.X <= boundsA.X && boundsB.Y >= boundsA.Y);
        }

        private static bool OverlapsBounds(Vector2 boundsA, Vector2 boundsB)
        {
            var rangeA = Enumerable.Range((int) boundsA.X, (int) (boundsA.Y - boundsA.X) + 1).ToList();
            var rangeB = Enumerable.Range((int) boundsB.X, (int) (boundsB.Y - boundsB.X) + 1).ToList();

            return rangeB.Contains((int) boundsA.X) || rangeB.Contains((int) boundsA.Y) ||
                   rangeA.Contains((int) boundsB.X) || rangeA.Contains((int) boundsB.Y);
        }
    }
}