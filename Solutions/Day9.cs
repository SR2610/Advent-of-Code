﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day9
	{
		public static int SolveRope(IEnumerable<string> data, int knots)
		{
			List<Position> allKnotPositions = new List<Position>();
			HashSet<(int, int)> tailPositions = new HashSet<(int, int)>();
			for (int i = 0; i < knots; i++)
			{
				allKnotPositions.Add(new Position(0, 0));
			}

			foreach (string line in data)
			{
				char instruction = line[0];
				int repeats = int.Parse(line.Split(' ')[1]);
				for (int i = 0; i < repeats; i++)
				{
					allKnotPositions[0] = MoveHead(allKnotPositions[0], instruction);
					for (int k = 1; k < allKnotPositions.Count; k++)
					{
						allKnotPositions[k] = MoveKnot(allKnotPositions[k], allKnotPositions[k - 1]);
					}


					if (!tailPositions.Contains((allKnotPositions[^1].x, allKnotPositions[^1].y)))
						tailPositions.Add((allKnotPositions[^1].x, allKnotPositions[^1].y));

				
				}
			}


			return tailPositions.Count;
		}


		private static Position MoveHead(Position head, char instruction)
		{
			switch (instruction)
			{
				case 'R':
					head.x += 1;
					break;
				case 'L':
					head.x -= 1;
					break;
				case 'U':
					head.y += 1;
					break;
				case 'D':
					head.y -= 1;
					break;
			}

			return head;
		}


		private static Position MoveKnot(Position self, Position parent)
		{
			int stepX = parent.x - self.x;
			int stepY = parent.y - self.y;

			if (Math.Abs(stepX) <= 1 && Math.Abs(stepY) <= 1)
			{
				return self;
			}

			self.x += Math.Sign(stepX);
			self.y += Math.Sign(stepY);

			return self;
		}
	}

	public struct Position
	{
		public int x;
		public int y;

		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}