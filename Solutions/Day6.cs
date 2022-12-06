using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day6
	{
		public static int CheckForDistinctIndex(string data, int requiredDistinct)
		{
			for (int i = 0; i < data.Length; i++)
			{
				string check = data.Substring(i, requiredDistinct);
				if (requiredDistinct == check.Distinct().Count())
				{
					return i+requiredDistinct;
				}
				
			}
			return -1;
		}
	}
}