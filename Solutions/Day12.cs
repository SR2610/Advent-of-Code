using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Advent_2022.Solutions
{
    public static class Day12
    {
        private static Dictionary<Position, HashSet<Position>> AdjacencyList { get; } =
            new Dictionary<Position, HashSet<Position>>();

        public static int SolvePartOne(List<string> data)
        {
            AdjacencyList.Clear();
            GenerateMap(data, out Position startPos, out Position endPos);
            return GetShortestPath(startPos, endPos);
        }

        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        private static int GetShortestPath(Position startPos, Position endPos)
        {
            var previous = new Dictionary<Position, Position>();

            var queue = new Queue<Position>();
            queue.Enqueue(startPos);

            while (queue.Count > 0)
            {
                Position vertex = queue.Dequeue();
                foreach (Position neighbor in AdjacencyList[vertex].Where(neighbor => !previous.ContainsKey(neighbor)))
                {
                    previous[neighbor] = vertex;
                    queue.Enqueue(neighbor);
                }
            }

            var path = new List<Position>();

            Position current = endPos;
            while (!current.Equals(startPos))
            {
                path.Add(current);
                if(previous.ContainsKey(current))
                 current = previous[current];
                else
                    return int.MaxValue;
            }

            path.Add(startPos);
            path.Reverse();
            return path.Count() - 1;
        }

        private static HashSet<Position> GenerateMap(List<string> data, out Position startPos, out Position endPos)
        {
            var lowestPoints = new HashSet<Position>();
            int[,] map = new int[data.First().Length, data.Count()];
            startPos = new Position(0, 0);
            endPos = new Position(0, 0);
            for (int y = 0; y < data.Count(); y++)
            for (int x = 0; x < data[y].Length; x++)
            {
                char currentPoint = data[y][x];
                switch (currentPoint)
                {
                    case 'S':
                        startPos = new Position(x, y);
                        map[x, y] = 0;
                        break;
                    case 'E':
                        endPos = new Position(x, y);
                        map[x, y] = 26;
                        break;
                    case 'a':
                        lowestPoints.Add(new Position(x, y));
                        map[x, y] = char.ToUpper(currentPoint) - 64;
                        break;
                    default:
                        map[x, y] = char.ToUpper(currentPoint) - 64;
                        break;
                }
            }


            int width = map.GetLength(0);
            int height = map.GetLength(1);

            for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                var adjacent = new HashSet<Position>();

                if (x > 0 && map[x - 1, y] <= map[x, y] + 1)
                    adjacent.Add(new Position(x - 1, y));
                if (x < width - 1 && map[x + 1, y] <= map[x, y] + 1)
                    adjacent.Add(new Position(x + 1, y));


                if (y > 0 && map[x, y - 1] <= map[x, y] + 1)
                    adjacent.Add(new Position(x, y - 1));

                if (y < height - 1 && map[x, y + 1] <= map[x, y] + 1)
                    adjacent.Add(new Position(x, y + 1));

                AdjacencyList.Add(new Position(x, y), adjacent);
            }

            return lowestPoints;
        }

        public static int SolvePartTwo(List<string> data)
        {
            AdjacencyList.Clear();
            var points = GenerateMap(data, out Position startPos, out Position endPos);


            int shortestDistance = int.MaxValue;
            foreach (Position lowPoint in points)
            {
                int dist = GetShortestPath(lowPoint, endPos);
                if (dist < shortestDistance)
                   shortestDistance = dist;
            }


            return shortestDistance;
        }
    }
}