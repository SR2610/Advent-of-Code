using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day15
	{
		[SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
		public static int SolvePartOne(string[] input, int rowToCheck)
		{
			HashSet<(int, int, int, int, int)> data = ParseInput(input);
			int minX = data
				.Select(s => s.Item1 - (s.Item5 - Math.Abs(rowToCheck - s.Item2)))
				.Min();
			int maxX = data
				.Select(s => s.Item1 + (s.Item5 - Math.Abs(rowToCheck - s.Item2)))
				.Max();

			int points = Enumerable.Range(minX, maxX - minX + 1)
				.Where(x => data.All(sensor => (sensor.Item3, sensor.Item4) != (x, rowToCheck)))
				.Count(x => data.Any(sensor => Math.Abs(x - sensor.Item1) + Math.Abs(rowToCheck - sensor.Item2) <= sensor.Item5));


			return points;
		}

		[SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
		public static long SolvePartTwo(string[] input, int maxHeight)
		{
			HashSet<(int, int, int, int, int)> data = ParseInput(input);

			(int x, int y) point = Enumerable.Range(maxHeight/2, maxHeight + 1)
				.Select(x => (x, data: data
					.Select(s => (sensorX: s.Item1, sensorY: s.Item2, distToX: s.Item5 - Math.Abs(x - s.Item1)))
					.Where(s => s.distToX >= 0)
					.Select(s => (sensorX: s.sensorX, sensorY: s.sensorY, minY: s.sensorY - s.distToX, maxY: s.sensorY + s.distToX))
					.OrderBy(s => s.minY)
					.ToList()))
				.SelectMany(x =>
				{
					(int min, int max) range = (min: 0, max: 0);
					foreach ((_, _, int minY, int maxY) in x.data)
					{
						if (minY <= range.max + 1)
							range = (range.min, Math.Max(maxY, range.max));
						else
							return new[] {(x.x, y: range.max + 1)};
					}

					return Array.Empty<(int x, int y)>();
				})
				.First();

			return point.x * 4000000L + point.y;
		}


		private static HashSet<(int, int, int, int, int)> ParseInput(string[] input)
		{
			HashSet<(int, int, int, int, int)> result = new HashSet<(int, int, int, int, int)>();
			foreach (string line in input)
			{
				string[] split = line.Replace(",", "").Replace(":", "").Split(' ');
				(int, int) beacon = (int.Parse(split[8].Split('=')[1]), int.Parse(split[9].Split('=')[1]));
				(int sensorX, int sensorY) = (int.Parse(split[2].Split('=')[1]), int.Parse(split[3].Split('=')[1]));
				result.Add((sensorX, sensorY, beacon.Item1, beacon.Item2, Math.Abs(sensorX - beacon.Item1) + Math.Abs(sensorY - beacon.Item2)));
			}

			return result;
		}
	}
}