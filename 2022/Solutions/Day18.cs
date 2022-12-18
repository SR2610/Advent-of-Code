using System.Collections.Generic;

namespace Advent_2022.Solutions
{
    public static class Day18
    {
        private static readonly List<int[]> Cubes = new List<int[]>();

        public static int SolvePartOne(string[] input)
        {
            foreach (string line in input)
            {
                int[] cube = new int[3];
                string[] pos = line.Split(',');
                for (int i = 0; i < 3; i++) cube[i] = int.Parse(pos[i]);
                Cubes.Add(cube);
            }

            var allSides = new HashSet<int>();

            foreach (int[] cube in Cubes)
                for (int side = 0; side < 6; side++)
                {
                    int code = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        code = code * 100 + cube[i] * 2;
                        if (i == side / 2) code += side % 2 == 0 ? 1 : -1;
                    }

                    allSides.Add(code);
                }

            int connected = Cubes.Count * 6 - allSides.Count;
            int exposed = allSides.Count - connected;

            return exposed;
        }
    }
}