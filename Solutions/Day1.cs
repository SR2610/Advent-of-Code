using System;
using System.Collections.Generic;
using System.Linq;

public static class Day1
{
	private static readonly int[] ThreeHighest = {0, 0, 0};

	public static void SolveTaskOne()
	{
		string[] data = Utils.GetDataFromFileAsLines("day1.txt");

		int highestCount = -1;


		int currentCount = 0;
		foreach (string line in data)
		{
			if (line == "")
			{
				if (currentCount > highestCount)
					highestCount = currentCount;

				currentCount = 0;
			}
			else
			{
				currentCount += int.Parse(line);
			}
		}

		if (currentCount > highestCount)
			highestCount = currentCount;

		Console.WriteLine(highestCount);
	}


	//An Improved attempt at the Task 
	public static int CombinedSolver(int numElves)
	{
		List<int> values = new List<int>();

		int current = 0;
		foreach (string line in Utils.GetDataFromFileAsLines("day1.txt")) //Get all the data and iterate through each line
		{
			if (int.TryParse(line, out int val)) //If its a number, add it to the current total
			{
				current += val;
				continue; //Break out of the iteration
			}

			values.Add(current); //Add to list
			current = 0;
		}

		values.Sort(); 
		values.Reverse(); 
		return values.GetRange(0, numElves).Sum(); //Return the top X values for the list
	}

	public static void SolveTaskTwo()
	{
		string[] data = Utils.GetDataFromFileAsLines("day1.txt");

		int currentCount = 0;
		foreach (string line in data)
		{
			if (line == "")
			{
				CheckIfTopThree(ref currentCount);
			}
			else
			{
				currentCount += int.Parse(line);
			}
		}

		if (currentCount > 0) //Check last line
		{
			CheckIfTopThree(ref currentCount);
		}

		Console.WriteLine(ThreeHighest.Sum());
	}

	private static void CheckIfTopThree(ref int currentCount)
	{
		for (int i = 0; i < ThreeHighest.Length; i++)
		{
			if (currentCount > ThreeHighest[i])
			{
				(ThreeHighest[i], currentCount) = (currentCount, ThreeHighest[i]);
			}
		}

		currentCount = 0;
	}
}