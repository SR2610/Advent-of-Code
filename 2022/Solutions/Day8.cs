using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day8
	{
		private static Tree[,] Data;

		public static int SolvePartOne(List<string> input)
		{
			SetupTrees(input);
			return Data.Cast<Tree>().Count(tree => tree.visible);
		}

		private static void SetupTrees(IReadOnlyList<string> input)
		{
			Data = new Tree[input.Count(), input.First().Length];


			for (int y = 0; y < input.Count(); y++)
			{
				for (int x = 0; x < input[y].Length; x++)
				{
					Data[x, y] = new Tree((int) char.GetNumericValue(input[y][x]));
				}
			}

			int width = Data.GetLength(0);
			int height = Data.GetLength(1);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					//Check each of the four directions until check is oob

					bool visible = x == 0 || y == 0 || x == width - 1 || y == height - 1;

					int size = Data[x, y].height;
					int scoreUp = 0, scoreDown = 0, scoreLeft = 0, scoreRight = 0;
					for (int i = y - 1; i >= 0; i--) //UP
					{
						scoreUp++;
						if (Data[x, i].height >= size) break;

						if (i == 0)
							visible = true;
					}

					for (int i = y + 1; i < height; i++) //DOWN
					{
						scoreDown++;
						if (Data[x, i].height >= size) break;

						if (i == height - 1)
							visible = true;
					}

					for (int i = x - 1; i >= 0; i--) //LEFT
					{
						scoreLeft++;

						if (Data[i, y].height >= size) break;

						if (i == 0)
							visible = true;
					}


					for (int i = x + 1; i < width; i++) //RIGHT
					{
						scoreRight++;
						if (Data[i, y].height >= size) break;

						if (i == width - 1)
							visible = true;
					}

					Data[x, y].visible = visible;
					Data[x, y].score = scoreUp * scoreDown * scoreLeft * scoreRight;
				}
			}
		}


		public static int SolvePartTwo(List<string> input)
		{
			SetupTrees(input);

			return Data.Cast<Tree>().Select(tree => tree.score).Prepend(0).Max();
		}
	}

	public struct Tree
	{
		public Tree(int height)
		{
			this.height = height;
			score = 0;
			visible = false;
		}

		public readonly int height;
		public int score;
		public bool visible;
	}
}