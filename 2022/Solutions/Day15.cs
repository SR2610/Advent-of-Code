using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day15
	{
		public static int SolvePartOne(string[] input, int rowToCheck)
		{
			List<Sensor> data = ParseInputToList(input);

			int minX = data
				.Select(sensor => sensor.sensorX - (sensor.distance - Math.Abs(rowToCheck - sensor.sensorY)))
				.Min();
			int maxX = data
				.Select(sensor => sensor.sensorX + (sensor.distance - Math.Abs(rowToCheck - sensor.sensorY)))
				.Max();

			int score = 0;

			for (int currentX = minX; currentX <= maxX; currentX++)
			{
				bool isBeacon = false;

				foreach (Sensor sensor in data)
				{
					if (sensor.beaconX == currentX && sensor.beaconY == rowToCheck)
					{
						isBeacon = true;
						break;
					}
				}

				if (isBeacon)
					continue;

				foreach (Sensor sensor in data)
				{
					if (currentX >= sensor.MinXAtY(rowToCheck) && currentX <= sensor.MaxXAtY(rowToCheck))
					{
						score++;
						break;
					}
				}
			}

			return score;
		}

		public static long SolvePartTwo(string[] input, int maxRow)
		{
			List<Sensor> data = ParseInputToList(input);
			List<(int, int)> bounds = new List<(int, int)>();

			for (int y = maxRow; y > 0; y--)
			{
				bounds.Clear();
				foreach (Sensor sensor in data)
				{
					if (Math.Max(sensor.MinXAtY(y), 0) <= Math.Min(sensor.MaxXAtY(y), maxRow))
					{
						bounds.Add((Math.Max(sensor.MinXAtY(y), 0), Math.Min(sensor.MaxXAtY(y), maxRow)));
					}
				}

				bounds.Sort((a, b) => a.Item1.CompareTo(b.Item1));

				bool isMerged = true;

				while (isMerged && bounds.Count > 1)
				{
					isMerged = false;

					if (bounds[0].Item1 <= bounds[1].Item1 && bounds[0].Item2 >= bounds[1].Item1)
					{
						bounds[0] = (bounds[0].Item1, Math.Max(bounds[0].Item2, bounds[1].Item2));
						bounds.RemoveAt(1);
						isMerged = true;
					}
				}

				if (!isMerged || bounds[0].Item1 != 0 || bounds[0].Item2 != maxRow)
				{
					return (bounds[0].Item2 + 1) * 4000000L + y;
				}
			}

			return 0;
		}

		private static List<Sensor> ParseInputToList(string[] input)
		{
			List<Sensor> result = new List<Sensor>();
			foreach (string line in input)
			{
				string[] split = line.Replace(",", "").Replace(":", "").Split(' ');
				(int, int) beacon = (int.Parse(split[8].Split('=')[1]), int.Parse(split[9].Split('=')[1]));
				(int sensorX, int sensorY) = (int.Parse(split[2].Split('=')[1]), int.Parse(split[3].Split('=')[1]));
				result.Add(new Sensor(sensorX, sensorY, beacon.Item1, beacon.Item2));
			}

			return result;
		}


		private class Sensor
		{
			public readonly int beaconX;
			public readonly int beaconY;
			public readonly int distance;
			public readonly int sensorX;
			public readonly int sensorY;

			public Sensor(int sX, int sY, int bX, int bY)
			{
				sensorX = sX;
				sensorY = sY;
				beaconX = bX;
				beaconY = bY;
				distance = Math.Abs(sensorX - beaconX) + Math.Abs(sensorY - beaconY);
			}

			public int MinXAtY(int y)
			{
				return sensorX - distance + Math.Abs(sensorY - y);
			}

			public int MaxXAtY(int y)
			{
				return sensorX + distance - Math.Abs(sensorY - y);
			}
		}
	}
}