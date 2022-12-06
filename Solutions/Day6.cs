using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day6
	{
		public static int CheckForDistinctIndex(string data, int requiredDistinct)
		{
			int total = 0;

			Queue<char> sequence = new Queue<char>();


			foreach (char character in data)
			{
				total++;
				sequence.Enqueue(character);
				if (sequence.Count == requiredDistinct)
				{
					List<char> list = sequence.ToList();

					if (list.Count == list.Distinct().Count())
					{
						break;
					}

					sequence.Dequeue();
				}
			}


			return total;
		}
	}
}