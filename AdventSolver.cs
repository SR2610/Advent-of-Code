using System;
using Advent_2022.Solutions;

internal static class AdventSolver
{
	private static void Main(string[] args)
	{
		Console.WriteLine("Day 1 Part 1: " + Day1.CombinedSolver(1, Utils.GetDataFromFileAsLines("day1.txt")));
		Console.WriteLine("Day 1 Part 2: " + Day1.CombinedSolver(3, Utils.GetDataFromFileAsLines("day1.txt")));
		Console.WriteLine("Day 2 Part 1: " + Day2.SolvePartOne(Utils.GetDataFromFileAsLines("day2.txt")));
		Console.WriteLine("Day 2 Part 2: " + Day2.SolvePartTwo(Utils.GetDataFromFileAsLines("day2.txt")));

		Console.Read();
	}
}