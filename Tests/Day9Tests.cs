using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day9Tests
	{
		
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(-1, Day9.SolvePartOne(Utils.GetDataFromFileAsLines("day9.txt", true)));
		}
		
		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(-1, Day9.SolvePartTwo(Utils.GetDataFromFileAsLines("day9.txt", true)));
		}
	}
}