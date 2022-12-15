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
			List<Sensor> data = ParseInput(input);
			int minX = data
				.Select(s => s.sensorX - (s.distanceToSensor - Math.Abs(rowToCheck - s.sensorY)))
				.Min();
			int maxX = data
				.Select(s => s.sensorX + (s.distanceToSensor - Math.Abs(rowToCheck - s.sensorY)))
				.Max();

			int points = Enumerable.Range(minX, maxX - minX + 1)
				.Where(x => data.All(s => (s.beaconX, s.beaconY) != (x, rowToCheck)))
				.Count(x => data.Any(s => Math.Abs(x - s.sensorX) + Math.Abs(rowToCheck - s.sensorY) <= s.distanceToSensor));


			return points;
		}

		[SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
		public static long SolvePartTwo(string[] input, int maxDistance)
		{
			List<Sensor> data = ParseInput(input);

			(int x, int y) point = Enumerable.Range(0, maxDistance + 1)
				.Select(x => (x, data: data
					.Select(s => (sx: s.sensorX, sy: s.sensorY, distToX: s.distanceToSensor - Math.Abs(x - s.sensorX)))
					.Where(s => s.distToX >= 0)
					.Select(s => (s.sx, s.sy, minY: s.sy - s.distToX, maxY: s.sy + s.distToX))
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


		private static List<Sensor> ParseInput(string[] input)
		{
			List<Sensor> sensors = new List<Sensor>();

			foreach (string line in input)
			{
				string[] split = line.Replace(",", "").Replace(":", "").Split(' ');
				(int, int) beacon = (int.Parse(split[8].Split('=')[1]), int.Parse(split[9].Split('=')[1]));
				(int sensorX, int sensorY) = (int.Parse(split[2].Split('=')[1]), int.Parse(split[3].Split('=')[1]));
				Sensor sensor = new Sensor(sensorX, sensorY, Math.Abs(sensorX - beacon.Item1) + Math.Abs(sensorY - beacon.Item2), beacon.Item1, beacon.Item2);
				sensors.Add(sensor);
			}

			return sensors;
		}


		private readonly struct Sensor
		{
			public readonly int sensorX;
			public readonly int sensorY;
			public readonly int beaconX;
			public readonly int beaconY;
			public readonly int distanceToSensor;

			public override string ToString()
			{
				return $"{sensorX},{sensorY} : {beaconX},{beaconY} - {distanceToSensor}";
			}

			public Sensor(int sensorX, int sensorY, int distanceToSensor, int beaconX, int beaconY)
			{
				this.sensorX = sensorX;
				this.sensorY = sensorY;
				this.distanceToSensor = distanceToSensor;
				this.beaconX = beaconX;
				this.beaconY = beaconY;
			}
		}
	}
}