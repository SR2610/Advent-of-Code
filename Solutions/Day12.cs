using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Advent_2022.Solutions
{
    public static class Day12
    {
        private static Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>> AdjacencyList { get; } =
            new Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>>();


        public static int SolvePartOne(List<string> data)
        {
            AdjacencyList.Clear();
            GenerateMap(data, out var startPos, out var endPos);
            return GetShortestPath(startPos, endPos);
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private static int GetShortestPath(Tuple<int, int> startPos, Tuple<int, int> endPos)
        {
            Dictionary<Tuple<int, int>, Tuple<int, int>> previous = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(startPos);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                foreach (var neighbor in AdjacencyList[vertex])
                    if (!previous.ContainsKey(neighbor))
                    {
                        previous[neighbor] = vertex;
                        queue.Enqueue(neighbor);
                    }
            }

            var path = new List<Tuple<int, int>>();

            var current = endPos;
            while (!current.Equals(startPos))
            {
                path.Add(current);
                if (previous.ContainsKey(current))
                    current = previous[current];
                else
                    return int.MaxValue;
            }

            path.Add(startPos);
            path.Reverse();
            return path.Count() - 1;
        }

        private static HashSet<Tuple<int, int>> GenerateMap(List<string> data, out Tuple<int, int> startPos,
            out Tuple<int, int> endPos)
        {
            HashSet<Tuple<int, int>> lowestPoints = new HashSet<Tuple<int, int>>();
            int[,] map = new int[data.First().Length, data.Count()];
            startPos = new Tuple<int, int>(0, 0);
            endPos = new Tuple<int, int>(0, 0);
            for (int y = 0; y < data.Count(); y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    char currentPoint = data[y][x];
                    switch (currentPoint)
                    {
                        case 'S':
                            startPos = new Tuple<int, int>(x, y);
                            map[x, y] = 0;
                            break;
                        case 'E':
                            endPos = new Tuple<int, int>(x, y);
                            map[x, y] = 26;
                            break;
                        case 'a':
                            lowestPoints.Add(new Tuple<int, int>(x, y));
                            map[x, y] = char.ToUpper(currentPoint) - 64;
                            break;
                        default:
                            map[x, y] = char.ToUpper(currentPoint) - 64;
                            break;
                    }
                }
            }


            int width = map.GetLength(0);
            int height = map.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    HashSet<Tuple<int, int>> adjacent = new HashSet<Tuple<int, int>>();

                    if (x > 0 && map[x - 1, y] <= map[x, y] + 1)
                        adjacent.Add(new Tuple<int, int>(x - 1, y));
                    if (x < width - 1 && map[x + 1, y] <= map[x, y] + 1)
                        adjacent.Add(new Tuple<int, int>(x + 1, y));


                    if (y > 0 && map[x, y - 1] <= map[x, y] + 1)
                        adjacent.Add(new Tuple<int, int>(x, y - 1));

                    if (y < height - 1 && map[x, y + 1] <= map[x, y] + 1)
                        adjacent.Add(new Tuple<int, int>(x, y + 1));

                    AdjacencyList.Add(new Tuple<int, int>(x, y), adjacent);
                }
            }

            return lowestPoints;
        }

        public static int SolvePartTwo(List<string> data)
        {
            AdjacencyList.Clear();
            HashSet<Tuple<int, int>> points = GenerateMap(data, out var startPos, out var endPos);


            int shortestDistance = int.MaxValue;

            foreach (Tuple<int, int> lowPoint in points)
            {
                int dist = GetShortestPath(lowPoint, endPos);
                if (dist < shortestDistance)
                    shortestDistance = dist;
            }


            return shortestDistance;
        }
    }
}