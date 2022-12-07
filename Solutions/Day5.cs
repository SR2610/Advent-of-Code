using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day5
	{
		public static string SolvePartOne(IEnumerable<string> data)
		{
			return MoveStacks(data, false);
		}

		public static string SolvePartTwo(IEnumerable<string> data)
		{
			return MoveStacks(data, true);
		}


		private static string MoveStacks(IEnumerable<string> data, bool moveAsOne)
		{
			List<Stack<char>> stacks = new List<Stack<char>>();
			bool hasGotStacks = false;
			foreach (string line in data)
			{
				if (!hasGotStacks)
				{
					int stack = 0;
					for (int index = 0; index <= line.Length / 4; index++)
					{
						int toCheck = index * 4 + 1;
						if (line[toCheck] == '1')
						{
							hasGotStacks = true;

							int i;
							for (i = 0; i < stacks.Count; i++)
							{
								Stack<char> t = stacks[i];
								stacks[i] = new Stack<char>(t);
							}

							break;
						}

						if (stack + 1 > stacks.Count)
							stacks.Add(new Stack<char>());
						if (line[toCheck] != ' ')
						{
							stacks[stack].Push(line[toCheck]);
						}

						stack++;
					}
				}

				else
				{
					if (line.Length == 0)
						continue;
					string[] instructions = line.Split(" ");
					List<char> grabbed = new List<char>();
					for (int j = 0; j < int.Parse(instructions[1]); j++)
					{
						grabbed.Add(stacks[int.Parse(instructions[3]) - 1].Pop());
					}

					if (moveAsOne)
						grabbed.Reverse();

					foreach (char grab in grabbed)
					{
						stacks[int.Parse(instructions[5]) - 1].Push(grab);
					}
				}
			}

			return stacks.Aggregate("", (current, stack) => current + stack.Pop());
		}
	}
}