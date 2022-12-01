using System;
using System.Linq;

public class Day1
{
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

	static int[] threeHighest = {0, 0, 0};

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

		Console.WriteLine(threeHighest.Sum());
	}

	private static void CheckIfTopThree(ref int currentCount)
	{
		for (int i = 0; i < threeHighest.Length; i++)
		{
			if (currentCount > threeHighest[i])
			{
				(threeHighest[i], currentCount) = (currentCount, threeHighest[i]);
			}
		}

		currentCount = 0;
	}
}