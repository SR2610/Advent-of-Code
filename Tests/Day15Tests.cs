using System.Linq;
using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day15Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(26, Day15.SolvePartOne(Utils.GetDataFromFileAsLines("day15.txt", true).ToArray(),10));
		}
		
		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(56000011, Day15.SolvePartTwo(Utils.GetDataFromFileAsLines("day15.txt", true).ToArray(),20));
		}
	}
}