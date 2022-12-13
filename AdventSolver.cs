using System;
using System.Linq;
using Advent_2022.Solutions;

namespace Advent_2022
{
	internal static class AdventSolver
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Day 1 Part 1: " + Day1.CombinedSolver(1, Utils.GetDataFromFileAsLines("day1.txt")));
			Console.WriteLine("Day 1 Part 2: " + Day1.CombinedSolver(3, Utils.GetDataFromFileAsLines("day1.txt")));
			Console.WriteLine("Day 2 Part 1: " + Day2.SolvePartOne(Utils.GetDataFromFileAsLines("day2.txt")));
			Console.WriteLine("Day 2 Part 2: " + Day2.SolvePartTwo(Utils.GetDataFromFileAsLines("day2.txt")));
			Console.WriteLine("Day 3 Part 1: " + Day3.SolvePartOne(Utils.GetDataFromFileAsLines("day3.txt")));
			Console.WriteLine("Day 3 Part 2: " + Day3.SolvePartTwo(Utils.GetDataFromFileAsLines("day3.txt")));
			Console.WriteLine("Day 4 Part 1: " + Day4.SolvePartOne(Utils.GetDataFromFileAsLines("day4.txt")));
			Console.WriteLine("Day 4 Part 2: " + Day4.SolvePartTwo(Utils.GetDataFromFileAsLines("day4.txt")));
			Console.WriteLine("Day 5 Part 1: " + Day5.SolvePartOne(Utils.GetDataFromFileAsLines("day5.txt")));
			Console.WriteLine("Day 5 Part 2: " + Day5.SolvePartTwo(Utils.GetDataFromFileAsLines("day5.txt")));
			Console.WriteLine("Day 6 Part 1: " + Day6.CheckForDistinctIndex(Utils.GetDataFromFile("day6.txt"), 4));
			Console.WriteLine("Day 6 Part 2: " + Day6.CheckForDistinctIndex(Utils.GetDataFromFile("day6.txt"), 14));
			Console.WriteLine("Day 7 Part 1: " + Day7.SolvePartOne(Utils.GetDataFromFileAsLines("day7.txt")));
			Console.WriteLine("Day 7 Part 2: " + Day7.SolvePartTwo(Utils.GetDataFromFileAsLines("day7.txt")));
			Console.WriteLine("Day 8 Part 1: " + Day8.SolvePartOne(Utils.GetDataFromFileAsLines("day8.txt").ToList()));
			Console.WriteLine("Day 8 Part 2: " + Day8.SolvePartTwo(Utils.GetDataFromFileAsLines("day8.txt").ToList()));
			Console.WriteLine("Day 9 Part 1: " + Day9.SolveRope(Utils.GetDataFromFileAsLines("day9.txt"), 2));
			Console.WriteLine("Day 9 Part 2: " + Day9.SolveRope(Utils.GetDataFromFileAsLines("day9.txt"), 10));
			Console.WriteLine("Day 10 Part 1: " +
			                  Day10.HandleInstructions(Utils.GetDataFromFileAsLines("day10.txt"), false));
			Console.WriteLine("Day 10 Part 2: ");
			Day10.HandleInstructions(Utils.GetDataFromFileAsLines("day10.txt"), true);
			Console.WriteLine();
			Console.WriteLine("Day 11 Part 1: " + Day11.DoMonkeyBusiness(Utils.GetDataFromFileAsLines("day11.txt").ToArray(), 20, false));
			Console.WriteLine("Day 11 Part 2: " + Day11.DoMonkeyBusiness(Utils.GetDataFromFileAsLines("day11.txt").ToArray(), 10000, true));
			Console.WriteLine("Day 12 Part 1: " + Day12.SolvePartOne(Utils.GetDataFromFileAsLines("day12.txt").ToList()));
			Console.WriteLine("Day 12 Part 2: " + Day12.SolvePartTwo(Utils.GetDataFromFileAsLines("day12.txt").ToList()));
			Console.WriteLine("Day 13 Part 1: " + Day13.SolvePartOne(Utils.GetDataFromFileAsLines("day13.txt").ToArray()));
			Console.WriteLine("Day 13 Part 2: " + Day13.SolvePartTwo(Utils.GetDataFromFileAsLines("day13.txt").ToArray()));

			Console.ReadLine();
		}
	}
}