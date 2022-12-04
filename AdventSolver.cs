using System;
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
            Console.Read();
        }
    }
}