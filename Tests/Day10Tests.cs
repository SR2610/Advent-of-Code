using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day10Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(-1, Day10.SolvePartOne(Utils.GetDataFromFileAsLines("day10.txt", true)));
		}
		
		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(-1, Day10.SolvePartTwo(Utils.GetDataFromFileAsLines("day10.txt", true)));
		}
	}
}