using Advent_2022.Solutions;
using NUnit.Framework;

namespace Advent_2022.Tests
{
	public class Day2Tests
	{
		[Test]
		public void PartOneTest()
		{
			Assert.AreEqual(15, Day2.SolvePartOne(Utils.GetDataFromFileAsLines("day2.txt", true)));
		}

		[Test]
		public void PartTwoTest()
		{
			Assert.AreEqual(12, Day2.SolvePartTwo(Utils.GetDataFromFileAsLines("day2.txt", true)));
		}
	}
}