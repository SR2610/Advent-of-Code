using System;
using System.Collections.Generic;

namespace Advent_2022.Solutions
{
	public static class Day14
	{

		private static HashSet<(int, int)> map = new HashSet<(int, int)>();
		private static int lowestSolidHeight = int.MinValue;

		public static int SolvePartOne(string[] input)
		{
			foreach (string line in input)
			{
				string[] points = line.Split("->");

				Tuple<int, int> lastPoint = null;

				foreach (string point in points)
				{
					string[] coords = point.Trim().Split(',');
					Tuple<int, int> currentPoint = new Tuple<int, int>(int.Parse(coords[0]), int.Parse(coords[1]));
					if (lastPoint != null)
					{
						if(lastPoint.Item1!=currentPoint.Item1)
							CreateRock(lastPoint.Item1, currentPoint.Item1,true,lastPoint.Item2);
						else CreateRock(lastPoint.Item2, currentPoint.Item2,false,lastPoint.Item1);

					}

					if (currentPoint.Item2 > lowestSolidHeight)
						lowestSolidHeight = currentPoint.Item2;

					lastPoint = currentPoint;
				}
			}
			bool hasVoided = false;
			int sandDropped = 0;

			while (!hasVoided)
			{
				if (TryMoveSand(500, 0))
					sandDropped++;
				else
					hasVoided = true;
			}
			return sandDropped;
		}


		private static bool TryMoveSand(int xPos, int yPos)
		{
			if (yPos > lowestSolidHeight)
				return false;
			if (!map.Contains((xPos, yPos + 1)))
				return TryMoveSand(xPos, yPos + 1);
			if (!map.Contains((xPos-1, yPos + 1)))
				return TryMoveSand(xPos-1, yPos + 1);
			if (!map.Contains((xPos+1, yPos + 1)))
				return TryMoveSand(xPos+1, yPos + 1);
			map.Add((xPos, yPos));
			return true;
		}
		
		
		private static void CreateRock(int start, int stop, bool isX, int staticPos)
		{
			int length = Math.Abs(start-stop);
			for(int i=0; i <= length; i++)
			{
				int step = (start < stop) ? start + i : stop + (length-i);

				int xPos = isX ? step : staticPos;
				int yPos = isX ? staticPos : step;

				if(!map.Contains((xPos,yPos)))
					map.Add((xPos, yPos));
				
			}
		}
		
	}
}