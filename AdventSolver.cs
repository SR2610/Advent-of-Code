using System;

internal static class AdventSolver
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Day 1 Part 1: " + Day1.CombinedSolver(1, Utils.GetDataFromFileAsLines("day1.txt")));
		Console.WriteLine("Day 1 Part 2: " + Day1.CombinedSolver(3, Utils.GetDataFromFileAsLines("day1.txt")));

		Console.Read();
	}
}