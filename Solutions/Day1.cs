using System.Collections.Generic;
using System.Linq;

namespace Advent_2022.Solutions
{
	public static class Day1
	{
		//An Improved attempt at the Task 
		public static int CombinedSolver(int numElves, IEnumerable<string> data)
		{
			List<int> values = new List<int>();

			int current = 0;
			foreach (string line in data) //Get all the data and iterate through each line
			{
				if (int.TryParse(line, out int val)) //If its a number, add it to the current total
				{
					current += val;
					continue; //Break out of the iteration
				}

				values.Add(current); //Add to list
				current = 0;
			}

			if (current > 0) //Catch the end of file which doesn't have a newline after 
				values.Add(current);

			return values.OrderByDescending(value => value).Take(numElves).Sum(); //Return the top X values for the list
		}
	}
}